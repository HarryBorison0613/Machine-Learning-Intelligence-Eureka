namespace FinanceProcessor.Core.Models
{
	public class IncomeModelDto
	{
		public DateTime? ReportDate { get; set; }
		public DateTime? FiscalDate { get; set; }
		public int FiscalQuarter { get; set; }
		public int FiscalYear { get; set; }
		public string Currency { get; set; }
		public decimal? TotalRevenue { get; set; }
		public decimal? CostOfRevenue { get; set; }
		public decimal? GrossProfit { get; set; }
		public decimal? ResearchAndDevelopment { get; set; }
		public decimal? SellingGeneralAndAdmin { get; set; }
		public decimal? OperatingExpense { get; set; }
		public decimal? OperatingIncome { get; set; }
		public decimal? OtherIncomeExpenseNet { get; set; }
		public decimal? Ebit { get; set; }
		public decimal? InterestIncome { get; set; }
		public decimal? PretaxIncome { get; set; }
		public decimal? IncomeTax { get; set; }
		public decimal? MinorityInterest { get; set; }
		public decimal? NetIncome { get; set; }
		public decimal? NetIncomeBasic { get; set; }
	}
}
