namespace FinanceProcessor.Core.Models
{
	public class StatsRecordDto
	{
		public StatsRecordsValueDto Volume { get; set; }
		public StatsRecordsValueDto SymbolsTraded { get; set; }
		public StatsRecordsValueDto RoutedVolume { get; set; }
		public StatsRecordsValueDto Notional { get; set; }
	}
}
