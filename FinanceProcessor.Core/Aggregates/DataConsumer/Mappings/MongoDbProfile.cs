using AutoMapper;
using FinanceProcessor.Core.Models;
using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Mappings
{
	public sealed class MongoDbProfile : Profile
    {
        public MongoDbProfile()
        {
            CreateMap<IntradayPrice, IntradayPriceDto>();

            CreateMap<Symbol, SymbolDto>()
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.SymbolId));

            CreateMap<CryptoSymbol, CryptoSymbolDto>();
            
            CreateMap<IEXSymbol, IEXSymbolDto>();

            CreateMap<News, NewsDto>();

            CreateMap<Sector, SectorDto>();

            CreateMap<Tag, TagDto>();

            CreateMap<ForexPair, ForexPairDto>();
            CreateMap<ForexCurrency, ForexCurrencyDto>();
            CreateMap<MutualFundsSymbol, MutualFundsSymbolDto>();
            CreateMap<OTCSymbol, OTCSymbolDto>();
            CreateMap<ExchangeUS, ExchangeUSDto>();
            CreateMap<InternationalExchange, InternationalExchangeDto>();
        }
    }
}
