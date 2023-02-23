using System.ComponentModel;

namespace FinanceProcessor.IEXSharp.Model.Shared.Request
{
	public enum Period
	{
		[Description("quarter")]
		Quarter,
		[Description("annual")]
		Annual
	}
}
