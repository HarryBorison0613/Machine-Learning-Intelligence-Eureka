namespace FinanceProcessor.IEXSharp.Model.CoreData.Futures.Response
{
	public class FutureResponse
	{
        public string cfiCode { get; set; }
        public double close { get; set; }
        public string contractName { get; set; }
        public double contractSize { get; set; }
        public string currency { get; set; }
        public string exchange { get; set; }
        public string exchangeName { get; set; }
        public string expirationDate { get; set; }
        public string figi { get; set; }
        public double high { get; set; }
        public string lastTradeDate { get; set; }
        public string lastTradeTime { get; set; }
        public string lastUpdated { get; set; }
        public double low { get; set; }
        public double open { get; set; }
        public double openInterest { get; set; }
        public string region { get; set; }
        public double settlementPrice { get; set; }
        public string symbol { get; set; }
        public string underlying { get; set; }
        public double volume { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string subkey { get; set; }
        public long date { get; set; }
        public double updated { get; set; }
    }
}
