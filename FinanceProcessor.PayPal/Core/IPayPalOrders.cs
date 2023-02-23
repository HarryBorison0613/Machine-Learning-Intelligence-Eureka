using FinanceProcessor.PayPal.Models;

using PayPalCheckoutSdk.Orders;

namespace FinanceProcessor.PayPal.Core
{
    public interface IPayPalOrders
    {
        Task<Order> CreateOrder(OrderRequest orderDto);
        Task<bool> UpdateOrder(OrderDto orderDto);
        Task<OrderDto> GetOrder(string orderId);
        Task<Order> AuthorizeOrder(string orderId);
        Task<PayPalCheckoutSdk.Payments.Capture> CaptureOrder(string AuthorizationId);
    }
}
