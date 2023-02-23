namespace FinanceProcessor.Core.Models
{
	public class FinancialDto
	{
		public string Symbol { get; set; }
		public List<FinancialModelDto> Financials { get; set; }
	}
}
