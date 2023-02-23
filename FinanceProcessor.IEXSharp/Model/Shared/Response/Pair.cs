namespace FinanceProcessor.IEXSharp.Model.Shared.Response
{
	public class Pair
	{
		public string fromCurrency { get; set; }
		public string toCurrency { get; set; }
		public string symbol { get; set; }
		public string name { get; set; }
		public int isCrypto { get; set; }
	}
}