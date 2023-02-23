namespace FinanceProcessor.Core.Models
{
	public class EarningModelDto
	{
		public DateTime EPSReportDate { get; set; }
		public decimal EPSSurpriseDollar { get; set; }
		public decimal EPSSurpriseDollarPercent { get; set; }
		public decimal ActualEPS { get; set; }
		public string AnnounceTime { get; set; }
		public decimal ConsensusEPS { get; set; }
		public string Currency { get; set; }
		public DateTime FiscalEndDate { get; set; }
		public string FiscalPeriod { get; set; }
		public int NumberOfEstimates { get; set; }
		public string PeriodType { get; set; }
		public string Symbol { get; set; }
		public decimal YearAgo { get; set; }
		public decimal YearAgoChangePercent { get; set; }
		public string Id { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public long Date { get; set; }
		public decimal Updated { get; set; }
	}
}
