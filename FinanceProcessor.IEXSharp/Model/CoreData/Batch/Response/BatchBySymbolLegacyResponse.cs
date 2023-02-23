using System.Collections.Generic;
using FinanceProcessor.IEXSharp.Model.CoreData.News.Response;

namespace FinanceProcessor.IEXSharp.Model.CoreData.Batch.Response
{
	public class BatchBySymbolLegacyResponse : BatchResponse
	{
		public List<NewsLegacy> news { get; set; }
	}
}