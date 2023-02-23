using System;

namespace FinanceProcessor.IEXSharp.Model.CoreData.ReferenceData.Response
{
	public class HolidaysAndTradingDatesUSResponse
	{
		public DateTime date { get; set; }
		public DateTime settlementDate { get; set; }
	}
}