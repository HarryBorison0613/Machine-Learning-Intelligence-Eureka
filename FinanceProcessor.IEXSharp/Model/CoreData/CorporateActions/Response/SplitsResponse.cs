namespace FinanceProcessor.IEXSharp.Model.CoreData.CorporateActions.Response
{
	public class SplitAdvancedResponse : CorporateActionResponse
	{
		public string splitType { get; set; }
		public double oldParValue { get; set; }
		public string oldParValueCurrency { get; set; }
	}
}