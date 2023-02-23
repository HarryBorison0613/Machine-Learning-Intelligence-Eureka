using FinanceProcessor.Core.Aggregates.Customer.DTOs;
using FinanceProcessor.Core.Aggregates.Customer.Enums;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User
{
    public interface IAuthorizationService
    {
        string? GenerateToken(PayLoad payload);
        bool ValidateToken(string? token, UserRole _userRole, PayLoad payload);
    }
}
