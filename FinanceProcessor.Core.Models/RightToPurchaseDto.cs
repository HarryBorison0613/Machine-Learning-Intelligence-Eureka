namespace FinanceProcessor.Core.Models
{
	public class RightToPurchaseDto : CorporateActionDto
	{
		public DateTime? SubscriptionStart { get; set; }
		public DateTime? SubscriptionEnd { get; set; }
		public double IssuePrice { get; set; }
		public string ResultSecurityType { get; set; }
		public bool? IsOverSubscription { get; set; }
		public string Currency { get; set; }
	}
}
