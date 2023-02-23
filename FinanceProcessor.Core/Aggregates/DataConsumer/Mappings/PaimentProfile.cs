using AutoMapper;

using FinanceProcessor.Core.Aggregates.Customer.Models;
using FinanceProcessor.PayPalSubscriptions.Models;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Mappings
{
    public class PaimentProfile : Profile
    {
        public PaimentProfile()
        {
            CreateMap<SubscriptionRatesDto, SubscriptionRates>()
                .ReverseMap();
        }
    }
}
