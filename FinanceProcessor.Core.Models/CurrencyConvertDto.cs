namespace FinanceProcessor.Core.Models
{
	public class CurrencyConvertDto : CurrencyRateDto
	{
		public decimal? Amount { get; set; }
	}
}
