namespace FinanceProcessor.Core.Models
{
	public class QuoteDto
	{
		public string Symbol { get; set; }
		public string CompanyName { get; set; }
		public string PrimaryExchange { get; set; }
		public string CalculationPrice { get; set; }
		public decimal? Open { get; set; }
		public long? OpenTime { get; set; }
		public string OpenSource { get; set; }
		public decimal? Close { get; set; }
		public long? CloseTime { get; set; }
		public string CloseSource { get; set; }
		public decimal? High { get; set; }
		public long? HighTime { get; set; }
		public string HighSource { get; set; }
		public decimal? Low { get; set; }
		public long? LowTime { get; set; }
		public string LowSource { get; set; }
		public decimal? LatestPrice { get; set; }
		public string LatestSource { get; set; }
		public string LatestTime { get; set; }
		public long? LatestUpdate { get; set; }
		public long? LatestVolume { get; set; }
		public decimal? IexRealtimePrice { get; set; }
		public int? IexRealtimeSize { get; set; }
		public long? IexLastUpdated { get; set; }
		public decimal? DelayedPrice { get; set; }
		public long? DelayedPriceTime { get; set; }
		public decimal? OddLotDelayedPrice { get; set; }
		public decimal? OddLotDelayedPriceTime { get; set; }
		public decimal? ExtendedPrice { get; set; }
		public decimal? ExtendedChange { get; set; }
		public decimal? ExtendedChangePercent { get; set; }
		public long? ExtendedPriceTime { get; set; }
		public decimal? PreviousClose { get; set; }
		public decimal? PreviousVolume { get; set; }
		public decimal? Change { get; set; }
		public decimal? ChangePercent { get; set; }
		public decimal? Volume { get; set; }
		public decimal? IexMarketPercent { get; set; }
		public long? IexVolume { get; set; }
		public long? AvgTotalVolume { get; set; }
		public decimal? IexBidPrice { get; set; }
		public int? IexBidSize { get; set; }
		public decimal? IexAskPrice { get; set; }
		public int? IexAskSize { get; set; }
		public decimal? IexOpen { get; set; }
		public decimal? IexOpenTime { get; set; }
		public decimal? IexClose { get; set; }
		public long? IexCloseTime { get; set; }
		public long? MarketCap { get; set; }
		public decimal? PeRatio { get; set; }
		public decimal? Week52High { get; set; }
		public decimal? Week52Low { get; set; }
		public decimal? YtdChange { get; set; }
		public long? LastTradeTime { get; set; }
		public bool IsUSMarketOpen { get; set; }
		public string Sector { get; set; }
	}
}
