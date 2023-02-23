using System.Collections.Generic;
using FinanceProcessor.IEXSharp.Model.CoreData.Stock.Response;

namespace FinanceProcessor.IEXSharp.Model.CoreData.StockResearch.Response
{
	public class EstimatesResponse
	{
		public string symbol { get; set; }
		public List<Estimate> estimates { get; set; }
	}
}