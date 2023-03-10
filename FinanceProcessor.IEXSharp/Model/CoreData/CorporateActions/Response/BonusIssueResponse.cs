
namespace FinanceProcessor.IEXSharp.Model.CoreData.CorporateActions.Response
{
	public class BonusIssueResponse : CorporateActionResponse
	{
		public string resultSecurityType { get; set; }
		public string currency { get; set; }
		public decimal lapsedPremium { get; set; }
	}
}