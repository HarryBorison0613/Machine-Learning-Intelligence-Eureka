namespace FinanceProcessor.Core.Models
{
	public class TradeDto
	{
		public decimal Price { get; set; }
		public int Size { get; set; }
		public long TradeId { get; set; }
		public bool IsISO { get; set; }
		public bool IsOddLot { get; set; }
		public bool IsOutsideRegularHours { get; set; }
		public bool IsSinglePriceCross { get; set; }
		public bool IsTradeThroughExempt { get; set; }
		public long Timestamp { get; set; }
	}
}
