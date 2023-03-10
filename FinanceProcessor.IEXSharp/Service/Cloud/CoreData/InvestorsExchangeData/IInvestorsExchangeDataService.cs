using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.InvestorsExchangeData.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.InvestorsExchangeData
{
	public interface IInvestorsExchangeDataService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<DeepResponse>> DeepAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep" and cref="https://iexcloud.io/docs/api/#sse-streaming"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		SSEClient<DeepResponse> DeepStream(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-auction"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, DeepAuctionResponse>>> DeepAuctionAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-auction" and cref="https://iexcloud.io/docs/api/#sse-streaming"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		SSEClient<DeepAuctionResponse> DeepAuctionStream(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-book"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, DeepBookResponse>>> DeepBookAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-book" and cref="https://iexcloud.io/docs/api/#sse-streaming"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		SSEClient<DeepBookResponse> DeepBookStream(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-operational-halt-status"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, DeepOperationalHaltStatusResponse>>> DeepOperationHaltStatusAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-operational-halt-status" and cref="https://iexcloud.io/docs/api/#sse-streaming"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		SSEClient<DeepOperationalHaltStatusResponse> DeepOperationHaltStatusStream(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-official-price"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, DeepOfficialPriceResponse>>> DeepOfficialPriceAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-official-price" and cref="https://iexcloud.io/docs/api/#sse-streaming"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		SSEClient<DeepOfficialPriceResponse> DeepOfficialPriceStream(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-security-event"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, DeepSecurityEventResponse>>> DeepSecurityEventAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-security-event" and cref="https://iexcloud.io/docs/api/#sse-streaming"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		SSEClient<DeepSecurityEventResponse> DeepSecurityEventStream(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-short-sale-price-test-status"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, DeepShortSalePriceTestStatusResponse>>> DeepShortSalePriceTestStatusAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-short-sale-price-test-status" and cref="https://iexcloud.io/docs/api/#sse-streaming"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		SSEClient<DeepShortSalePriceTestStatusResponse> DeepShortSalePriceTestStatusStream(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-system-event"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<DeepSystemEventResponse>> DeepSystemEventAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-system-event" and cref="https://iexcloud.io/docs/api/#sse-streaming"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		SSEClient<DeepSystemEventResponse> DeepSystemEventStream(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-trades"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, IEnumerable<DeepTradeResponse>>>> DeepTradeAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-trades" and cref="https://iexcloud.io/docs/api/#sse-streaming"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		SSEClient<DeepTradeStreamResponse> DeepTradeStream(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-trade-break"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, IEnumerable<DeepTradeResponse>>>> DeepTradeBreaksAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-trade-break" and cref="https://iexcloud.io/docs/api/#sse-streaming"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		SSEClient<DeepTradeStreamResponse> DeepTradeBreaksStream(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-trading-status"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, DeepTradingStatusResponse>>> DeepTradingStatusAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#deep-trading-status" and cref="https://iexcloud.io/docs/api/#sse-streaming"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		SSEClient<DeepTradingStatusStreamResponse> DeepTradingStatusStream(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#last"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<LastResponse>>> LastAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#listed-regulation-sho-threshold-securities-list-in-dev"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<ListedRegulationSHOThresholdSecuritiesListResponse>>> ListedRegulationSHOThresholdSecuritiesListAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#listed-short-interest-list-in-dev"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<ListedShortInterestListResponse>>> ListedShortInterestListAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stats-historical-daily-in-dev"/>
		/// </summary>
		/// <param name="date">yyyyMM or yyyyMMdd</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<StatsHisoricalDailyResponse>>> StatsHistoricalDailyByDateAsync(string date);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stats-historical-daily-in-dev"/>
		/// </summary>
		/// <param name="last">Up to 90</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<StatsHisoricalDailyResponse>>> StatsHistoricalDailyByLastAsync(int last);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stats-historical-summary"/>
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<StatsHistoricalSummaryResponse>>> StatsHistoricalSummaryAsync(DateTime? date = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stats-intraday"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<StatsIntradayResponse>> StatsIntradayAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stats-recent"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<StatsRecentResponse>>> StatsRecentAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stats-records"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<StatsRecordResponse>> StatsRecordAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#tops"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<TOPSResponse>>> TOPSAsync(IEnumerable<string> symbols);
	}
}