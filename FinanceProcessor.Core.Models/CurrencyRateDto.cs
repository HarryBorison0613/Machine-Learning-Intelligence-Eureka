namespace FinanceProcessor.Core.Models
{
	public class CurrencyRateDto
	{
		public string Symbol { get; set; }
		public decimal? Rate { get; set; }
		public long? Timestamp { get; set; }
		public bool? IsDerived { get; set; }
	}
}
