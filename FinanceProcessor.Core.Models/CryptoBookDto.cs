namespace FinanceProcessor.Core.Models
{
	public class CryptoBookDto
	{
		public List<CryptoBookQuoteDto> Bids { get; set; }
		public List<CryptoBookQuoteDto> Asks { get; set; }
	}
}
