using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Response;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.StockPrices
{
	public interface IStockPricesService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#book"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<BookResponse>> BookAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#delayed-quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<DelayedQuoteResponse>> DelayedQuoteAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#historical-prices"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="range"></param>
		/// <param name="qsb">Additional optional parameters</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<HistoricalPriceResponse>>> HistoricalPriceAsync(string symbol, ChartRange range = ChartRange.OneMonth, QueryStringBuilder qsb = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#historical-prices"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="date"></param>
		/// <param name="qsb">Additional optional parameters</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<IntradayPriceResponse>>> HistoricalPriceByDateAsync(string symbol, DateTime date, bool chartByDay, QueryStringBuilder qsb = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#historical-prices"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="qsb">Additional optional parameters</param>
		/// <returns></returns>
		Task<IEXResponse<HistoricalPriceDynamicResponse>> HistoricalPriceDynamicAsync(string symbol, QueryStringBuilder qsb = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#intraday-prices"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<IntradayPriceResponse>>> IntradayPricesAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#largest-trades"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<LargestTradeResponse>>> LargestTradesAsync(string symbol);

		/// <summary>
		/// https://iexcloud.io/docs/api/#ohlc
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<OHLCResponse>> OHLCAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#previous-day-price"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<HistoricalPriceResponse>> PreviousDayPriceAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#price"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<decimal>> PriceAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<Quote>> QuoteAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#quote"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="field"></param>
		/// <returns></returns>
		Task<IEXResponse<string>> QuoteFieldAsync(string symbol, string field);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#quote"/>
		/// US Stock Quote SSE Stream
		/// </summary>
		/// <param name="symbols"></param>
		/// <param name="UTP"></param>
		/// <param name="interval"></param>
		/// <returns></returns>
		SSEClient<QuoteSSE> QuoteStream(IEnumerable<string> symbols, bool UTP, StockQuoteSSEInterval interval);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#volume-by-venue"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<VolumeByVenueResponse>>> VolumeByVenueAsync(string symbol);
	}
}
