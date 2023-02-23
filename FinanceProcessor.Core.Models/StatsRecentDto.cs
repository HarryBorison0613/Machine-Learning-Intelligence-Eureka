namespace FinanceProcessor.Core.Models
{
	public class StatsRecentDto
	{
		public DateTime Date { get; set; }
		public long Volume { get; set; }
		public long RoutedVolume { get; set; }
		public decimal MarketShare { get; set; }
		public bool IsHalfday { get; set; }
		public long LitVolume { get; set; }
	}
}
