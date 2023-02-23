using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface IStockPricesService
	{
		Task<Dictionary<string, IntradayPriceDto[]>> GetIntradayPricesForMostPopularSymbol(CancellationToken cancellationToken = default);
		Task<IEnumerable<IntradayPriceDto>> GetIntradayPricesAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<HistoricalPriceDto>> GetHistoricalPriceAsync(string symbol, ChartRange range = ChartRange.OneMonth, CancellationToken cancellationToken = default);
		Task<IEnumerable<IntradayPriceDto>> GetHistoricalPriceByDateAsync(string symbol, DateTime date, bool chartByDay = false, CancellationToken cancellationToken = default);
		Task<HistoricalPriceDynamicDto> GetHistoricalPriceDynamicAsync(string symbol, CancellationToken cancellationToken = default);
		Task<BookDto> GetBookAsync(string symbol, CancellationToken cancellationToken = default);
		Task<DelayedQuoteDto> GetDelayedQuoteAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<LargestTradeDto>> GetLargestTradesAsync(string symbol, CancellationToken cancellationToken = default);
		Task<OHLCDto> GetOHLCAsync(string symbol, CancellationToken cancellationToken = default);
		Task<HistoricalPriceDto> GetPreviousDayPriceAsync(string symbol, CancellationToken cancellationToken = default);
		Task<decimal> GetPriceAsync(string symbol, CancellationToken cancellationToken = default);
		Task<QuoteDto> GetQuoteAsync(string symbol, CancellationToken cancellationToken = default);
		Task<string> GetQuoteFieldAsync(string symbol, string field, CancellationToken cancellationToken = default);
		Task<IEnumerable<VolumeByVenueDto>> GetVolumeByVenueAsync(string symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<QuoteSSEDto>> GetQuoteStream(IEnumerable<string> symbols, bool UTP, StockQuoteSSEInterval interval, CancellationToken cancellationToken = default);
	}
}
