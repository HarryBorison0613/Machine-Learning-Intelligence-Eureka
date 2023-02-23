namespace FinanceProcessor.IEXSharp.Model.CoreData.ForexCurrencies.Response
{
	public class CurrencyRateResponse
	{
		public string symbol { get; set; }
		public decimal? rate { get; set; }
		public long? timestamp { get; set; }
		public bool? isDerived { get; set; }
	}
}