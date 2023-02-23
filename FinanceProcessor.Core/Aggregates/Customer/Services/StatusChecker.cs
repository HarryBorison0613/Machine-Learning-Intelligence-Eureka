using FinanceProcessor.Core.Aggregates.Customer.Enums;
using FinanceProcessor.Core.Aggregates.Customer.Models;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User;

namespace FinanceProcessor.Core.Aggregates.Customer.Services
{
    public class StatusChecker : IStatusChecker
    {
        public bool Check(FinanceUser user)
        {
            if(user.LastUserRoleUpdated > GetPeriod(user.UserFinanceRole)
                || user.UserFinanceRole == UserRole.Admin)
            {
                return true;
            }

            return false;
        }

        private static DateTime GetPeriod(UserRole? userRole) => userRole switch
        {
            UserRole.FreeUser => DateTime.Now.AddDays(-7),
            UserRole.BasicUser => DateTime.Now.AddDays(-30),
            UserRole.ProfessionalUser => DateTime.Now.AddDays(-30),
            UserRole.ExpertUser => DateTime.Now.AddDays(-30),
            UserRole.Donator => DateTime.Now.AddDays(-30),
            UserRole.BasicUserForLongPeriod => DateTime.Now.AddYears(-1),
            UserRole.ProfessionalUserForLongPeriod => DateTime.Now.AddYears(-1),
            UserRole.ExpertUserForLongPeriod => DateTime.Now.AddYears(-1),
            UserRole.Admin => DateTime.Now.AddYears(-100),
            _ => throw new ArgumentOutOfRangeException(nameof(userRole), $"Not expected value of user role: {userRole}"),
        };
    }
}