namespace FinanceProcessor.Core.Models
{
	public class FutureDto
	{
        public string CfiCode { get; set; }
        public double Close { get; set; }
        public string ContractName { get; set; }
        public double ContractSize { get; set; }
        public string Currency { get; set; }
        public string Exchange { get; set; }
        public string ExchangeName { get; set; }
        public string ExpirationDate { get; set; }
        public string Figi { get; set; }
        public double High { get; set; }
        public string LastTradeDate { get; set; }
        public string LastTradeTime { get; set; }
        public string LastUpdated { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double OpenInterest { get; set; }
        public string Region { get; set; }
        public double SettlementPrice { get; set; }
        public string Symbol { get; set; }
        public string Underlying { get; set; }
        public double Volume { get; set; }
        public string Id { get; set; }
        public string Key { get; set; }
        public string Subkey { get; set; }
        public long Date { get; set; }
        public double Updated { get; set; }
    }
}
