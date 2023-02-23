using FinanceProcessor.Core.Aggregates.Customer.Models;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User
{
    public interface IStatusChecker
    {
        bool Check(FinanceUser user);
    }
}
