using System.Collections.Generic;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Model.CoreData.InvestorsExchangeData.Response
{
	public class DeepBookResponse
	{
		public List<Bid> bids { get; set; }
		public List<Ask> asks { get; set; }
	}
}