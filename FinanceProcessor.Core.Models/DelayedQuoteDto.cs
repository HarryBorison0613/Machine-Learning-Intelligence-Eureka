namespace FinanceProcessor.Core.Models
{
	public class DelayedQuoteDto
	{
		public string Symbol { get; set; }
		public decimal DelayedPrice { get; set; }
		public long DelayedSize { get; set; }
		public long DelayedPriceTime { get; set; }
		public decimal High { get; set; }
		public decimal Low { get; set; }
		public long TotalVolume { get; set; }
		public long ProcessedTime { get; set; }
	}
}
