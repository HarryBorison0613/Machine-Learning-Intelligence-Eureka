namespace FinanceProcessor.Core.Models
{
	public class CryptoSymbolDto
	{
		public string Symbol { get; set; }
		public string Name { get; set; }
		public string Exchange { get; set; }
		public DateTime Date { get; set; }
		public string Type { get; set; }
		public string IexId { get; set; }
		public string Region { get; set; }
		public string Currency { get; set; }
		public bool IsEnabled { get; set; }
	}
}
