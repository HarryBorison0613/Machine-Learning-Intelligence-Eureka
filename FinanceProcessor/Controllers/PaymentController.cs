using FinanceProcessor.Core.Aggregates.Customer.Extensions;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Payment;
using FinanceProcessor.PayPal.Models;
using FinanceProcessor.PayPalSubscriptions.Models;

using Microsoft.AspNetCore.Mvc;

using PayPalCheckoutSdk.Orders;

using PayPalSubscriptionNetSdk.Subscriptions;

//using Thinktecture.IdentityModel.Authorization.WebApi;

namespace FinanceProcessor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [ApiAuthorize]
        [Route("createorder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto order, CancellationToken cancellationToken)
         {
            if (!ModelState.IsValid) 
            {
                return StatusCode(500);
            }

            var resalt = new Order();

            try
            {
                resalt = await _paymentService.CreateOrder(order);


                if (resalt is null 
                    || !string.Equals(resalt.Status, "CREATED", StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest("Somthing went wrong!");
                }
            }
            catch
            {
                return StatusCode(500);
            }

            return Ok(new
            {
                result = resalt
            });
        }

        [HttpPost]
        [ApiAuthorize]
        [Route("paytheorder/{orderId}/{userId}")]
        public async Task<IActionResult> PayTheOrder(string orderId, string userId)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(500);
            }

            var result = (new PayPalCheckoutSdk.Payments.Capture(), string.Empty);

            try
            {
                result = await _paymentService?.PayTheOrder(/*UserDataContainer.UserId*/userId ,orderId);

                if (result.Item1 is null
                    || !string.Equals(result.Item1.Status, "COMPLETED", StringComparison.OrdinalIgnoreCase))
                {
                    return BadRequest("Something went wrong!");
                }
            }
            catch
            {
                return StatusCode(500);
            }

            return Ok(new
            {
                result = result.Item1,
                token = result.Item2
            });
        }

        [HttpPost]
        [ApiAuthorize]
        [Route("updateorder")]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderDto order)
        {
            var result = await _paymentService.UpdateOrder(order);

            if (!result)
            {
                return BadRequest("Something went wrong!");
            }

            return Ok(new
            {
                result = "Order Created!"
            });
        }

        [HttpPut]
        [ApiAuthorize]
        [Route("getorder/{orderId}")]
        public async Task<IActionResult> GetOrder(string orderId)
        {
            var order = await _paymentService.GetOrder(orderId);

            if (order is null)
            {
                return BadRequest("Something went wrong!");
            }

            return Ok(order);
        }

		[HttpPost]
		[ApiAuthorize]
		[Route("subscription")]
		public IActionResult CreateSubscription([FromQuery] BuildSubscriptionDto buildSubscription)
		{
			if (!ModelState.IsValid)
			{
				return StatusCode(500);
			}

			var resalt = new SubscriptionDto();

			try
			{
				resalt = _paymentService.CreateSubscription(buildSubscription);

				if (resalt is null)
				{
					return BadRequest("Somthing went wrong!");
				}
			}
			catch
			{
				return StatusCode(500);
			}

			return Ok(new
			{
				result = resalt
			});
		}

		[HttpPost]
		[ApiAuthorize]
		[Route("createplan")]
		public IActionResult CreatePlan([FromQuery] PlanBodyDto planBody)
		{
			if (!ModelState.IsValid)
			{
				return StatusCode(500);
			}

			var resalt = new Plan();

			try
			{
				resalt = _paymentService.CreatePlan(planBody);

				if (resalt is null)
				{
					return BadRequest("Somthing went wrong!");
				}
			}
			catch
			{
				return StatusCode(500);
			}

			return Ok(new
			{
				result = resalt
			});
		}
	}
}
