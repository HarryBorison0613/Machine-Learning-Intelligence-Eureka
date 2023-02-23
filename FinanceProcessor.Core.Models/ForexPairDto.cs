namespace FinanceProcessor.Core.Models
{
	public class ForexPairDto
	{
		public string Symbol { get; set; }
		public string FromCurrency { get; set; }
		public string ToCurrency { get; set; }
		public string Name { get; set; }
		public int IsCrypto { get; set; }
	}
}
