using System.ComponentModel;

namespace FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request
{
	public enum ChartRange
	{
		//[Description("dynamic")]
		//Dynamic,
		//[Description("date")]
		//Date,
		//[Description("5dm")]
		//FiveDayMinute,
		//[Description("1mm")]
		//OneMonthMinute,
		[Description("5d")]
		FiveDay,
		[Description("1m")]
		OneMonth,
		[Description("3m")]
		ThreeMonths,
		[Description("6m")]
		SixMonths,
		[Description("ytd")]
		Ytd,
		[Description("1y")]
		OneYear,
		[Description("2y")]
		TwoYears,
		[Description("5y")]
		FiveYears,
		[Description("max")]
		Max,
	}
}