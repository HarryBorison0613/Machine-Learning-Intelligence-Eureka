namespace FinanceProcessor.Core.Models
{
	public class NewsDto
	{
		public string Symbol { get; set; }
		public long Datetime { get; set; }
		public string Headline { get; set; }
		public string Source { get; set; }
		public string Url { get; set; }
		public string Summary { get; set; }
		public string Related { get; set; }
		public string Image { get; set; }
		public string Lang { get; set; }
		public bool HasPaywall { get; set; }
	}
}
