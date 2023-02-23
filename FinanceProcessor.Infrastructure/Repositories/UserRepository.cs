using FinanceProcessor.Core.Aggregates.Customer.DTOs;
using FinanceProcessor.Core.Aggregates.Customer.Enums;
using FinanceProcessor.Core.Aggregates.Customer.Models;
using FinanceProcessor.Core.Aggregates.Customer.Repository;
using FinanceProcessor.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System.Data;

namespace FinanceProcessor.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FinanceContext _financeContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(FinanceContext financeContext, 
        ILogger<UserRepository> logger)
        {
            _financeContext = financeContext;
            _logger = logger;
        }

        public Task<bool> ChangePassword(string? oldPass, string? newPass, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<FinanceUser?> CheckPassword(string? userName, string? password)
        {
            FinanceUser? user = _financeContext.Set<FinanceUser>()
                .Where(x => x.UserName == userName && x.Password == password && !x.IsDeleted)
                .FirstOrDefault();
            return user;
        }

        public Guid? CreateUser(CreateUserDto data, UserRole role)
        {
            var user = InitializeFinanceUser(data, role);
            _ = _financeContext.Add(user);
            _financeContext.SaveChanges();
            var userId = _financeContext.Set<FinanceUser>()
                .Where(x => x.UserName == data.Email)
                .Select(x => x.Id)
                .FirstOrDefault();
            if (userId is null)
            {
                return null;
            }

            return Guid.Parse(userId);
        }

        public CreateProfile? GetUserProfile(string id)
        {
            try
            {
                var user = _financeContext.Set<FinanceUser>()
                .Where(x => x.Id == id)
                .FirstOrDefault();

                if (user is null)
                {
                    _logger.LogError("There is no user with such Id : {id}!");
                    return null;
                }
                
                return ConvertToCreateProfile(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong during serching profile of user!");
                return null;
            }
        }

        private CreateProfile? ConvertToCreateProfile(FinanceUser data)
        {
            return new CreateProfile
            {
                City = data.City,
                LastName = data.LastName,
                FirstName = data.FirstName,
                AboutMe = data.AboutMe,
                Address = data.Address,
                Email = data.Email,
                Country = data.Country,
                PostalCode = data.PostalCode,
                AptSuite = data.AptSuite,
                AdminAria = data.AdminAria,
                RegionCode = data.RegionCode
            };
        }

        public bool UpdateUser(CreateProfile data)
        {
            try
            {
                var user = _financeContext.Set<FinanceUser>()
                .Where(x => x.Id == data.Id)
                .FirstOrDefault();

                if (user is null)
                {
                    _logger.LogError("Didn't find user by ID during updating profile!");
                    return false;
                }
                user = UpdateFinanceUser(data, user);
                _ = _financeContext.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Something went wrong during updating profile of user!");
                return false;
            }
        }

        public async Task<bool> UpdateUserStatus(string userId, UserRole userRole)
        {
            try
            {
                FinanceUser? user = await _financeContext.Set<FinanceUser>()
                    .Where(x => x.Id == userId && !x.IsDeleted)
                    .FirstOrDefaultAsync();

                if (user is null)
                {
                    _logger.LogError("User with such Id absent or deleted!");
                    return false;
                }

                user.UserFinanceRole = userRole;
                user.Status = Status.Active;
                user.LastUserRoleUpdated = DateTime.Now;

                await _financeContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                _logger.LogError("Something went wrong during changing role of user!");
                return false;
            }
        }

        public async Task DeleteUser(string userId)
        {
            FinanceUser? user = await _financeContext.Set<FinanceUser>()
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();
            
            if (userId is null)
            {
                return;
            }

            user.IsDeleted = true;
            await _financeContext.SaveChangesAsync();
        }

        private FinanceUser InitializeFinanceUser(CreateUserDto data, UserRole role)
        {
            return new FinanceUser
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                EmailConfirmed = true,
                UserName = data.Email,
                Password = data.Password,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                AccessFailedCount = 0,
                LockoutEnabled = false,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                LastUserRoleUpdated = DateTime.Now,
                UserFinanceRole = role,
                Status = Status.Active
            };
        }

        private FinanceUser UpdateFinanceUser(CreateProfile data, FinanceUser user)
        {
            user.City = data.City;
            user.LastName = data.LastName;
            user.FirstName = data.FirstName;
            user.AboutMe = data.AboutMe;
            user.Address = data.Address;
            user.Email = data.Email;
            user.Country = data.Country;
            user.PostalCode = data.PostalCode;
            user.AptSuite = data.AptSuite;
            user.AdminAria = data.AdminAria;
            user.RegionCode = data.RegionCode;
            user.LastUpdated = DateTime.Now;

            return user;

        }
    }
}
