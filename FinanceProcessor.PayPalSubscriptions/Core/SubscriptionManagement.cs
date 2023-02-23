using AutoMapper;

using FinanceProcessor.PayPalSubscriptions.Models;

using Newtonsoft.Json;
using PayPalSubscriptionNetSdk.Subscriptions;
using RestSharp;

namespace FinanceProcessor.PayPalSubscriptions.Core
{
    public class SubscriptionManagement : ISubscriptionManagement
    {
        private readonly IMapper _mapper;

        public SubscriptionManagement(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Product CreateProduct(PlanBodyDto planBodyDto)
        {
            var product = new Product
            {
                Name = "Finance Service",
                Description = "Giving statistics and forecast for birge selling.",
                Type = ProductTypeEnum.SERVICE,
                Category = ProductCategoryEnum.SOFTWARE,
                ImageUrl = planBodyDto.ImageUrl,
                HomeUrl = planBodyDto.HomeUrl
            };

            var response = ProductResponse.ProductCreate(product);
            var result = JsonConvert.DeserializeObject<Product>(response.Content);

            return result;
        }

        public Plan? CreatePlan(PlanBodyDto planBodyDto,
            string productId,
            SubscriptionRatesDto? subscriptionRates)
        {
            var plan = BuildPlanBody(planBodyDto, productId, subscriptionRates);

            var response = PlanResponse.PlanCreate(plan);
            if (response is not null)
            {
                var result = JsonConvert.DeserializeObject<Plan>(response.Content);
                return result;
            }

            return null;
        }

        private static Plan BuildPlanBody(PlanBodyDto planBodyDto, 
            string productId,
            SubscriptionRatesDto subscriptionRates)
        {
            return new Plan()
            {
                ProductId = productId,
                Name = "Finance Service - Basic",
                Description = "Giving statistics and forecast for birge selling.",
                Status = PlanStatusEnum.ACTIVE,
                BillingCycles = new List<BillingCycle>()
                {
                    new BillingCycle()
                    {
                        Frequency = new Frequency()
                        {
                            IntervalUnit = "WEEK",  //????
                            IntervalCount = 1
                        },
                        TenureType = BillingCycleTenureTypeEnum.TRIAL,
                        Sequence = 1,
                        TotalCycles = 1,
                        PricingScheme = new PricingScheme()
                        {
                            FixedPrice = new Currency()
                            {
                                Value = "0",
                                CurrencyCode = "USD"
                            }
                        }
                    },
                    new BillingCycle()
                    {
                        Frequency = new Frequency()
                        {
                            IntervalUnit = "MONTH",//subscriptionRates.IntervalUnit,
                            IntervalCount = 1
                        },
                        TenureType = BillingCycleTenureTypeEnum.REGULAR,
                        Sequence = 2,
                        TotalCycles = 12,//subscriptionRates.TotalCycles,
                        PricingScheme = new PricingScheme()
                        {
                            FixedPrice = new Currency()
                            {
                                Value = "30",//subscriptionRates.SubscriptionPrice.ToString(),
                                CurrencyCode = "USD"
                            }
                        }
                    }
                },
                PaymentPreferences = new PaymentPreferences()
                {
                    AutoBillOutstanding = true,
                    //SetupFee = new Currency()    //?????????
                    //{
                    //    Value = "10",
                    //    CurrencyCode = "USD"
                    //},
                    SetupFeeFailureAction = PaymentPreferencesSetupFeeFailureActionEnum.CONTINUE,
                    PaymentFailureThreshold = 3
                },
                //Taxes = new Taxes()            //???????????
                //{
                //    Percentage = "10",
                //    Inclusive = false
                //}
            };
        }

        public SubscriptionDto? CreateSubscription(BuildSubscriptionDto subDto)
        {
            var subscription = BuildSubscriptionBody(subDto);

            var response = SubscriptionResponse.SubscriptionCreate(subscription);

            var result = JsonConvert.DeserializeObject<Subscription>(response.Content);

            return Convert(result);//_mapper.Map<SubscriptionDto>(result);
        }

        private SubscriptionDto? Convert(Subscription? result)
        {
            return new SubscriptionDto
            {
                Id = result.Id,
                PlanId = result.PlanId,
                Quantity = result.Quantity,
                ShippingAmount = result.ShippingAmount,
                Subscriber = result.Subscriber,
                Status = result.Status,
                StatusChangeNote = result.StatusChangeNote,
                StatusUpdateTime = result.StatusUpdateTime,
                StartTime = result.StartTime,
                CreateTime = result.CreateTime,
                Links = result.Links,
                ApplicationContext = result.ApplicationContext,
                BillingInfo = result.BillingInfo
            };
        }

        private static Subscription BuildSubscriptionBody(BuildSubscriptionDto subscription)
        {
            return new Subscription()
            {
                PlanId = subscription.PlanId,
                StartTime = DateTime.UtcNow.AddDays(1).ToString("s") + "Z",
                Subscriber = new Subscriber()
                {
                    Name = new Name
                    {
                        GivenName = subscription?.Subscriber?.Name?.GivenName,
                        Surname = subscription?.Subscriber?.Name?.Surname
                    },
                    EmailAddress = subscription?.Subscriber?.EmailAddress,
                    ShippingAddress = new ShippingAddress
                    {
                        Name = new FullName
                        {
                            Fullname = subscription?.Subscriber?.ShippingAddress?.Name?.Fullname
                        },
                        Address = new Address
                        {
                            AddressLine1 = subscription?.Subscriber?.ShippingAddress?.Address?.AddressLine1,
                            AddressLine2 = subscription?.Subscriber?.ShippingAddress?.Address?.AddressLine2,
                            AdminArea2 = subscription?.Subscriber?.ShippingAddress?.Address?.AdminArea1,
                            AdminArea1 = subscription?.Subscriber?.ShippingAddress?.Address?.AdminArea2,
                            PostalCode = subscription?.Subscriber?.ShippingAddress?.Address?.PostalCode,
                            CountryCode = subscription?.Subscriber?.ShippingAddress?.Address?.CountryCode
                        }
                    }
                },
                ApplicationContext = new ApplicationContext()
                {
                    BrandName = "Finance Processor",
                    Locale = subscription?.Locale,
                    ShippingPreference = ApplicationContextShippingPreferenceEnum.SET_PROVIDED_ADDRESS,
                    UserAction = ApplicationContextUserActionEnum.SUBSCRIBE_NOW,
                    PaymentMethod = new PaymentMethod()
                    {
                        PayerSelected = "PAYPAL",
                        PayeePreferred = "IMMEDIATE_PAYMENT_REQUIRED"
                    },
                    ReturnUrl = subscription?.ReturnUrl,
                    CancelUrl = subscription?.ReturnUrl
                }
            };
        }
    }
}
