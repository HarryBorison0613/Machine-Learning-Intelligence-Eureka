namespace FinanceProcessor.Core.Models
{
	public class DividendDto
	{
		public string ExDate { get; set; }
		public string PaymentDate { get; set; }
		public string RecordDate { get; set; }
		public string DeclaredDate { get; set; }
		public string Date { get; set; }
		public string Updated { get; set; }
		public decimal? Amount { get; set; }
		public string Id { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public decimal? Refid { get; set; }
		public string Flag { get; set; }
		public string Currency { get; set; }
		public string Description { get; set; }
		public string Frequency { get; set; }
		public string Symbol { get; set; }
	}
}
