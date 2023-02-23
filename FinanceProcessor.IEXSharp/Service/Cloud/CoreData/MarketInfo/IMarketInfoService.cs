using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.MarketInfo.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.MarketInfo.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.StockFundamentals.Response;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.MarketInfo
{
	public interface IMarketInfoService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#collections"/>
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="collectionName"></param>
		Task<IEXResponse<IEnumerable<Quote>>> CollectionsAsync(CollectionType collection, string collectionName);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#earnings-today"/>
		/// </summary>
		Task<IEXResponse<EarningTodayResponse>> EarningsTodayAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#intraday-prices"/>
		/// </summary>
		/// <param name="ipoType"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<IPOCalendarResponse>>> IPOCalendarAsync(IPOType ipoType);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#list"/>
		/// </summary>
		/// <param name="listType"></param>
		/// <param name="displayPercent"></param>
		/// <param name="listLimit"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<Quote>>> ListAsync(ListType listType, bool displayPercent = false,
			int listLimit = 10);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#market-volume-u-s"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<MarketVolumeUSResponse>>> MarketVolumeUSAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#sector-performance"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SectorPerformanceResponse>>> SectorPerformanceAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#upcoming-events"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<UpcomingEventMarketResponse>> UpcomingEventsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#upcoming-events"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<UpcomingEarningsResponse>>> UpcomingEarningsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#upcoming-events"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<Dividend>>> UpcomingDividendsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#upcoming-events"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<Split>>> UpcomingSplitsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#upcoming-events"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IPOCalendarResponse>> UpcomingIposAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#upcoming-events"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<UpcomingEventMarketResponse>>> UpcomingEventsMarketAsync();
		Task<IEXResponse<IEnumerable<Dividend>>> UpcomingDividendsMarketAsync();
		Task<IEXResponse<IEnumerable<Split>>> UpcomingSplitsMarketAsync();
		Task<IEXResponse<IEnumerable<UpcomingEarningsResponse>>> UpcomingEarningsMarketAsync();
		Task<IEXResponse<IEnumerable<IPOCalendarResponse>>> UpcomingIPOsMarketAsync();
		Task<IEXResponse<IEnumerable<MarketVolumeUSResponse>>> MarketAsync();
	}
}
