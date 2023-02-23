namespace FinanceProcessor.Core.Models
{
	public class SpinOffDto : CorporateActionDto
	{
		public DateTime? WithdrawalFromDate { get; set; }
		public DateTime? WithdrawalToDate { get; set; }
		public DateTime? ElectionDate { get; set; }
		public DateTime? EffectiveDate { get; set; }
		public double MinPrice { get; set; }
		public double MaxPrice { get; set; }
		public int HasWithdrawalRights { get; set; }
		public string Currency { get; set; }
	}
}
