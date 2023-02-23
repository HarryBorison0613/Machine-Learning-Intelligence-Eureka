namespace FinanceProcessor.Core.Models
{
	public class ExchangeRateDto
	{
		public DateTime Date { get; set; }
		public string FromCurrency { get; set; }
		public string ToCurrency { get; set; }
		public decimal Rate { get; set; }
	}
}
