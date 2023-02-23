using System;

namespace FinanceProcessor.IEXSharp.Model.CoreData.ReferenceData.Response
{
	public class SymbolIEXResponse
	{
		public string symbol { get; set; }
		public DateTime date { get; set; }
		public bool isEnabled { get; set; }
	}
}