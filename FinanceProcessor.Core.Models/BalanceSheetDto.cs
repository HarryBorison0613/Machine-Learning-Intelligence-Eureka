namespace FinanceProcessor.Core.Models
{
	public class BalanceSheetDto
	{
		public string Symbol { get; set; }
		public List<BalanceSheetModelDto> Balancesheet { get; set; }
	}
}
