namespace FinanceProcessor.Core.Models
{
	public class IncomeStatementDto
	{
		public string Symbol { get; set; }
		public List<IncomeModelDto> Income { get; set; }
	}
}
