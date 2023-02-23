using System.Collections.Generic;

namespace FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Response
{
	public class HistoricalPriceDynamicResponse
	{
		public string range { get; set; }
		public List<IntradayPriceResponse> data { get; set; }
	}
}