namespace FinanceProcessor.Core.Models
{
	public class DeepShortSalePriceTestStatusDto
	{
		public bool IsSSR { get; set; }
		public string Symbol { get; set; }
		public string Detail { get; set; }
		public long Timestamp { get; set; }
	}
}
