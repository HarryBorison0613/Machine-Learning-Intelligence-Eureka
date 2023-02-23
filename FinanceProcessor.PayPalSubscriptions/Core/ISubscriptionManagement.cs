using FinanceProcessor.PayPalSubscriptions.Models;
using PayPalSubscriptionNetSdk.Subscriptions;

namespace FinanceProcessor.PayPalSubscriptions.Core
{
    public interface ISubscriptionManagement
    {
        Product CreateProduct(PlanBodyDto planBodyDto);

        Plan? CreatePlan(PlanBodyDto planBodyDto,
            string productId,
            SubscriptionRatesDto? subscriptionRates);

        SubscriptionDto? CreateSubscription(BuildSubscriptionDto subDto);
    }
}