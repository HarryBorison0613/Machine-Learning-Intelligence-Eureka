namespace FinanceProcessor.Core.Models
{
	public class StatsRecordsValueDto
	{
		public decimal RecordValue { get; set; }
		public DateTime RecordDate { get; set; }
		public decimal PreviousDayValue { get; set; }
		public decimal Avg30Value { get; set; }
	}
}
