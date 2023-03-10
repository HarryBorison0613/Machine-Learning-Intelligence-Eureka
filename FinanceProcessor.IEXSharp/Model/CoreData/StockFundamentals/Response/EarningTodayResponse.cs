using System;
using System.Collections.Generic;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Model.CoreData.StockFundamentals.Response
{
	public class EarningTodayResponse
	{
		public List<Earning> bto { get; set; }
		public List<Earning> amc { get; set; }
		public List<Other> other { get; set; }

		public class Earning
		{
			public decimal actualEPS { get; set; }
			public decimal consensusEPS { get; set; }
			public decimal estimatedEPS { get; set; }
			public string announceTime { get; set; }
			public long numberOfEstimates { get; set; }
			public decimal EPSSurpriseDollar { get; set; }
			public DateTime EPSReportDate { get; set; }
			public string fiscalPeriod { get; set; }
			public DateTime fiscalEndDate { get; set; }
			public decimal yearAgo { get; set; }
			public decimal yearAgoChangePercent { get; set; }
			public decimal estimatedChangePercent { get; set; }
			public int symbolId { get; set; }
			public string symbol { get; set; }
			public DateTime reportDate { get; set; }
			public string currency { get; set; }
			public Quote quote { get; set; }
			public string headline { get; set; }
		}
		public class Other
		{
			public decimal? consensusEPS { get; set; }
			public string announceTime { get; set; }
			public long numberOfEstimates { get; set; }
			public string fiscalPeriod { get; set; }
			public DateTime fiscalEndDate { get; set; }
			public string symbol { get; set; }
			public DateTime reportDate { get; set; }
			public string currency { get; set; }
			public Quote quote { get; set; }
		}
	}
}