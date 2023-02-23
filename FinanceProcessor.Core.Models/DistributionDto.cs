namespace FinanceProcessor.Core.Models
{
	public class DistributionDto : CorporateActionDto
	{
		public DateTime? WithdrawalFromDate { get; set; }
		public DateTime? WithdrawalToDate { get; set; }
		public DateTime? ElectionDate { get; set; }
		public decimal MinPrice { get; set; }
		public decimal MaxPrice { get; set; }
		public int HasWithdrawalRights { get; set; }
	}
}
