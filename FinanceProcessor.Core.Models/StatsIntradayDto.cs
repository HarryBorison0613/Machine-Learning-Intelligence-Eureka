namespace FinanceProcessor.Core.Models
{
	public class StatsIntradayDto
	{
		public StatsIntradayValueDto Volume { get; set; }
		public StatsIntradayValueDto SymbolsTraded { get; set; }
		public StatsIntradayValueDto RoutedVolume { get; set; }
		public StatsIntradayValueDto Notional { get; set; }
		public StatsIntradayValueDto MarketShare { get; set; }
	}
}
