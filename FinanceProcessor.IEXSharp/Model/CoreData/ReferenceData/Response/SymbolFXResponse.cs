using System.Collections.Generic;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Model.CoreData.ReferenceData.Response
{
	public class SymbolFXResponse
	{
		public List<Currency> currencies { get; set; }
		public List<Pair> pairs { get; set; }
	}
}