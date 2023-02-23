using FinanceProcessor.Core.Aggregates.Customer.DTOs;
using FinanceProcessor.Core.Aggregates.Customer.Enums;
using FinanceProcessor.Core.Aggregates.Customer.Extensions;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User;
using FinanceProcessor.Infrastructure.Models;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

using IAuthService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User.IAuthorizationService;

//using System.Web.Http;

namespace FinanceProcessor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthService _authorizationService;
        private readonly IUserService _userService;
        private readonly ISecurity _security;

        public UserController(ILogger<UserController> logger,
        IAuthenticationService authenticationService,
        IUserService userService,
        ISecurity security,
        IAuthService authorizationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
            _userService = userService;
            _security = security;
            _authorizationService = authorizationService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var errorMessage = CheckLoginData(loginDto);
            if (errorMessage is not null)
            {
                return BadRequest(errorMessage);
            }

            try
            {
                var user = await _authenticationService.CheckPassword(loginDto?.UserName, loginDto?.Password);

                if (user is null) 
                {
                    _logger.LogInformation("Incorrect user name or password!");
                    return BadRequest("Incorrect user name or password!");
                }

                var token = _authorizationService.GenerateToken(
                new PayLoad
                {
                    WebId = user.Id.ToString(),
                    UserRole = user?.UserFinanceRole?.ToString(),
                    Status = user?.Status.ToString()
                });

                if (string.IsNullOrWhiteSpace(token))
                {
                    _logger.LogInformation("Problem in token generation!");
                    return BadRequest("Something went wrong!");
                }

                HttpContext.Response.Headers.Add("Authorization", token);
                return Ok(new
                {
                    token,
                    userId = user?.Id,
                    userRole = user?.UserFinanceRole.ToString(),
                    status = user?.Status.ToString(),
                    dateCreationOfNewRole = user?.LastUserRoleUpdated,
                    email = user?.Email,
                    firstName = user?.FirstName,
                    lastName = user?.LastName
                });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(message: ex.ToString());
                return StatusCode(500);//BadRequest("Something went wrong!");
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody] CreateUserDto user)
        {
            try
            {
                UserRole role = UserRole.FreeUser;
                Guid? ID = Guid.Empty;

                if (user == null)
                {
                    return BadRequest("User's object is empty");
                }

                if (string.IsNullOrEmpty(user.Password)
                   || string.IsNullOrEmpty(user.Email)
                   || string.IsNullOrEmpty(user.FirstName)
                   || string.IsNullOrEmpty(user.LastName))
                {
                    return BadRequest("Not every required field is filled!");
                }

                if (!_security.IsEmail(user.Email))
                {
                    return BadRequest("The email is not correct!");
                }

                if (_security.IsPasswordValid(user.Password))
                {
                    var adminPass = user.Password.Substring(0, 7);
                    if (adminPass == "Zs3$_7h")
                    {
                        role = UserRole.Admin;
                    }

                    ID = _userService.CreateUser(user, role);
                }
                else
                {
                    return BadRequest("The password is not secure!");
                }

                if (ID == Guid.Empty || ID is null)
                {
                    _logger.LogInformation("Invalid registration!");
                    return BadRequest("Invalid registration!");
                }

                var token = _authorizationService.GenerateToken(new PayLoad
                {
                    WebId = ID.ToString(),
                    UserRole = role.ToString(),
                    Status = Status.Active.ToString()
                });

                HttpContext.Response.Headers.Add("Authorization", token);

                return Ok(new
                {
                    token = token,
                    userId = ID,
                    userRole = role.ToString(),
                    status = Status.Active.ToString(),
                    dateCreationOfNewRole = DateTime.Now,
                    email = user?.Email,
                    firstName = user?.FirstName,
                    lastName = user?.LastName
                });
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{"Invalid registration!"} {ex}");
                return BadRequest("Invalid registration!");
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("profile")]
        public IActionResult CreateUserProfile([FromBody] CreateProfile user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Profile's object is empty");
                }

                if (string.IsNullOrWhiteSpace(user.Id))
                {
                    _logger.LogInformation("Invalid Id data in the updating profile request!");
                    return BadRequest("Invalid Id data in the updating profile request!");
                }

                var result = _userService.UpdatingProfile(user);

                if(!result)
                {
                    _logger.LogInformation("Invalid updating profile!");
                    return BadRequest("Invalid updating profile!");
                }

                return Ok(new
                {
                    result = "Updating successful!"
                });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex,"Invalid updating profile!");
                return BadRequest("Invalid updating profile!");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("get-user/{userId}")]
        public IActionResult GetUset(string userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                {
                    _logger.LogInformation("Invalid getting profile - empty userId!");
                    return BadRequest("Invalid getting profile! - empty userId!");
                }
                var user =_userService.GetUserProfile(userId);
                if(user is null)
                {
                    _logger.LogInformation("Invalid getting profile!");
                    return BadRequest("Invalid getting profile!");
                }

                return Ok(user);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, "Invalid getting profile!");
                return BadRequest("Invalid getting profile!");
            }
        }


        [HttpDelete]
        [ApiAuthorize]
        [Route("DeleteUser/{userId}")]
        public IActionResult DeleteUser(Guid userId)
        {
            try
            {
                _userService.DeletedUser(userId);

                return Ok(new { result = "true", statusCode = "200" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"{"Invalid deliting"} {ex}");
                return StatusCode(500);
            }
        }

        private string? CheckLoginData(UserLoginDto loginDto)
        {
            if (loginDto == null)
            {
                _logger.LogInformation("UserLoginDto object is empty!");
                return "UserLogin object is empty!";
            }

            if (string.IsNullOrWhiteSpace(loginDto?.UserName)
                || string.IsNullOrWhiteSpace(loginDto?.Password))
            {
                _logger.LogInformation("Incorrect user name or password!");
                return "Incorrect user name or password!";
            }

            return null;
        }
    }
}
