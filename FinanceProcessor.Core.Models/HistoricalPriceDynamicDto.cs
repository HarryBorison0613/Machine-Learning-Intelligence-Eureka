namespace FinanceProcessor.Core.Models
{
	public class HistoricalPriceDynamicDto
	{
		public string Range { get; set; }
		public IEnumerable<IntradayPriceDto> HistoricalPriceDtos { get; set; }
	}
}
