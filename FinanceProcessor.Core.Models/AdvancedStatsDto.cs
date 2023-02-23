namespace FinanceProcessor.Core.Models
{
	public class AdvancedStatsDto : KeyStatsDto
	{
		public long? TotalCash { get; set; }
		public long? CurrentDebt { get; set; }
		public long? Revenue { get; set; }
		public long? GrossProfit { get; set; }
		public long? TotalRevenue { get; set; }
		public long? Ebitda { get; set; }
		public decimal? RevenuePerShare { get; set; }
		public decimal? RevenuePerEmployee { get; set; }
		public decimal? DebtToEquity { get; set; }
		public decimal? ProfitMargin { get; set; }
		public decimal? EnterpriseValue { get; set; }
		public decimal? EnterpriseValueToRevenue { get; set; }
		public decimal? PriceToSales { get; set; }
		public decimal? PriceToBook { get; set; }
		public decimal? ForwardPERatio { get; set; }
		public decimal? PegRatio { get; set; }
		public decimal? PeHigh { get; set; }
		public decimal? PeLow { get; set; }
		public DateTime? Week52highDate { get; set; }
		public DateTime? Week52lowDate { get; set; }
		public decimal? PutCallRatio { get; set; }
	}
}