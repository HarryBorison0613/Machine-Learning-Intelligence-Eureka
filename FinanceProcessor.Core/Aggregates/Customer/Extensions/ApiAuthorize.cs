using AutoMapper.Internal;

using FinanceProcessor.Core.Aggregates.Customer.DTOs;
using FinanceProcessor.Core.Aggregates.Customer.Enums;
using FinanceProcessor.Core.Aggregates.Customer.Models;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User;
using FinanceProcessor.Core.Aggregates.security;
using FinanceProcessor.Core.Aggregates.Security;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System.IdentityModel.Tokens.Jwt;

namespace FinanceProcessor.Core.Aggregates.Customer.Extensions
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiAuthorize : Attribute, IAuthorizationFilter
    {
        private readonly IAuthorizationService _authService = new AuthorizationService();
        private readonly ISecurity _security = new SecurityCrypts();
        private readonly UserRole _userRole = UserRole.FreeUser;

        public ApiAuthorize(UserRole role = UserRole.FreeUser)
        {
            _userRole = role;
        }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            try
            {
                var token = filterContext.HttpContext.Request.Headers.GetOrDefault("Authorization").First();

                if(string.IsNullOrWhiteSpace(token))
                {
                    Unauthorized();
                    return;
                }

                token = token[(token.IndexOf(" ", StringComparison.Ordinal) + 1)..];

                if (string.IsNullOrWhiteSpace(token))
                {
                    Unauthorized();
                    return;
                }

                token = _security.DecryptStringFromBytes(Convert.FromBase64String(token));
                var claim = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var result = claim.Payload.TryGetValue("sub", out var webIdObj);
                if (result)
                {
                    var res = webIdObj?.ToString()?.Split('"');

                    if (res is null)
                    {
                        Unauthorized();
                        return;
                    }

                    UserDataContainer.UserId = res[3];
                    UserDataContainer.UserRole = res[7];
                    UserDataContainer.Status = res[11];
                }
                else
                {
                    Unauthorized();
                    return;
                }

                var isValidata = _authService.ValidateToken(token, _userRole, new PayLoad()
                {
                    WebId = UserDataContainer.UserId,
                    UserRole = UserDataContainer.UserRole,
                    Status = UserDataContainer.Status
                });

                if (!isValidata)
                {
                    Unauthorized();
                    return;
                }

                return;

                void Unauthorized()
                {
                    filterContext.Result = new JsonResult(new { massege = "unauthorized" })
                    {
                        StatusCode = 401
                    };
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
