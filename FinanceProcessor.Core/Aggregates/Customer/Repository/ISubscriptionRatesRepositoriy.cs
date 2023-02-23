using FinanceProcessor.Core.Aggregates.Customer.Models;

namespace FinanceProcessor.Core.Aggregates.Customer.Repository
{
    public interface ISubscriptionRatesRepositoriy
    {
        void AddRoleRate(SubscriptionRates rates);
        /*Task<*/IEnumerable<SubscriptionRates> GetRoleRate();
        void FeelRoleRateTable();
    }
}
