namespace FinanceProcessor.Core.Models
{
	public class MarketVolumeUSDto
	{
		public string Mic { get; set; }
		public string TapeId { get; set; }
		public string VenueName { get; set; }
		public long Volume { get; set; }
		public long TapeA { get; set; }
		public long TapeB { get; set; }
		public long TapeC { get; set; }
		public decimal MarketPercent { get; set; }
		public long? LastUpdated { get; set; }
	}
}
