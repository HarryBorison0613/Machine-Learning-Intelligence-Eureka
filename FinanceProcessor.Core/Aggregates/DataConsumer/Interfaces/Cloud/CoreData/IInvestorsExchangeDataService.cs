using FinanceProcessor.Core.Models;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface IInvestorsExchangeDataService
	{
		Task<DeepDto> DeepAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default);
		//SSEClient<DeepDto> DeepStream(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<DeepAuctionDto>> DeepAuctionAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default);
		//SSEClient<DeepAuctionDto> DeepAuctionStream(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<DeepBookDto>> DeepBookAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default);
		//SSEClient<DeepBookDto> DeepBookStream(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<DeepOperationalHaltStatusDto>> DeepOperationHaltStatusAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default);
		//SSEClient<DeepOperationalHaltStatusDto> DeepOperationHaltStatusStream(string symbol, CancellationToken cancellationToken = default)

		Task<IEnumerable<DeepOfficialPriceDto>> DeepOfficialPriceAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default);

		//SSEClient<DeepOfficialPriceDto> DeepOfficialPriceStream(string symbol, CancellationToken cancellationToken = default);

		Task<IEnumerable<DeepSecurityEventDto>> DeepSecurityEventAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default);

		//SSEClient<DeepSecurityEventDto> DeepSecurityEventStream(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<DeepShortSalePriceTestStatusDto>> DeepShortSalePriceTestStatusAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default);

		//SSEClient<DeepShortSalePriceTestStatusDto> DeepShortSalePriceTestStatusStream(string symbol, CancellationToken cancellationToken = default);


		Task<DeepSystemEventDto> DeepSystemEventAsync(CancellationToken cancellationToken = default);

		//SSEClient<DeepSystemEventDto> DeepSystemEventStream(string symbol, CancellationToken cancellationToken = default);

		Task<Dictionary<string, IEnumerable<DeepTradeDto>>> DeepTradeAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default);
		//SSEClient<DeepTradeStreamDto> DeepTradeStream(string symbol = default);
		Task<Dictionary<string, IEnumerable<DeepTradeDto>>> DeepTradeBreaksAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default);
		//SSEClient<DeepTradeStreamDto> DeepTradeBreaksStream(string symbol = default);
		Task<IEnumerable<DeepTradingStatusDto>> DeepTradingStatusAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default);
		//SSEClient<DeepTradingStatusStreamDto> DeepTradingStatusStream(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<LastDto>> LastAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default);
		Task<IEnumerable<ListedRegulationSHOThresholdSecuritiesListDto>> ListedRegulationSHOThresholdSecuritiesListAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<ListedShortInterestListDto>> ListedShortInterestListAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<StatsHisoricalDailyDto>> StatsHistoricalDailyByDateAsync(string date, CancellationToken cancellationToken = default);
		Task<IEnumerable<StatsHisoricalDailyDto>> StatsHistoricalDailyByLastAsync(int last, CancellationToken cancellationToken = default);
		Task<IEnumerable<StatsHistoricalSummaryDto>> StatsHistoricalSummaryAsync(DateTime? date = null, CancellationToken cancellationToken = default);
		Task<StatsIntradayDto> StatsIntradayAsync(CancellationToken cancellationToken = default);
		Task<IEnumerable<StatsRecentDto>> StatsRecentAsync(CancellationToken cancellationToken = default);

		Task<StatsRecordDto> StatsRecordAsync(CancellationToken cancellationToken = default);
		Task<IEnumerable<TOPSDto>> TOPSAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default);
	}
}
