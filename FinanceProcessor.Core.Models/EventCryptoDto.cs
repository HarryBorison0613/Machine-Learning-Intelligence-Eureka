namespace FinanceProcessor.Core.Models
{
	public class EventCryptoDto
	{
		public string Symbol { get; set; }
		public string EventType { get; set; }
		public long Timestamp { get; set; }
		public string Reason { get; set; }
		public decimal Price { get; set; }
		public decimal Size { get; set; }
		public string Side { get; set; }

		public override string ToString() =>
			$"{Timestamp}:{Symbol},{EventType},{Price}";
	}
}
