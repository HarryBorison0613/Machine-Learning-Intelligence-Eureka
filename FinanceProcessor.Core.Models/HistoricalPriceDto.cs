namespace FinanceProcessor.Core.Models
{
	public class HistoricalPriceDto
	{
		public string Date { get; set; }
		public string Minute { get; set; }
		public decimal? Close { get; set; }
		public decimal? High { get; set; }
		public decimal? Low { get; set; }
		public decimal? Open { get; set; }
		public decimal? Volume { get; set; }
		public string Id { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public decimal? Updated { get; set; }
		public decimal? ChangeOverTime { get; set; }
		public decimal? MarketChangeOverTime { get; set; }
		public decimal? UOpen { get; set; }
		public decimal? UClose { get; set; }
		public decimal? UHigh { get; set; }
		public decimal? ULow { get; set; }
		public decimal? UVolume { get; set; }
		public decimal? FOpen { get; set; }
		public decimal? FClose { get; set; }
		public decimal? FHigh { get; set; }
		public decimal? FLow { get; set; }
		public decimal? FVolume { get; set; }
		public string Label { get; set; }
		public decimal? Change { get; set; }
		public decimal? ChangePercent { get; set; }
	}
}
