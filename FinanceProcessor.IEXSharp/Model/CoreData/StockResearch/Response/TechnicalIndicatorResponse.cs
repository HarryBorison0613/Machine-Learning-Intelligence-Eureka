using System.Collections.Generic;

namespace FinanceProcessor.IEXSharp.Model.CoreData.StockResearch.Response
{
	public class TechnicalIndicatorsResponse
	{
		public IEnumerable<string> indicator { get; set; }
		public IEnumerable<Dictionary<string, string>> chart { get; set; }
	}
}