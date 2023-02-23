using System.ComponentModel;

namespace FinanceProcessor.IEXSharp.Model.CoreData.Options.Request
{
	public enum OptionSide
	{
		[Description("put")]
		Put,
		[Description("call")]
		Call
	}
}
