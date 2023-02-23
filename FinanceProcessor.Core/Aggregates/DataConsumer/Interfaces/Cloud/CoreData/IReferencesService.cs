using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.ReferenceData.Request;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface IReferencesService
	{
		Task<IEnumerable<SymbolDto>> GetSymbolsAsync();
		Task<IEnumerable<CryptoSymbolDto>> GetCryptoSymbolsAsync();
		Task<IEnumerable<IEXSymbolDto>> GetIEXSymbolsAsync();
		Task<IEnumerable<SectorDto>> GetAllSectorsAsync();
		Task<IEnumerable<TagDto>> GetAllTagsAsync();
		Task<IEnumerable<ForexPairDto>> GetForexPairsSymbolsAsync();
		Task<IEnumerable<ForexCurrencyDto>> GetForexCurrenciesAsync();
		Task<IEnumerable<MutualFundsSymbolDto>> GetMutualFundsSymbolsAsync();
		Task<IEnumerable<OTCSymbolDto>> GetOTCSymbolsAsync();
		Task<IEnumerable<ExchangeUSDto>> GetExchangesUSAsync();
		Task<IEnumerable<InternationalExchangeDto>> GetInternationalExchangesAsync();
		Task<IEnumerable<InternationalSymbolDto>> GetSymbolsInternationalRegionAsync(string region);
		Task<IEnumerable<InternationalSymbolDto>> GetSymbolsInternationalExchangeAsync(string exchange);
		Task<IEnumerable<SearchDto>> GetSearchAsync(string fragment);
		Task<IEnumerable<MappingDto>> GetFIGIMappingAsync(string figi);
		Task<IEnumerable<MappingDto>> GetISINMappingAsync(string isin);
		Task<IEnumerable<MappingDto>> GetRICMappingAsync(string ric);
		Task<IEnumerable<FutureSymbolUnderlyingDto>> GetSymbolsFuturesUnderlyingAsync(string underlying);
		Task<IEnumerable<HolidaysAndTradingDatesUSDto>> GetHolidaysAndTradingDatesUSAsync(
			DateType type, DirectionType direction = DirectionType.Next, int last = 1, DateTime? startDate = null);
	}
}
