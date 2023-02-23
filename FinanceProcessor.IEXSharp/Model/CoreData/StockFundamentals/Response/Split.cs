using System;

namespace FinanceProcessor.IEXSharp.Model.CoreData.StockFundamentals.Response
{
	public class SplitLegacy
	{
		public DateTime exDate { get; set; }
		public DateTime declaredDate { get; set; }
		public DateTime recordDate { get; set; }
		public DateTime paymentDate { get; set; }
		public double ratio { get; set; }
		public int toFactor { get; set; }
		public int forFactor { get; set; }
	}

	public class Split
	{
		public string declaredDate { get; set; }
		public string description { get; set; }
		public string exDate { get; set; }
		public decimal? date { get; set; }
		public decimal fromFactor { get; set; }
		public decimal ratio { get; set; }
		public long refid { get; set; }
		public string symbol { get; set; }
		public decimal toFactor { get; set; }
		public string id { get; set; }
		public string key { get; set; }
		public string subkey { get; set; }
		public decimal? updated { get; set; }
	}
}