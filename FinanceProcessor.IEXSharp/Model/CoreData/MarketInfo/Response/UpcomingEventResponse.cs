using System.Collections.Generic;
using FinanceProcessor.IEXSharp.Model.CoreData.Stock.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.StockFundamentals.Response;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Model.CoreData.MarketInfo.Response
{
	public class UpcomingEventSymbolResponse
	{
		public List<Estimate> earnings { get; set; }
		public List<Dividend> dividends { get; set; }
		public List<Split> splits { get; set; }
	}

	public class UpcomingEventMarketResponse
	{
		public List<IPOCalendarResponse> ipos { get; set; }
		public List<UpcomingEarningEvent> earnings { get; set; }
		public List<Dividend> dividends { get; set; }
		public List<Split> splits { get; set; }
	}
}