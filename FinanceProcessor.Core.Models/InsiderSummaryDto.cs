namespace FinanceProcessor.Core.Models
{
	public class InsiderSummaryDto
	{
		public string FullName { get; set; }
		public long? NetTransacted { get; set; }
		public string ReportedTitle { get; set; }
		public string Symbol { get; set; }
		public long? TotalBought { get; set; }
		public long? TotalSold { get; set; }
		public string Id { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public decimal Updated { get; set; }
	}
}
