using System.ComponentModel;

namespace FinanceProcessor.IEXSharp.Model.CoreData.Batch.Request
{
	public enum BatchType
	{
		[Description("advanced-stats")]
		AdvancedStats,

		[Description("balance-sheet")]
		BalanceSheets,

		[Description("book")]
		Book,

		[Description("cash-flow")]
		CashFlows,

		[Description("chart")]
		Chart,

		[Description("company")]
		Company,

		[Description("delayed-quote")]
		DelayedQuote,

		/// <summary> only DividendsBasic is available in batches (not DividendsAdvanced) </summary>
		[Description("dividends")]
		DividendsBasic,

		// ToDo: needs permission

		//[Description("earnings")]
		//Earnings,

		//[Description("today-earnings")]
		//EarningsToday,

		//[Description("estimates")]
		//Estimates,

		//[Description("price-target")]
		//PriceTarget,

		//[Description("recommendation-trends")]
		//RecommendationTrends,

		[Description("financials")]
		Financials,

		[Description("fund-ownership")]
		FundOwnership,

		[Description("income")]
		IncomeStatement,

		[Description("insider-roster")]
		InsiderRoster,

		[Description("insider-summary")]
		InsiderSummary,

		[Description("insider-transactions")]
		InsiderTransactions,

		[Description("institutional-ownership")]
		InstitutionalOwnership,

		[Description("intraday-prices")]
		IntradayPrices,

		[Description("stats")]
		KeyStats,

		[Description("largest-trades")]
		LargestTrades,

		[Description("logo")]
		Logo,

		[Description("news")]
		News,

		[Description("ohlc")]
		Ohlc,

		[Description("options")]
		Options,

		[Description("peers")]
		Peers,

		[Description("previous")]
		PreviousDayPrice,

		[Description("price")]
		Price,

		[Description("quote")]
		Quote,

		/// <summary> only SplitsBasic is available in batches (not SplitsAdvanced) </summary>
		[Description("splits")]
		SplitsBasic,

		[Description("volume-by-venue")]
		VolumeByVenue,
	}
}