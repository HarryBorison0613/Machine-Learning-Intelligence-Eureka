namespace FinanceProcessor.Core.Models
{
	public class DividendAdvancedDto : CorporateActionDto
	{
		public DateTime? AnnounceDate { get; set; }
		public string Currency { get; set; }
		public string Frequency { get; set; }
		public decimal? Amount { get; set; }
		public decimal? NetAmount { get; set; }
		public decimal? GrossAmount { get; set; }
		public string Marker { get; set; }
		public decimal TaxRate { get; set; }
		public decimal AdrFee { get; set; }
		public int Coupon { get; set; }
		public string DeclaredCurrencyCD { get; set; }
		public decimal DeclaredGrossAmount { get; set; }
		public int? IsCapitalGains { get; set; }
		public bool? IsNetInvestmentIncome { get; set; }
		public int? IsDAP { get; set; }
		public bool? IsApproximate { get; set; }
		public DateTime? FxDate { get; set; }
		public DateTime? SecondPaymentDate { get; set; }
		public DateTime? SecondExDate { get; set; }
		public DateTime? FiscalYearEndDate { get; set; }
		public DateTime? PeriodEndDate { get; set; }
		public DateTime? OptionalElectionDate { get; set; }
		public DateTime? ToDate { get; set; }
		public DateTime? RegistrationDate { get; set; }
		public DateTime? InstallmentPayDate { get; set; }
		public DateTime? DeclaredDate { get; set; }
	}
}
