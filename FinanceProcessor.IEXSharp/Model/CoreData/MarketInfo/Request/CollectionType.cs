using System.ComponentModel;

namespace FinanceProcessor.IEXSharp.Model.CoreData.MarketInfo.Request
{
	public enum CollectionType
	{
		[Description("sector")]
		Sector,
		[Description("tag")]
		Tag,
		[Description("list")]
		List
	}
}