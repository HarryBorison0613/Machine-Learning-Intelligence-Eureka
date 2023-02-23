namespace FinanceProcessor.Core.Models
{
	public class SectorPerformanceDto
	{
		public string Type { get; set; }
		public string Name { get; set; }
		public decimal? Performance { get; set; }
		public long LastUpdated { get; set; }
	}
}
