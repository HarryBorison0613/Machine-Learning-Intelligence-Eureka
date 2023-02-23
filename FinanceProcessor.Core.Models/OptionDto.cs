namespace FinanceProcessor.Core.Models
{
	public class OptionDto
	{
		public string Symbol { get; set; }
		public string Id { get; set; }
		public string ExpirationDate { get; set; }
		public int ContractSize { get; set; }
		public decimal StrikePrice { get; set; }
		public decimal ClosingPrice { get; set; }
		public string Side { get; set; }
		public string Type { get; set; }
		public int Volume { get; set; }
		public int OpenInterest { get; set; }
		public decimal Bid { get; set; }
		public decimal Ask { get; set; }
		public DateTime LastUpdated { get; set; }
		public bool IsAdjusted { get; set; }
	}
}
