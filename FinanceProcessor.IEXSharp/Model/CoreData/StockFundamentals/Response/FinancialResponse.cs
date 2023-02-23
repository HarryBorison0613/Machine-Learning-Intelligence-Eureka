using System.Collections.Generic;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Model.CoreData.StockFundamentals.Response
{
	public class FinancialResponse
	{
		public string symbol { get; set; }
		public List<Financial> financials { get; set; }
	}
}