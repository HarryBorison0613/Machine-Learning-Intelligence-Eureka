using AutoMapper;
using FinanceProcessor.IEXSharp.Model.CoreData.News.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.ReferenceData.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Response;
using FinanceProcessor.IEXSharp.Model.Shared.Response;
using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.ApiConsumer.Mappings
{
	public sealed class ApiConsumerProfile : Profile
    {
        public ApiConsumerProfile()
        {
            CreateMap<IntradayPriceResponse, IntradayPrice>();

            CreateMap<NewsResponse, News>();

            CreateMap<SymbolResponse, Symbol>()
                .ForMember(dest => dest.SymbolId, opt => opt.MapFrom(src => src.symbol));

            CreateMap<SymbolCryptoResponse, CryptoSymbol>();

            CreateMap<SymbolIEXResponse, IEXSymbol>();

            CreateMap<SectorResponse, Sector>();
            CreateMap<TagResponse, Tag>();
            CreateMap<Pair, ForexPair>();
            CreateMap<Currency, ForexCurrency>();

            CreateMap<SymbolMutualFundResponse, MutualFundsSymbol>(); 
            CreateMap<SymbolOTCResponse, OTCSymbol>();
            CreateMap<ExchangeUSResponse, ExchangeUS>();
            CreateMap<ExchangeInternationalResponse, InternationalExchange>();
        }
    }
}
