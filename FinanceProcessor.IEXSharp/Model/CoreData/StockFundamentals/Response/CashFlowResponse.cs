using System.Collections.Generic;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Model.CoreData.StockFundamentals.Response
{
	public class CashFlowsResponse
	{
		public string symbol { get; set; }
		public List<Cashflow> cashflow { get; set; }
		public string id { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public long date { get; set; }
		public decimal updated { get; set; }
	}
}