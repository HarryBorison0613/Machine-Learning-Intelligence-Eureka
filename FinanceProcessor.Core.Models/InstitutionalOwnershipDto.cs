namespace FinanceProcessor.Core.Models
{
	public class InstitutionalOwnershipDto
	{
		public string Symbol { get; set; }
		public string Id { get; set; }
		public long? AdjHolding { get; set; }
		public long? AdjMv { get; set; }
		public string EntityProperName { get; set; }
		public long ReportDate { get; set; }
		public string FilingDate { get; set; }
		public long? ReportedHolding { get; set; }
		public long Date { get; set; }
		public decimal Updated { get; set; }
	}
}