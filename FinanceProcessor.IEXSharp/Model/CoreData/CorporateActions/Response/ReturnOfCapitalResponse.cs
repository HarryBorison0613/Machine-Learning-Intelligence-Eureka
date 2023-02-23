using System;

namespace FinanceProcessor.IEXSharp.Model.CoreData.CorporateActions.Response
{
	public class ReturnOfCapitalResponse : CorporateActionResponse
	{
		public DateTime? withdrawalFromDate { get; set; }
		public DateTime? withdrawalToDate { get; set; }
		public DateTime? electionDate { get; set; }
		public decimal cashBack { get; set; }
		public decimal? hasWithdrawalRights { get; set; }
		public string currency { get; set; }
  }
}