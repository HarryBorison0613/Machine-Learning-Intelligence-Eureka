using System.ComponentModel;

namespace FinanceProcessor.IEXSharp.Model.Shared.Request
{
	public enum TimeSeriesPeriod
	{
		[Description("quarterly")]
		Quarterly,
		[Description("annual")]
		Annual,
		[Description("ttm")]
		Ttm
	}
}