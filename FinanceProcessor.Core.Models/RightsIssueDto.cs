namespace FinanceProcessor.Core.Models
{
	public class RightsIssueDto : CorporateActionDto
	{
		public DateTime? SubscriptionStartDate { get; set; }
		public DateTime? SubscriptionEndDate { get; set; }
		public DateTime? TradeStartDate { get; set; }
		public DateTime? TradeEndDate { get; set; }
		public DateTime? SplitDate { get; set; }
		public string ResultSecurityType { get; set; }
		public string Currency { get; set; }
		public decimal IssuePrice { get; set; }
		public decimal LapsedPremium { get; set; }
		public bool? IsOverSubscription { get; set; }
	}
}
