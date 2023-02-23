using System.ComponentModel;

namespace FinanceProcessor.IEXSharp.Model.CoreData.ReferenceData.Request
{
	public enum DirectionType
	{
		[Description("next")]
		Next,
		[Description("last")]
		Last
	}
}