using FinanceProcessor.Core.Aggregates.Customer.Models;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User
{
    public interface IAuthenticationService
    {
        Task<FinanceUser?> CheckPassword(string? userName, string? password);
        Task<bool> ChangePassword(string? oldPass, string? newPass, Guid id);
        Task<bool> ResetPassword(string? username);
        Task Logout();
    }
}
