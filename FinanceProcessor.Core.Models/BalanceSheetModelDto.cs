namespace FinanceProcessor.Core.Models
{
	public class BalanceSheetModelDto
	{
		public DateTime? ReportDate { get; set; }
		public DateTime? FiscalDate { get; set; }
		public int FiscalQuarter { get; set; }
		public int FiscalYear { get; set; }
		public string Currency { get; set; }
		public decimal? CurrentCash { get; set; }
		public decimal? ShortTermInvestments { get; set; }
		public decimal? Receivables { get; set; }
		public decimal? Inventory { get; set; }
		public decimal? OtherCurrentAssets { get; set; }
		public decimal? CurrentAssets { get; set; }
		public decimal? LongTermInvestments { get; set; }
		public decimal? PropertyPlantEquipment { get; set; }
		public decimal? Goodwill { get; set; }
		public decimal? IntangibleAssets { get; set; }
		public decimal? OtherAssets { get; set; }
		public decimal? TotalAssets { get; set; }
		public decimal? AccountsPayable { get; set; }
		public decimal? CurrentLongTermDebt { get; set; }
		public decimal? OtherCurrentLiabilities { get; set; }
		public decimal? TotalCurrentLiabilities { get; set; }
		public decimal? LongTermDebt { get; set; }
		public decimal? OtherLiabilities { get; set; }
		public decimal? MinorityInterest { get; set; }
		public decimal? TotalLiabilities { get; set; }
		public decimal? CommonStock { get; set; }
		public decimal? RetainedEarnings { get; set; }
		public decimal? TreasuryStock { get; set; }
		public decimal? CapitalSurplus { get; set; }
		public decimal? ShareholderEquity { get; set; }
		public decimal? NetTangibleAssets { get; set; }
		public string Id { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public long Date { get; set; }
		public decimal Updated { get; set; }
	}
}
