namespace FinanceProcessor.Core.Models
{
	public class DividendBasicDto : DividendDto
	{
		public long? Date { get; set; }
		public decimal Updated { get; set; }
	}
}
