namespace FinanceProcessor.Core.Models
{
	public class EarningDto
	{
		public string Symbol { get; set; }
		public List<EarningModelDto> Earnings { get; set; }
	}
}
