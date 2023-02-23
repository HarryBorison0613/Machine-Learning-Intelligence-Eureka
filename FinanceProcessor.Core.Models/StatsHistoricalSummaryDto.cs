namespace FinanceProcessor.Core.Models
{
	public class StatsHistoricalSummaryDto
	{
		public decimal AverageDailyVolume { get; set; }
		public decimal AverageDailyRoutedVolume { get; set; }
		public decimal AverageMarketShare { get; set; }
		public int AverageOrderSize { get; set; }
		public int AverageFillSize { get; set; }
		public decimal Bin100Percent { get; set; }
		public decimal Bin101Percent { get; set; }
		public decimal Bin200Percent { get; set; }
		public decimal Bin300Percent { get; set; }
		public decimal Bin400Percent { get; set; }
		public decimal Bin500Percent { get; set; }
		public decimal Bin1000Percent { get; set; }
		public decimal Bin5000Percent { get; set; }
		public decimal Bin10000Percent { get; set; }
		public int Bin10000Trades { get; set; }
		public int Bin20000Trades { get; set; }
		public int Bin50000Trades { get; set; }
		public int UniqueSymBolsTraded { get; set; }
		public decimal BlockPercent { get; set; }
		public decimal SelfCrossPercent { get; set; }
		public decimal EtfPercent { get; set; }
		public decimal LargeCapPercent { get; set; }
		public decimal MidCapPercent { get; set; }
		public decimal SmallCapPercent { get; set; }
		public decimal VenueARCXFirstWaveWeight { get; set; }
		public decimal VenueBATSFirstWaveWeight { get; set; }
		public decimal VenueBATYFirstWaveWeight { get; set; }
		public decimal VenueEDGAFirstWaveWeight { get; set; }
		public decimal VenueEDGXFirstWaveWeight { get; set; }
		public decimal VenueOverAllFirstWaveWeight { get; set; }
		public decimal VenueXASEFirstWaveWeight { get; set; }
		public decimal VenueXBOSFirstWaveWeight { get; set; }
		public decimal VenueXCHIFirstWaveWeight { get; set; }
		public decimal VenueXCISFirstWaveWeight { get; set; }
		public decimal VenueXNGSFirstWaveWeight { get; set; }
		public decimal VenueXNYSFirstWaveWeight { get; set; }
		public decimal VenueXPHLFirstWaveWeight { get; set; }
		public decimal VenueARCXFirstWaveRate { get; set; }
		public decimal VenueBATSFirstWaveRate { get; set; }
		public decimal VenueBATYFirstWaveRate { get; set; }
		public decimal VenueEDGAFirstWaveRate { get; set; }
		public decimal VenueEDGXFirstWaveRate { get; set; }
		public decimal VenueOverAllFirstWaveRate { get; set; }
		public decimal VenueXASEFirstWaveRate { get; set; }
		public decimal VenueXBOSFirstWaveRate { get; set; }
		public decimal VenueXCHIFirstWaveRate { get; set; }
		public decimal VenueXCISFirstWaveRate { get; set; }
		public decimal VenueXNGSFirstWaveRate { get; set; }
		public decimal VenueXNYSFirstWaveRate { get; set; }
		public decimal VenueXPHLFirstWaveRate { get; set; }
	}
}
