using System.ComponentModel;

namespace FinanceProcessor.IEXSharp.Model.CoreData.ReferenceData.Request
{
	public enum DateType
	{
		[Description("trade")]
		Trade,
		[Description("holiday")]
		Holiday
	}
}