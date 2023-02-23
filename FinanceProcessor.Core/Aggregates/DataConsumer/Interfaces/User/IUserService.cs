using FinanceProcessor.Core.Aggregates.Customer.DTOs;
using FinanceProcessor.Core.Aggregates.Customer.Enums;
using FinanceProcessor.Core.Aggregates.Customer.Models;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User
{
    public interface IUserService
    {
        Guid? CreateUser(CreateUserDto data, UserRole role);
        UserDto GetUserDataByUsername(string username);
        UserDto GetUser(Guid userId);
        List<FinanceUser> GetAllUsers(FilterUsersDto filterUsersDto);
        Task DeletedUser(Guid userId);
        UserDto UpdateUser(FinanceUser user);
        bool UpdatingProfile(CreateProfile profile);
        CreateProfile? GetUserProfile(string id);
    }
}
