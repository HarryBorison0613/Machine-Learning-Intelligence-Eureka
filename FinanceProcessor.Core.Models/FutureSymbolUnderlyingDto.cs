namespace FinanceProcessor.Core.Models
{
	public class FutureSymbolUnderlyingDto
	{
        public string Symbol { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string ExpirationDate { get; set; }
        public string Underlying { get; set; }
        public string Region { get; set; }
        public string Currency { get; set; }
        public string Figi { get; set; }
        public int ContractSize { get; set; }
        public string CfiCode { get; set; }
        public string Exchange { get; set; }
        public string ExchangeName { get; set; }
    }
}
