using System;

namespace FinanceProcessor.IEXSharp.Model.CoreData.CorporateActions.Response
{
	public class DividendAdvancedResponse : CorporateActionResponse
	{
		public DateTime? announceDate { get; set; }
		public string currency { get; set; }
		public string frequency { get; set; }
		public decimal? amount { get; set; }
		public decimal? netAmount { get; set; }
		public decimal? grossAmount { get; set; }
		public string marker { get; set; }
		public decimal taxRate { get; set; }
		public decimal adrFee { get; set; }
		public int coupon { get; set; }
		public string declaredCurrencyCD { get; set; }
		public decimal declaredGrossAmount { get; set; }
		public int? isCapitalGains { get; set; }
		public bool? isNetInvestmentIncome { get; set; }
		public int? isDAP { get; set; }
		public bool? isApproximate { get; set; }
		public DateTime? fxDate { get; set; }
		public DateTime? secondPaymentDate { get; set; }
		public DateTime? secondExDate { get; set; }
		public DateTime? fiscalYearEndDate { get; set; }
		public DateTime? periodEndDate { get; set; }
		public DateTime? optionalElectionDate { get; set; }
		public DateTime? toDate { get; set; }
		public DateTime? registrationDate { get; set; }
		public DateTime? installmentPayDate { get; set; }
		public DateTime? declaredDate { get; set; }
	}
}
