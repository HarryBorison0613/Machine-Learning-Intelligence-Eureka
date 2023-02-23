namespace FinanceProcessor.Core.Models
{
	public class FundOwnershipDto
	{
		public string Symbol { get; set; }
		public long AdjHolding { get; set; }
		public long? AdjMv { get; set; }
		public string EntityProperName { get; set; }
		public long? Report_date { get; set; }
		public int ReportedHolding { get; set; }
		public long ReportedMv { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public long Date { get; set; }
		public decimal Updated { get; set; }
	}
}
