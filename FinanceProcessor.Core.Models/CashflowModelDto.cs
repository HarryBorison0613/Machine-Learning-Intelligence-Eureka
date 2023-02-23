namespace FinanceProcessor.Core.Models
{
	public class CashflowModelDto
    {
        public DateTime ReportDate { get; set; }
        public DateTime FiscalDate { get; set; }
        public string Currency { get; set; }
        public decimal? NetIncome { get; set; }
        public decimal? Depreciation { get; set; }
        public decimal? ChangesInReceivables { get; set; }
        public decimal? ChangesInInventories { get; set; }
        public decimal? CashChange { get; set; }
        public decimal? CashFlow { get; set; }
        public decimal? CapitalExpenditures { get; set; }
        public decimal? Investments { get; set; }
        public decimal? InvestingActivityOther { get; set; }
        public decimal? TotalInvestingCashFlows { get; set; }
        public decimal? DividendsPaid { get; set; }
        public decimal? NetBorrowings { get; set; }
        public decimal? OtherFinancingCashFlows { get; set; }
        public decimal? CashFlowFinancing { get; set; }
        public decimal? ExchangeRateEffect { get; set; }
        public string Id { get; set; }
        public string Key { get; set; }
        public string Subkey { get; set; }
        public string Symbol { get; set; }
        public string FilingType { get; set; }
        public int FiscalQuarter { get; set; }
        public int FiscalYear { get; set; }
        public decimal Updated { get; set; }
    }
}
