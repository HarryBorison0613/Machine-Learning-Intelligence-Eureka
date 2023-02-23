using System.ComponentModel;

namespace FinanceProcessor.IEXSharp.Model.CoreData.MarketInfo.Request
{
	public enum UpcomingEventType
	{
		[Description("events")]
		Events,
		[Description("dividends")]
		Dividends,
		[Description("splits")]
		Splits,
		[Description("earnings")]
		Earnings,
		[Description("ipos")]
		IPOs
	}
}