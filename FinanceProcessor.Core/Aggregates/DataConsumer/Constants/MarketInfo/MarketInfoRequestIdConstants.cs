namespace FinanceProcessor.Core.Aggregates.DataConsumer.Constants.MarketInfo
{
	public static class MarketInfoRequestIdConstants
	{
		public const string GetCollectionsList = "stock/market/collection/list";
		public const string GetCollectionsTag = "stock/market/collection/tag";
		public const string GetCollectionsSector = "stock/market/collection/sector";

		public const string GetListMostactive = "stock/market/list/mostactive";
		public const string GetListGainers = "stock/market/list/gainers";
		public const string GetListLosers = "stock/market/list/losers";
		public const string GetListIexvolume = "stock/market/list/iexvolume";
		public const string GetListIexPercent = "stock/market/list/iexPercent";

		public const string GetUpcomingDividends = "stock/symbol/upcoming-dividends";
		public const string GetUpcomingEarnings = "stock/symbol/upcoming-earnings";
		public const string GetUpcomingSplits = "stock/symbol/upcoming-splits";
		public const string GetUpcomingIpos = "stock/symbol/upcoming-ipos";
		public const string GetUpcomingEvents = "stock/symbol/upcoming-events";

		public const string GetUpcomingEventMarket = "stock/market/upcoming-events";
		public const string GetUpcomingDividendsMarket = "stock/market/upcoming-dividends";
		public const string GetUpcomingSplitsMarket = "stock/market/upcoming-splits";
		public const string GetUpcomingEarningsMarket = "stock/market/upcoming-earnings";
		public const string GetUpcomingIPOsMarket = "stock/market/upcoming-ipos";

		public const string GetMarketVolumeUS = "stock/market/volume";
		public const string GetMarket = "market";

		public const string GetSectorPerformance = "stock/market/sector-performance";

		public const string GetIPOCalendarUpcomingIpos = "stock/market/upcoming-ipos";
		public const string GetIPOCalendarTodayIpos = "stock/market/today-ipos";

		public const string GetEarningsToday = "stock/market/today-earnings";
	}
}
