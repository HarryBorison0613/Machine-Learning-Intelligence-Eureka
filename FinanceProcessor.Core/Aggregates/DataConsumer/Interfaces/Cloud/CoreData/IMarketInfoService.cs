using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.MarketInfo.Request;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface IMarketInfoService
	{
		Task<IEnumerable<QuoteDto>> GetCollectionsAsync(CollectionType collectionType, string collectionName, CancellationToken cancellationToken = default);
		Task<IEnumerable<object>> GetEarningsTodayAsync(CancellationToken cancellationToken = default);
		Task<IEnumerable<IPOCalendarDto>> GetIPOCalendarAsync(IPOType ipoType, CancellationToken cancellationToken = default);
		Task<IEnumerable<QuoteDto>> GetListAsync(ListType listType, bool displayPercent = false, int listLimit = 10, CancellationToken cancellationToken = default);
		Task<IEnumerable<MarketVolumeUSDto>> GetMarketVolumeUSAsync(CancellationToken cancellationToken = default);
		Task<IEnumerable<SectorPerformanceDto>> GetSectorPerformanceAsync(CancellationToken cancellationToken = default);
		Task<IEnumerable<DividendDto>> GetUpcomingDividendsAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<DividendDto>> GetUpcomingDividendsMarketAsync(CancellationToken cancellationToken = default);
		Task<IEnumerable<UpcomingEarningsDto>> GetUpcomingEarningsAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<UpcomingEarningsDto>> GetUpcomingEarningsMarketAsync(CancellationToken cancellationToken = default);
		Task<IEnumerable<UpcomingEventMarketDto>> GetUpcomingEventMarketAsync(CancellationToken cancellationToken = default);
		Task<UpcomingEventMarketDto> GetUpcomingEventsAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IPOCalendarDto> GetUpcomingIposAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<IPOCalendarDto>> GetUpcomingIposMarketAsync(CancellationToken cancellationToken = default);
		Task<IEnumerable<SplitDto>> GetUpcomingSplitsAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<SplitDto>> GetUpcomingSplitsMarketAsync(CancellationToken cancellationToken = default);

		Task<IEnumerable<MarketVolumeUSDto>> GetMarketAsync(CancellationToken cancellationToken = default);
	}
}
