using AutoMapper;

using FinanceProcessor.Core.Aggregates.Customer.DTOs;
using FinanceProcessor.Core.Aggregates.Customer.Enums;
using FinanceProcessor.Core.Aggregates.Customer.Repository;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Payment;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User;
using FinanceProcessor.Core.Aggregates.Security;
using FinanceProcessor.PayPal.Core;
using FinanceProcessor.PayPal.Models;
using FinanceProcessor.PayPalSubscriptions.Core;
using FinanceProcessor.PayPalSubscriptions.Models;

using Microsoft.Extensions.Logging;

using PayPalCheckoutSdk.Orders;

using PayPalSubscriptionNetSdk.Subscriptions;

using ApplicationContext = PayPalCheckoutSdk.Orders.ApplicationContext;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IPayPalOrders _payPalOrders;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<PaymentService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly ISubscriptionRatesRepositoriy subscriptionRatesRepositoriy;
        private readonly ISubscriptionManagement _subscriptionManagement;
        private readonly IMapper _mapper;
        private readonly ISetupSubscriptionClient _subscriptionClient;

        public PaymentService(IPayPalOrders payPalOrders,
        IUserRepository userRepository,
        ILogger<PaymentService> logger,
        IAuthorizationService authorizationService,
        ISubscriptionRatesRepositoriy subscriptionRatesRepositoriy,
        ISubscriptionManagement subscriptionManagement,
        IMapper mapper,
        ISetupSubscriptionClient subscriptionClient)
        {
            _payPalOrders = payPalOrders;
            _userRepository = userRepository;
            _logger = logger;
            _authorizationService = authorizationService;
            this.subscriptionRatesRepositoriy = subscriptionRatesRepositoriy;
            _subscriptionManagement = subscriptionManagement;
            _mapper = mapper;
            _subscriptionClient = subscriptionClient;
        }

        public async Task<Order> CreateOrder(OrderDto orderDto)
        {
            UserDataContainer.ClaimedRole = orderDto.ClaimedRole;
            return await _payPalOrders.CreateOrder(BuildRequestBody(orderDto));
        }

        public async Task<OrderDto> GetOrder(string orderId)
        {
            return await _payPalOrders.GetOrder(orderId);
        }

        public Task<bool> UpdateOrder(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        private static OrderRequest BuildRequestBody(OrderDto order)
        {

            var result = new OrderRequest
            {
                ApplicationContext = new ApplicationContext
                {
                    BrandName = "Finance Processor",
                    LandingPage = "BILLING",
                    UserAction = "CONTINUE",
                    CancelUrl = order?.ApplicationContext?.CancelUrl,
                    ReturnUrl = order?.ApplicationContext?.ReturnUrl
                },
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest
                    {
                        Description = "Finance Information",
                        SoftDescriptor = "Finance Processor",
                        AmountWithBreakdown = order?.PurchaseUnits?.FirstOrDefault()?.AmountWithBreakdown,
                    }
                },
                CheckoutPaymentIntent = "AUTHORIZE"
            };

            return result;
        }

        public async Task<(PayPalCheckoutSdk.Payments.Capture?, string?)> PayTheOrder(string userId, string orderId)
        {
            var authorizeOrderResult = await _payPalOrders.AuthorizeOrder(orderId);
            var AuthorizationId = authorizeOrderResult.PurchaseUnits.FirstOrDefault()?.Payments.Authorizations.FirstOrDefault()?.Id;
            if (string.IsNullOrWhiteSpace(AuthorizationId))
            {
                _logger.LogError("Didn't get AuthorizationId from PayPal!!!");
                return (null, null);
            }

            if (!Enum.TryParse(UserDataContainer.ClaimedRole, out UserRole userRole))
            {
                _logger.LogError("There is no such role!!!");
                return (null, null);
            };

            var result = await _payPalOrders.CaptureOrder(AuthorizationId);

            var isSuccess = await _userRepository.UpdateUserStatus(userId, userRole);
            if (!isSuccess)
            {
                _logger.LogError("User paid, but user role has not changed!!!");
                return (null, null);
            }

            var token = _authorizationService.GenerateToken(
                new PayLoad
                {
                    Status = Status.Active.ToString(),
                    UserRole = userRole.ToString(),
                    WebId = userId
                });

            return (result, token);
        }

        public Task<PayPalCheckoutSdk.Payments.Capture> CaptureOrder(string AuthorizationId)
        {
            return _payPalOrders.CaptureOrder(AuthorizationId);
        }

        public Plan? CreatePlan(PlanBodyDto planBody)
        {
           _subscriptionClient.Client();
           subscriptionRatesRepositoriy.FeelRoleRateTable();
            var product = _subscriptionManagement.CreateProduct(planBody);

            var raite = subscriptionRatesRepositoriy.GetRoleRate()
                //.Result
                .Where(x => x.UserRoleName == planBody.RequestedRole)
                .FirstOrDefault();

            var plan = _subscriptionManagement.CreatePlan(planBody,
                product.Id,
                _mapper.Map<SubscriptionRatesDto>(raite));

            return plan;
        }

        public SubscriptionDto? CreateSubscription(BuildSubscriptionDto subDto)
        {
            _subscriptionClient.Client();
            return _subscriptionManagement.CreateSubscription(subDto);
        }

        public void autorization()
        {

        }
    }
}
