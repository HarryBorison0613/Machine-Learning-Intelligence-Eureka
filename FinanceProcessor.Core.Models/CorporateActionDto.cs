namespace FinanceProcessor.Core.Models
{
	public class CorporateActionDto
	{
		public string Symbol { get; set; }
		public DateTime? ExDate { get; set; }
		public DateTime? RecordDate { get; set; }
		public DateTime? PaymentDate { get; set; }
		public decimal? FromFactor { get; set; }
		public decimal? ToFactor { get; set; }
		public decimal? Ratio { get; set; }
		public string Description { get; set; }
		public string Flag { get; set; }
		public string SecurityType { get; set; }
		public string Notes { get; set; }
		public string Figi { get; set; }
		public DateTime? LastUpdated { get; set; }
		public string CountryCode { get; set; }
		public decimal ParValue { get; set; }
		public string ParValueCurrency { get; set; }
		public long? Refid { get; set; }
		public DateTime? Сreated { get; set; }
		public string Id { get; set; }
		public string Source { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public long? Date { get; set; }
		public decimal? Updated { get; set; }
	}
}
