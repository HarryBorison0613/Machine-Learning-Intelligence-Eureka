using FinanceProcessor.PayPal.Models;
using FinanceProcessor.PayPalSubscriptions.Models;

using PayPalCheckoutSdk.Orders;
using PayPalHttp;

using PayPalSubscriptionNetSdk.Subscriptions;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Payment
{
    public interface IPaymentService
    {
        Task<Order> CreateOrder(OrderDto orderDto);
        Task<bool> UpdateOrder(OrderDto orderDto);
        Task<OrderDto> GetOrder(string orderId);
        Task<PayPalCheckoutSdk.Payments.Capture> CaptureOrder(string AuthorizationId);
        Task<(PayPalCheckoutSdk.Payments.Capture?, string?)> PayTheOrder(string userId, string orderId);
        Plan? CreatePlan(PlanBodyDto planBody);
        SubscriptionDto? CreateSubscription(BuildSubscriptionDto subDto);
    }
}
