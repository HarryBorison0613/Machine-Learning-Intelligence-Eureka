namespace FinanceProcessor.Core.Models
{
	public class ReturnOfCapitalDto : CorporateActionDto
	{
		public DateTime? WithdrawalFromDate { get; set; }
		public DateTime? WithdrawalToDate { get; set; }
		public DateTime? ElectionDate { get; set; }
		public decimal CashBack { get; set; }
		public decimal? HasWithdrawalRights { get; set; }
		public string Currency { get; set; }
	}
}
