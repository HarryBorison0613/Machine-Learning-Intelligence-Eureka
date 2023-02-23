namespace FinanceProcessor.Core.Models
{
	public class LargestTradeDto
	{
		public decimal Price { get; set; }
		public long Size { get; set; }
		public long Time { get; set; }
		public string TimeLabel { get; set; }
		public string Venue { get; set; }
		public string VenueName { get; set; }
	}
}
