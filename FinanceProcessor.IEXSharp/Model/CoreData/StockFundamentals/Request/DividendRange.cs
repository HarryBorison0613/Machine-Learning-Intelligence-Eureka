using System.ComponentModel;

namespace FinanceProcessor.IEXSharp.Model.CoreData.StockFundamentals.Request
{
	public enum DividendRange
	{
		[Description("next")]
		Next,
		[Description("ytd")]
		Ytd,
		[Description("1m")]
		OneMonth,
		[Description("3m")]
		ThreeMonths,
		[Description("6m")]
		SixMonths,
		[Description("1y")]
		OneYear,
		[Description("2y")]
		TwoYears,
		[Description("5y")]
		FiveYears,
	}
}