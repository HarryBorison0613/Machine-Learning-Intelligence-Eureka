namespace FinanceProcessor.Core.Models
{
	public class ChartDto
	{
		public DateTime Date { get; set; }
		public decimal Open { get; set; }
		public decimal Close { get; set; }
		public decimal High { get; set; }
		public decimal Low { get; set; }
		public long Volume { get; set; }
		public decimal UOpen { get; set; }
		public decimal UClose { get; set; }
		public decimal UHigh { get; set; }
		public decimal ULow { get; set; }
		public long UVolume { get; set; }
		public decimal Change { get; set; }
		public decimal ChangePercent { get; set; }
		public string Label { get; set; }
		public decimal ChangeOverTime { get; set; }
	}
}
