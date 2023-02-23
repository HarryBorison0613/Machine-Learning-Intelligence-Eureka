namespace FinanceProcessor.Core.Models
{
	public class SplitDto
	{
		public DateTime? DeclaredDate { get; set; }
		public string Description { get; set; }
		public DateTime? ExDate { get; set; }
		public decimal? Date { get; set; }
		public decimal FromFactor { get; set; }
		public decimal Ratio { get; set; }
		public long Refid { get; set; }
		public string Symbol { get; set; }
		public decimal ToFactor { get; set; }
		public string Id { get; set; }
		public string Key { get; set; }
		public string Subkey { get; set; }
		public decimal? Updated { get; set; }
	}
}
