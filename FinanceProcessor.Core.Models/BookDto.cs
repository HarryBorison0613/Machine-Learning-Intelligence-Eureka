namespace FinanceProcessor.Core.Models
{
	public class BookDto : DeepBookDto
	{
		public QuoteDto Quote { get; set; }
		public List<TradeDto> Trades { get; set; }
		public SystemEventDto SystemEvent { get; set; }
	}
}
