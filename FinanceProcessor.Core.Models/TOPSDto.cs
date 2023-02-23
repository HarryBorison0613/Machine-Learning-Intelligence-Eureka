namespace FinanceProcessor.Core.Models
{
	public class TOPSDto
	{
		public string Symbol { get; set; }
		public int BidSize { get; set; }
		public decimal BidPrice { get; set; }
		public int AskSize { get; set; }
		public decimal AskPrice { get; set; }
		public int Volume { get; set; }
		public decimal LastSalePrice { get; set; }
		public int LastSaleSize { get; set; }
		public long LastSaleTime { get; set; }
		public long LastUpdated { get; set; }
		public string Sector { get; set; }
		public string SecurityType { get; set; }
	}
}
