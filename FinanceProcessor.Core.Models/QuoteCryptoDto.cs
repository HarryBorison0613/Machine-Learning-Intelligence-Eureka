namespace FinanceProcessor.Core.Models
{
	public class QuoteCryptoDto
	{
		public string Symbol { get; set; }
		public string PrimaryExchange { get; set; }
		public string Sector { get; set; }
		public string CalculationPrice { get; set; }
		public decimal LatestPrice { get; set; }
		public string LtestSource { get; set; }
		public long LatestUpdate { get; set; }
		public decimal? LatestVolume { get; set; }
		public decimal? BidPrice { get; set; }
		public decimal? BidSize { get; set; }
		public decimal? AskPrice { get; set; }
		public decimal? AskSize { get; set; }
		public decimal? High { get; set; }
		public decimal? Low { get; set; }
		public decimal? PreviousClose { get; set; }

		public override string ToString() =>
			$"{LatestUpdate}:{Symbol},{LatestPrice},{LatestVolume}";
	}
}
