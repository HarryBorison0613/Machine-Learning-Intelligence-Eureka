namespace FinanceProcessor.IEXSharp.Model.Shared.Response
{
	public class Dividend
	{
		public string exDate { get; set; }
		public string paymentDate { get; set; }
		public string recordDate { get; set; }
		public string declaredDate { get; set; }
		public string date { get; set; }
		public string updated { get; set; }
		public decimal? amount { get; set; }
		public string id { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public decimal? refid { get; set; }
		public string flag { get; set; }
		public string currency { get; set; }
		public string description { get; set; }
		public string frequency { get; set; }
		public string symbol { get; set; }
	}
}