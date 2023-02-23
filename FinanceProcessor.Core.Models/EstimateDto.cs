namespace FinanceProcessor.Core.Models
{
	public class EstimateDto
	{
		public decimal ConsensusEPS { get; set; }
		public string AnnounceTime { get; set; }
		public long NumberOfEstimates { get; set; }
		public DateTime ReportDate { get; set; }
		public string FiscalPeriod { get; set; }
		public DateTime FiscalEndDate { get; set; }
	}
}