namespace FinanceProcessor.Core.Aggregates.DataConsumer.Constants.StockPrices
{
	public class StockPricesRequestIdConstants
	{
		public const string GetIntradayPrices = "stock/symbol/intraday-prices";
		public const string GetHistoricalPrice = "stock/symbol/chart/range";
		public const string GetHistoricalPriceByDate = "stock/symbol/chart/date/date";
		public const string GetHistoricalPriceDynamic = "stock/symbol/chart/dynamic";
		public const string GetBook = "stock/symbol/book";
		public const string GetDelayedQuote = "stock/symbol/delayed-quote";
		public const string GetLargestTrades = "stock/symbol/largest-trades";
		public const string GetOHLC = "stock/symbol/ohlc";
		public const string GetPreviousDayPrice = "stock/symbol/previous";
		public const string GetPrice = "stock/symbol/price";
		public const string GetQuote = "stock/symbol/quote";
		public const string GetQuoteField = "stock/symbol/quote/field";
		public const string GetVolumeByVenue = "stock/symbol/volume-by-venue";
		public const string GetQuoteStream = "stocksUS";
	}
}
