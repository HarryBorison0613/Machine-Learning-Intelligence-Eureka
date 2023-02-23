namespace FinanceProcessor.Core.Models
{
	public class LastDto
	{
		public string Symbol { get; set; }
		public decimal Price { get; set; }
		public int Size { get; set; }
		public long Time { get; set; }
	}
}
