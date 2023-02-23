using AutoMapper;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.Batch.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.CeoCompensation.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.CorporateActions.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.Crypto.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.ForexCurrencies.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.Futures.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.FutureSymbols.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.InvestorsExchangeData.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.MarketInfo.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.News.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.Options.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.ReferenceData.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.Stock.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.StockFundamentals.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.StockProfiles.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.StockResearch.Response;
using FinanceProcessor.IEXSharp.Model.Shared.Response;
using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Mappings
{
	public sealed class IEXProfile : Profile
    {
        public IEXProfile()
        {
            CreateMap<HistoricalPriceResponse, HistoricalPriceDto>();
            CreateMap<IntradayPriceResponse, IntradayPriceDto>();
            CreateMap<HistoricalPriceDynamicResponse, HistoricalPriceDynamicDto>();
            CreateMap<BookResponse, BookDto>();
            CreateMap<Ask, AskDto>();
            CreateMap<Bid, BidDto>();
            CreateMap<DeepBookResponse, DeepBookDto>();
            CreateMap<Quote, QuoteDto>();
            CreateMap<SystemEvent, SystemEventDto>();
            CreateMap<Trade, TradeDto>();
            CreateMap<DelayedQuoteResponse, DelayedQuoteDto>();
            CreateMap<LargestTradeResponse, LargestTradeDto>();
            CreateMap<OHLCResponsePrice, OHLCResponsePriceDto>();
            CreateMap<OHLCResponse, OHLCDto>();
            CreateMap<VolumeByVenueResponse, VolumeByVenueDto>();
            CreateMap<QuoteSSE, QuoteSSEDto>(); 


            CreateMap<CryptoBookResponse, CryptoBookDto>();

            CreateMap<CryptoBookQuote, CryptoBookQuoteDto>();

            CreateMap<CryptoPriceResponse, CryptoPriceDto>();
            
            CreateMap<QuoteCryptoResponse, QuoteCryptoDto>();

            CreateMap<EventCrypto, EventCryptoDto>();

            CreateMap<QuoteCryptoResponse, QuoteCryptoDto>();

            CreateMap<NewsResponse, NewsDto>(); 

            CreateMap<SymbolInternationalResponse, InternationalSymbolDto>();
            CreateMap<MappingResponse, MappingDto>();
            CreateMap<HolidaysAndTradingDatesUSResponse, HolidaysAndTradingDatesUSDto>();
            CreateMap<SymbolResponse, SymbolDto>();
            CreateMap<Pair, ForexPairDto>();
            CreateMap<Currency, ForexCurrencyDto>();
            CreateMap<SymbolCryptoResponse, CryptoSymbolDto>();
            CreateMap<SymbolMutualFundResponse, MutualFundsSymbolDto>();
            CreateMap<SectorResponse, SectorDto>();
            CreateMap<SymbolOTCResponse, OTCSymbolDto>();
            CreateMap<SymbolIEXResponse, IEXSymbolDto>();
            CreateMap<TagResponse, TagDto>(); 
            CreateMap<ExchangeUSResponse, ExchangeUSDto>();
            CreateMap<ExchangeInternationalResponse, InternationalExchangeDto>();
            
            CreateMap<Quote, QuoteDto>();
            CreateMap<FutureSymbolUnderlyingResponse, FutureSymbolUnderlyingDto>();

            CreateMap<Dividend, DividendDto>();

            CreateMap<UpcomingEventMarketResponse, UpcomingEventMarketDto>();

            CreateMap<UpcomingEarningsResponse, UpcomingEarningsDto>();
            CreateMap<UpcomingEarningEvent, UpcomingEarningsDto>();
            
            CreateMap<Split, SplitDto>();

            CreateMap<IPOCalendarResponse, IPOCalendarDto>();
            CreateMap<MarketVolumeUSResponse, MarketVolumeUSDto>();
            CreateMap<SectorPerformanceResponse, SectorPerformanceDto>();

            CreateMap<AdvancedFundamentalsResponse, AdvancedFundamentalsDto>(); 
            CreateMap<FundamentalValuationsResponse, FundamentalValuationsDto>();
            CreateMap<Balancesheet, BalanceSheetModelDto> ();
            CreateMap<BalanceSheetResponse, BalanceSheetDto>();
            CreateMap<CashFlowsResponse, CashFlowsDto>();
            CreateMap<Cashflow, CashflowModelDto>();
            CreateMap<DividendBasicResponse, DividendBasicDto>();
            CreateMap<EarningResponse, EarningDto>();
            CreateMap<Earning, EarningModelDto>();
            CreateMap<FinancialResponse, FinancialDto>();
            CreateMap<Financial, FinancialModelDto>();
            CreateMap<IncomeStatementResponse, IncomeStatementDto>();
            CreateMap<Income, IncomeModelDto>();
            CreateMap<ReportedFinancialResponse, ReportedFinancialDto>();
            CreateMap<SplitBasicResponse, SplitBasicDto>();

            CreateMap<CorporateActionResponse, CorporateActionDto>();
            CreateMap<BonusIssueResponse, BonusIssueDto>();
            CreateMap<DistributionResponse, DistributionDto>();
            CreateMap<DividendAdvancedResponse, DividendAdvancedDto>();
            CreateMap<ReturnOfCapitalResponse, ReturnOfCapitalDto>();
            CreateMap<RightsIssueResponse, RightsIssueDto>();
            CreateMap<RightToPurchaseResponse, RightToPurchaseDto>();
            CreateMap<SecurityUpdateResponse, SecurityUpdateDto>();
            CreateMap<SpinOffResponse, SpinOffDto>();
            CreateMap<SplitAdvancedResponse, SplitAdvancedDto>();
            CreateMap<DividendForecastResponse, DividendForecastDto>();

            CreateMap<CeoCompensationResponse, CeoCompensationDto>();

            CreateMap<CompanyResponse, CompanyDto>();
            CreateMap<InsiderRosterResponse, InsiderRosterDto>();
            CreateMap<InsiderTransactionResponse, InsiderTransactionDto>();
            CreateMap<InsiderSummaryResponse, InsiderSummaryDto>();
            CreateMap<LogoResponse, LogoDto>();

            CreateMap<AdvancedStatsResponse, AdvancedStatsDto>();
            CreateMap<AnalystRecommendationsResponse, AnalystRecommendationsDto>();
            CreateMap<Estimate, EstimateDto>();
            CreateMap<EstimatesResponse, EstimatesDto>();
            CreateMap<FundOwnershipResponse, FundOwnershipDto>();
            CreateMap<InstitutionalOwnershipResponse, InstitutionalOwnershipDto>();
            CreateMap<KeyStatsResponse, KeyStatsDto>();
            CreateMap<PriceTargetResponse, PriceTargetDto>();
            CreateMap<TechnicalIndicatorsResponse, TechnicalIndicatorsDto>();
            CreateMap<RelevantStocksResponse, RelevantStocksDto>();

            CreateMap<BatchResponse, BatchDto>();
            CreateMap<Chart, ChartDto>();
            CreateMap<OptionResponse, OptionDto>();

            CreateMap<CurrencyConvertResponse, CurrencyConvertDto>();
            CreateMap<CurrencyHistoricalRateResponse, CurrencyHistoricalRateDto>();
            CreateMap<CurrencyRateResponse, CurrencyRateDto>();
            CreateMap<ExchangeRateResponse, ExchangeRateDto>();

            CreateMap<TimeSeriesResponse, TimeSeriesDto>();

            CreateMap<DeepAuctionResponse, DeepAuctionDto>();
            CreateMap<DeepResponse, DeepDto>();
            CreateMap<DeepOfficialPriceResponse, DeepOfficialPriceDto>();
            CreateMap<DeepOperationalHaltStatusResponse, DeepOperationalHaltStatusDto>();
            CreateMap<DeepSecurityEventResponse, DeepSecurityEventDto>();
            CreateMap<DeepShortSalePriceTestStatusResponse, DeepShortSalePriceTestStatusDto>();
            CreateMap<DeepSystemEventResponse, DeepSystemEventDto>();
            CreateMap<DeepTradeResponse, DeepTradeDto>();
            CreateMap<DeepTradingStatusResponse, DeepTradingStatusDto>();
            CreateMap<LastResponse, LastDto>();
            CreateMap<ListedRegulationSHOThresholdSecuritiesListResponse, ListedRegulationSHOThresholdSecuritiesListDto>();
            CreateMap<ListedShortInterestListResponse, ListedShortInterestListDto>();
            CreateMap<SecurityEvent, SecurityEventDto>();
            CreateMap<StatsHisoricalDailyResponse, StatsHisoricalDailyDto>();
            CreateMap<StatsHistoricalSummaryResponse, StatsHistoricalSummaryDto>();
            CreateMap<StatsIntradayResponse, StatsIntradayDto>();
            CreateMap<StatsIntradayValue, StatsIntradayValueDto>();
            CreateMap<StatsRecentResponse, StatsRecentDto>();
            CreateMap<StatsRecordResponse, StatsRecordDto>();
            CreateMap<StatsRecordsValue, StatsRecordsValueDto>();
            CreateMap<TOPSResponse, TOPSDto>();

            CreateMap<SearchResponse, SearchDto>();

            CreateMap<FutureResponse, FutureDto>();
        }
    }
}
