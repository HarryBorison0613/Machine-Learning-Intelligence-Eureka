using System.Collections.Generic;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Model.CoreData.StockFundamentals.Response
{
	public class EarningResponse
	{
		public string symbol { get; set; }
		public List<Earning> earnings { get; set; }
	}
}