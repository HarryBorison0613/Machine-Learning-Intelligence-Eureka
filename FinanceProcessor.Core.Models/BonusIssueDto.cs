namespace FinanceProcessor.Core.Models
{
	public class BonusIssueDto : CorporateActionDto
	{
		public string ResultSecurityType { get; set; }
		public string Currency { get; set; }
		public decimal LapsedPremium { get; set; }
	}
}
