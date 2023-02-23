using System.Collections.Generic;

namespace FinanceProcessor.IEXSharp.Model.CoreData.StockResearch.Response
{
	public class RelevantStocksResponse
	{
		public bool peers { get; set; }
		public List<string> symbols { get; set; }
	}
}