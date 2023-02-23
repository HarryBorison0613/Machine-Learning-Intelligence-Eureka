using System.Collections.Generic;
using FinanceProcessor.IEXSharp.Model.CoreData.InvestorsExchangeData.Response;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Response
{
	public class BookResponse : DeepBookResponse
	{
		public Quote quote { get; set; }
		public List<Trade> trades { get; set; }
		public SystemEvent systemEvent { get; set; }
	}
}