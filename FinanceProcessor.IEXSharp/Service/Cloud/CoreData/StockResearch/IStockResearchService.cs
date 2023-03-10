using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.StockResearch.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.StockResearch.Response;
using FinanceProcessor.IEXSharp.Model.Shared.Request;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.StockResearch
{
	public interface IStockResearchService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#advanced-stats"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<AdvancedStatsResponse>> AdvancedStatsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#analyst-recommendations"/>
		/// (previously called Recommendation Trends, but renamed by IEX. Endpoint URL is still the same though.
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<AnalystRecommendationsResponse>>> AnalystRecommendationsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#estimates"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<EstimatesResponse>> EstimatesAsync(string symbol, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#estimates"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <param name="period"></param>
		/// <param name="last"></param>
		/// <returns></returns>
		Task<IEXResponse<string>> EstimateFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#fund-ownership"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<FundOwnershipResponse>>> FundOwnershipAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#institutional-ownership"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<InstitutionalOwnershipResponse>>> InstitutionalOwnerShipAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#key-stats"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<KeyStatsResponse>> KeyStatsAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#key-stats"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="stat"></param>
		/// <returns></returns>
		Task<IEXResponse<string>> KeyStatsStatAsync(string symbol, string stat);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#price-target"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<PriceTargetResponse>> PriceTargetAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#technical-indicators"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="indicator"></param>
		/// <param name="range"></param>
		/// <param name="lastIndicator"></param>
		/// <param name="indicatorOnly"></param>
		/// <returns></returns>
		Task<IEXResponse<TechnicalIndicatorsResponse>> TechnicalIndicatorsAsync(string symbol, IndicatorName indicatorName, ChartRange range, bool lastIndicator = false, bool indicatorOnly = false);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#relevant-stocks-deprecated"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<RelevantStocksResponse>> RelevantStocksAsync(string symbol);
	}
}
