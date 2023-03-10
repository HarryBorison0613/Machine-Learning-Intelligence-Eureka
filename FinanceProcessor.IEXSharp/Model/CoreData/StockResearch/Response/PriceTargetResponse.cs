using System;

namespace FinanceProcessor.IEXSharp.Model.CoreData.StockResearch.Response
{
	public class PriceTargetResponse
	{
		public string symbol { get; set; }
		public DateTime updatedDate { get; set; }
		public decimal priceTargetAverage { get; set; }
		public decimal priceTargetHigh { get; set; }
		public decimal priceTargetLow { get; set; }
		public int numberOfAnalysts { get; set; }
		public string currency { get; set; }
	}
}