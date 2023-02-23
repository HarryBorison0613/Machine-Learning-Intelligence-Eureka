using System.ComponentModel;

namespace FinanceProcessor.IEXSharp.Model.CoreData.Futures.Request
{
	public enum FuturesRange
	{
		[Description("1")]
		OneMonth,
		[Description("3")]
		ThreeMonths,
		[Description("6")]
		SixMonths,
		[Description("1y")]
		OneYear,
		[Description("2y")]
		TwoYears,
		[Description("5y")]
		FiveYears,
	}
}
