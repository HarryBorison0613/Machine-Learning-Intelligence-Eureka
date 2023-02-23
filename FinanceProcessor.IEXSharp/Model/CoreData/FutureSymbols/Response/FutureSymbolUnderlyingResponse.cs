namespace FinanceProcessor.IEXSharp.Model.CoreData.FutureSymbols.Response
{
	public class FutureSymbolUnderlyingResponse
    {
        public string symbol { get; set; }
        public string date { get; set; }
        public string name { get; set; }
        public string expirationDate { get; set; }
        public string underlying { get; set; }
        public string region { get; set; }
        public string currency { get; set; }
        public string figi { get; set; }
        public int contractSize { get; set; }
        public string cfiCode { get; set; }
        public string exchange { get; set; }
        public string exchangeName { get; set; }
	}
}
