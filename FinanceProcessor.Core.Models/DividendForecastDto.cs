namespace FinanceProcessor.Core.Models
{
	public class DividendForecastDto
	{
		public decimal? AdjustedAmount { get; set; }
		public decimal? Amount { get; set; }
		public string Currency { get; set; }
		public DateTime? DeclaredDate { get; set; }
		public decimal? DisbursementAmount { get; set; }
		public string DisbursementType { get; set; }
		public DateTime? ExDate { get; set; }
		public string FiscalYear { get; set; }
		public DateTime? FiscalYearEndDate { get; set; }
		public string Frequency { get; set; }
		public DateTime? FxDate { get; set; }
		public DateTime? LastChange { get; set; }
		public string Marker { get; set; }
		public string Name { get; set; }
		public decimal? NonTaxedAmount { get; set; }
		public DateTime? PaymentDate { get; set; }
		public DateTime? PeriodEndDate { get; set; }
		public int? Position { get; set; }
		public DateTime? RecordDate { get; set; }
		public DateTime? RecordUpdated { get; set; }
		public decimal? SharesHeld { get; set; }
		public decimal? SharesReceived { get; set; }
		public string Status { get; set; }
		public string Symbol { get; set; }
		public string Id { get; set; }
		public string Key { get; set; }
		public string SubKey { get; set; }
		public decimal? NetAmount { get; set; }
		public decimal? Date { get; set; }
		public decimal? Updated { get; set; }
	}
}
