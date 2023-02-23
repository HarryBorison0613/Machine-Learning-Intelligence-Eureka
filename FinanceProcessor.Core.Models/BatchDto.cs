namespace FinanceProcessor.Core.Models
{
	public class BatchDto
	{
		public AdvancedStatsDto AdvancedStats { get; set; }
		public BalanceSheetDto BalanceSheets { get; set; }
		public BookDto Book { get; set; }
		public CashFlowsDto CashFlows { get; set; }
		public List<ChartDto> Chart { get; set; }
		public CompanyDto Company { get; set; }
		public DelayedQuoteDto DelayedQuote { get; set; }
		public List<DividendBasicDto> DividendsBasic { get; set; }
		//public EarningDto Earnings { get; set; }

		//public List<EarningTodayDto> EarningsToday { get; set; }
		//public EstimatesDto Estimates { get; set; }
		public FinancialDto Financials { get; set; }
		public List<FundOwnershipDto> FundOwnership { get; set; }
		public IncomeStatementDto IncomeStatement { get; set; }
		public List<InsiderRosterDto> InsiderRoster { get; set; }
		public List<InsiderSummaryDto> InsiderSummary { get; set; }
		public List<InsiderTransactionDto> InsiderTransactions { get; set; }
		public List<InstitutionalOwnershipDto> InstitutionalOwnership { get; set; }
		public List<IntradayPriceDto> IntradayPrices { get; set; }
		public KeyStatsDto KeyStats { get; set; }
		public List<LargestTradeDto> LargestTrades { get; set; }
		public LogoDto Logo { get; set; }
		public List<NewsDto> News { get; set; }
		public OHLCDto Ohlc { get; set; }
		public List<string> OptionExpirationDates { get; set; }
		public List<string> Peers { get; set; }
		public HistoricalPriceDto PreviousDayPrice { get; set; }
		public decimal Price { get; set; }
		//public PriceTargetDto PriceTarget { get; set; }
		public QuoteDto Quote { get; set; }
		//public List<AnalystRecommendationsDto> RecommendationTrends { get; set; }
		public List<SplitBasicDto> SplitsBasic { get; set; }
		public List<VolumeByVenueDto> VolumeByVenue { get; set; }
	}
}
