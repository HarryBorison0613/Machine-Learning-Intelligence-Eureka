namespace FinanceProcessor.Core.Models
{
	public class OHLCDto
	{
		public OHLCResponsePriceDto Open { get; set; }
		public OHLCResponsePriceDto Close { get; set; }
		public decimal? High { get; set; }
		public decimal? Low { get; set; }
		public string Symbol { get; set; }
		public decimal? Volume { get; set; }

	}
}
