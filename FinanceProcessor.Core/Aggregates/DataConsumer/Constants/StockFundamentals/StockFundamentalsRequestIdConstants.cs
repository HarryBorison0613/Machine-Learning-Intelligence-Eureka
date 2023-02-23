namespace FinanceProcessor.Core.Aggregates.DataConsumer.Constants.StockFundamentals
{
	public sealed class StockFundamentalsRequestIdConstants
	{
		public const string GetAdvancedFundamentals = "time-series/fundamentals/symbol/period";
		public const string GetFundamentalValuations = "time-series/FUNDAMENTAL_VALUATIONS/symbol/period";
		public const string GetBalanceSheet = "stock/symbol/balance-sheet/last";
		public const string GetBalanceSheetField = "stock/symbol/balance-sheet/last/field";
		public const string GetCashFlow = "stock/symbol/cash-flow/last";
		public const string GetCashFlowField = "stock/symbol/cash-flow/last/field";
		public const string GetDividendsBasic = "stock/symbol/dividends/range";
		public const string GetEarning = "stock/symbol/earnings/last";
		public const string GetEarningField = "stock/symbol/earnings/last/field";
		public const string GetFinancial = "stock/symbol/financials/last";
		public const string GetFinancialField = "stock/symbol/financials/last/field";
		public const string GetIncomeStatement = "stock/symbol/income/last";
		public const string GetIncomeStatementField = "stock/symbol/income/last/field";
		public const string GetReportedFinancials = "time-series/reported_financials/symbol/filing";
		public const string GetSplitsBasic = "stock/symbol/splits/range";
	}
}