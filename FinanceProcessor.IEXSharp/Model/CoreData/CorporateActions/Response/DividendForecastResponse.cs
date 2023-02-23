using System;

namespace FinanceProcessor.IEXSharp.Model.CoreData.CorporateActions.Response
{
	public class DividendForecastResponse
	{
		public decimal? adjustedAmount { get; set; }
		public decimal? amount { get; set; }
		public string currency { get; set; }
		public DateTime? declaredDate { get; set; }
		public decimal? disbursementAmount { get; set; }
		public string disbursementType { get; set; }
		public DateTime? exDate { get; set; }
		public string fiscalYear { get; set; }
		public DateTime? fiscalYearEndDate { get; set; }
		public string frequency { get; set; }
		public DateTime? fxDate { get; set; }
		public DateTime? lastChange { get; set; }
		public string marker { get; set; }
		public string name { get; set; }
		public decimal? nonTaxedAmount { get; set; }
		public DateTime? paymentDate { get; set; }
		public DateTime? priodEndDate { get; set; }
		public int? position { get; set; }
		public DateTime? recordDate { get; set; }
		public DateTime? recordUpdated { get; set; }
		public decimal? sharesHeld { get; set; }
		public decimal? sharesReceived { get; set; }
		public string status { get; set; }
		public string symbol { get; set; }
		public string id { get; set; }
		public string key { get; set; }
		public string subKey { get; set; }
		public decimal? netAmount { get; set; }
		public decimal? date { get; set; }
		public decimal? updated { get; set; }
	}
}
