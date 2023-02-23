using System.ComponentModel;

namespace FinanceProcessor.IEXSharp.Model.CoreData.MarketInfo.Request
{
	public enum IPOType
	{
		[Description("upcoming-ipos")]
		Upcoming,
		[Description("today-ipos")]
		Today
	}
}