namespace FinanceProcessor.Core.Models
{
	public class DeepTradingStatusDto
	{
		public string Symbol { get; set; }
		public string Status { get; set; }
		public string Reason { get; set; }
		public long Timestamp { get; set; }
	}
}
