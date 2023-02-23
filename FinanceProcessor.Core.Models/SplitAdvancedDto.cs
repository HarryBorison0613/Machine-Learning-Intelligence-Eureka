namespace FinanceProcessor.Core.Models
{
	public class SplitAdvancedDto : CorporateActionDto
	{
		public string SplitType { get; set; }
		public double OldParValue { get; set; }
		public string OldParValueCurrency { get; set; }
	}
}
