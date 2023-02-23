namespace FinanceProcessor.Core.Models
{
	public class DeepAuctionDto
	{
		public string Symbol { get; set; }
		public string AuctionType { get; set; }
		public int PairedShares { get; set; }
		public int ImbalanceShares { get; set; }
		public decimal ReferencePrice { get; set; }
		public decimal IndicativePrice { get; set; }
		public decimal AuctionBookPrice { get; set; }
		public decimal CollarReferencePrice { get; set; }
		public decimal LowerCollarPrice { get; set; }
		public decimal UpperCollarPrice { get; set; }
		public int ExtensionNumber { get; set; }
		public string StartTime { get; set; }
		public long LastUpdate { get; set; }
	}
}
