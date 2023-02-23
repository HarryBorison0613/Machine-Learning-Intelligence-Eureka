using System;

namespace FinanceProcessor.IEXSharp.Model.CoreData.CorporateActions.Response
{
	public class RightToPurchaseResponse : CorporateActionResponse
	{
		public DateTime? subscriptionStart { get; set; }
		public DateTime? subscriptionEnd { get; set; }
		public double issuePrice { get; set; }
		public string resultSecurityType { get; set; }
		public bool? isOverSubscription { get; set; }
		public string currency { get; set; }
	}
}