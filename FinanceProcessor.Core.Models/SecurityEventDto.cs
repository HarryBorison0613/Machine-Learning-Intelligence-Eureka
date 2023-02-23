namespace FinanceProcessor.Core.Models
{
	public class SecurityEventDto
	{
		public string Symbol { get; set; }
		public string SecurityEvent { get; set; }
		public long Timestamp { get; set; }
	}
}
