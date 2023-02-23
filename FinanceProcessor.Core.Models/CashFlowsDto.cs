namespace FinanceProcessor.Core.Models
{
	public class CashFlowsDto
	{
		public string Symbol { get; set; }
		public List<CashflowModelDto> Cashflow { get; set; }
		public string Id { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public long Date { get; set; }
		public decimal Updated { get; set; }
	}
}
