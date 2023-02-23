namespace FinanceProcessor.Core.Models
{
	public class DeepBookDto
	{
		public string Symbol { get; set; }
		public List<BidDto> Bids { get; set; }
		public List<AskDto> Asks { get; set; }
	}
}
