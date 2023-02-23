using Newtonsoft.Json;

namespace FinanceProcessor.IEXSharp.Model.CoreData.MarketInfo.Response
{
	public class IPOCalendarResponse
	{
        public decimal? currentPrice { get; set; }
        public string filedDate { get; set; }
        public decimal? firstDayClose { get; set; }
        public string status { get; set; }
        public string companyName { get; set; }
        public string lockupPeriod { get; set; }
        public string managers { get; set; }
        public string offeringDate { get; set; }
        public decimal? offerPrice { get; set; }
        public decimal? priceRangeHigh { get; set; }
        public decimal? priceRangeLow { get; set; }
        public string quietperiod { get; set; }

        [JsonProperty("return")]
        public decimal? returnValue { get; set; }
        public int shares { get; set; }
        public string symbol { get; set; }
        public string updated { get; set; }
        public int volume { get; set; }
    }
}