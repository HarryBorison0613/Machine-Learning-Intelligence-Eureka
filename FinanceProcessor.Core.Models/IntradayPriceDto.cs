namespace FinanceProcessor.Core.Models
{
    public class IntradayPriceDto
    {
		public string Symbol { get; set; }
		public string Date { get; set; }
		public string Minute { get; set; }
		public string Label { get; set; }
		public decimal? High { get; set; }
		public decimal? Low { get; set; }
		public decimal? Open { get; set; } 
		public decimal? Close { get; set; }
		public decimal? Average { get; set; }
		public long? Volume { get; set; }
		public decimal? Notional { get; set; }
		public long? NumberOfTrades { get; set; }
		public decimal? ChangeOverTime { get; set; }
		public decimal? MarketOpen { get; set; }
		public decimal? MarketClose { get; set; }
		public decimal? MarketHigh { get; set; }
		public decimal? MarketLow { get; set; }
		public decimal? MarketAverage { get; set; }
		public long? MarketVolume { get; set; }
		public decimal? MarketNotional { get; set; }
		public long? MarketNumberOfTrades { get; set; }
		public decimal? MarketChangeOverTime { get; set; }
	}
}
