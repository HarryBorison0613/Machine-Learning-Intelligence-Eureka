using FinanceProcessor.PayPal.Models;

using PayPalCheckoutSdk.Orders;
using PayPalCheckoutSdk.Payments;

namespace FinanceProcessor.PayPal.Core
{
    public class PayPalOrders : IPayPalOrders
    {
        private readonly IPayPalClient _payPalClient;

        public PayPalOrders(IPayPalClient payPalClient)
        {
            _payPalClient = payPalClient;
        }

        public async Task<Order> CreateOrder(OrderRequest orderDto)
        {

            try
            {
                var request = new OrdersCreateRequest();
                request.Prefer("return=minimal");
                request.RequestBody(orderDto);
                var response = await _payPalClient.Client().Execute(request);
                var statusCode = response.StatusCode;
                var result = response.Result<Order>();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
                throw new Exception();
            }
        }

        public async Task<Order> AuthorizeOrder(string OrderId)
        {
            try
            {
                var request = new OrdersAuthorizeRequest(OrderId);
                request.Prefer("return=minimal");
                request.RequestBody(new AuthorizeRequest());
                var response = await _payPalClient.Client().Execute(request);
                var authorizeOrderResult = response.Result<Order>();

                return authorizeOrderResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
                throw new Exception();
            }
        }

        public async Task<PayPalCheckoutSdk.Payments.Capture> CaptureOrder(string AuthorizationId)
        {
            try
            {
                var request = new AuthorizationsCaptureRequest(AuthorizationId);
                request.Prefer("return=representation");
                request.RequestBody(new CaptureRequest());
                var response = await _payPalClient.Client().Execute(request);
                var captureOrderResult = response.Result<PayPalCheckoutSdk.Payments.Capture>();

                return captureOrderResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
                throw new Exception();
            }
        }

        public Task<bool> UpdateOrder(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetOrder(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}
