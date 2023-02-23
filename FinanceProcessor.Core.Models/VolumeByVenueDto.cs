namespace FinanceProcessor.Core.Models
{
	public class VolumeByVenueDto
	{
		public long Volume { get; set; }
		public string Venue { get; set; }
		public string VenueName { get; set; }
		public decimal MarketPercent { get; set; }
		public decimal AvgMarketPercent { get; set; }
		public DateTime? Date { get; set; }
	}
}
