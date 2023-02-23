namespace FinanceProcessor.Core.Models
{
	public class DeepOfficialPriceDto
	{
		public string Symbol { get; set; }
		public string PriceType { get; set; }
		public decimal Price { get; set; }
		public long Timestamp { get; set; }
	}
}
