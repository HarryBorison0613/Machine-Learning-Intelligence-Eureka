namespace FinanceProcessor.Core.Models
{
	public class KeyStatsDto
	{
		public string CompanyName { get; set; }
		public long? Marketcap { get; set; }
		public decimal? Week52high { get; set; }
		public decimal? Week52low { get; set; }
		public decimal? Week52change { get; set; }
		public long? SharesOutstanding { get; set; }
		public string Symbol { get; set; }
		public decimal? Avg10Volume { get; set; }
		public decimal? Avg30Volume { get; set; }
		public decimal? Day200MovingAvg { get; set; }
		public decimal? Day50MovingAvg { get; set; }
		public long? Employees { get; set; }
		public decimal? TtmEPS { get; set; }
		public decimal? TtmDividendRate { get; set; }
		public decimal? DividendYield { get; set; }
		public DateTime? NextDividendDate { get; set; }
		public DateTime? ExDividendDate { get; set; }
		public decimal? PeRatio { get; set; }
		public decimal? Beta { get; set; }
		public decimal? MaxChangePercent { get; set; }
		public decimal? Year5ChangePercent { get; set; }
		public decimal? Year2ChangePercent { get; set; }
		public decimal? Year1ChangePercent { get; set; }
		public decimal? YtdChangePercent { get; set; }
		public decimal? Month6ChangePercent { get; set; }
		public decimal? Month3ChangePercent { get; set; }
		public decimal? Month1ChangePercent { get; set; }
		public decimal? Day30ChangePercent { get; set; }
		public decimal? Day5ChangePercent { get; set; }
	}
}