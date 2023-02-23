namespace FinanceProcessor.Core.Models
{
	public class DeepOperationalHaltStatusDto
	{
		public string Symbol { get; set; }
		public bool IsHalted { get; set; }
		public long Timestamp { get; set; }
	}
}
