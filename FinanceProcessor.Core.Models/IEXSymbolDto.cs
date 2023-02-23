namespace FinanceProcessor.Core.Models
{
	public class IEXSymbolDto
	{
		public string Symbol { get; set; }
		public DateTime Date { get; set; }
		public bool IsEnabled { get; set; }
	}
}
