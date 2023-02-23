using AutoMapper;

using FinanceProcessor.PayPalSubscriptions.Models;

using PayPalSubscriptionNetSdk.Subscriptions;

namespace FinanceProcessor.PayPalSubscriptions
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Subscription, SubscriptionDto>()
                .ReverseMap();
        }
    }
}
