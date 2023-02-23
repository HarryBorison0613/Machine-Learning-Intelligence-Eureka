namespace FinanceProcessor.Core.Aggregates.DataConsumer.Constants.StockResearch
{
	public static class StockResearchRequestIdConstants
	{
		public const string GetAdvancedStats = "stock/symbol/advanced-stats";
		public const string GetAnalystRecommendations = "stock/symbol/recommendation-trends";
		public const string GetEstimates = "stock/symbol/estimates/last";
		public const string GetEstimateField = "stock/symbol/estimates/last/field";
		public const string GetFundOwnership = "stock/symbol/fund-ownership";
		public const string GetInstitutionalOwnerShip = "stock/symbol/institutional-ownership";
		public const string GetKeyStats = "stock/symbol/stats";
		public const string GetKeyStatsStat = "stock/symbol/stats/stat";
		public const string GetPriceTarget = "stock/symbol/price-target";
		public const string GetTechnicalIndicators = "stock/symbol/indicator/indicator";
		public const string GetRelevantStocks = "stock/symbol/relevant";
	}
}