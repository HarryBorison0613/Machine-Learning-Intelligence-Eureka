using FinanceProcessor.Core.Aggregates.Customer.DTOs;
using FinanceProcessor.Core.Aggregates.Customer.Enums;
using FinanceProcessor.Core.Aggregates.Customer.Models;

namespace FinanceProcessor.Core.Aggregates.Customer.Repository;

public interface IUserRepository
{
    Task<FinanceUser> CheckPassword(string? userName, string? password);
    Task<bool> ChangePassword(string? oldPass, string? newPass, Guid id);
    Guid? CreateUser(CreateUserDto data, UserRole role);
    Task DeleteUser(string userId);
    Task<bool> UpdateUserStatus(string userId, UserRole userRole);
    bool UpdateUser(CreateProfile data);
    CreateProfile? GetUserProfile(string id);
}