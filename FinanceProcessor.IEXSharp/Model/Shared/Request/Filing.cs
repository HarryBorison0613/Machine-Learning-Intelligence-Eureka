using System.ComponentModel;

namespace FinanceProcessor.IEXSharp.Model.Shared.Request
{
	public enum Filing
	{
		[Description("10-K")]
		Annual,
		[Description("10-Q")]
		Quarterly
	}
}