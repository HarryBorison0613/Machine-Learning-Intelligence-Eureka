namespace FinanceProcessor.Core.Models
{
	public class UpcomingEventMarketDto
	{
		public List<IPOCalendarDto> Ipos { get; set; }
		public List<UpcomingEarningsDto> Earnings { get; set; }
		public List<DividendDto> Dividends { get; set; }
		public List<SplitDto> Splits { get; set; }
	}
}
