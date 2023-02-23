namespace FinanceProcessor.Core.Models
{
	public class PriceTargetDto
	{
		public string Symbol { get; set; }
		public DateTime UpdatedDate { get; set; }
		public decimal PriceTargetAverage { get; set; }
		public decimal PriceTargetHigh { get; set; }
		public decimal PriceTargetLow { get; set; }
		public int NumberOfAnalysts { get; set; }
		public string Currency { get; set; }
	}
}