namespace FinanceProcessor.IEXSharp.Model.CoreData.Crypto.Response
{
	public class EventCrypto
	{
		public string symbol { get; set; }
		public string eventType { get; set; }
		public long timestamp { get; set; }
		public string reason { get; set; }
		public decimal price { get; set; }
		public decimal size { get; set; }
		public string side { get; set; }

		public override string ToString() =>
			$"{timestamp}:{symbol},{eventType},{price}";
	}
}
