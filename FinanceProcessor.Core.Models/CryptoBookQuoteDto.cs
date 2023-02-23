namespace FinanceProcessor.Core.Models
{
	public class CryptoBookQuoteDto
	{
		public decimal Price { get; set; }
		public decimal Size { get; set; }
		public long Timestamp { get; set; }
	}
}
