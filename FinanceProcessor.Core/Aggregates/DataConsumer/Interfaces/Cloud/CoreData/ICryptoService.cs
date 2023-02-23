using FinanceProcessor.Core.Models;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface ICryptoService
	{
		Task<CryptoPriceDto> GetPriceAsync(string symbol);
		Task<QuoteCryptoDto> GetQuoteAsync(string symbol);
		Task<CryptoBookDto> BookAsync(string symbol);
		Task<List<CryptoBookDto>> BookStream(IEnumerable<string> symbols);
		Task<List<EventCryptoDto>> GetEventStream(IEnumerable<string> symbols);
		Task<List<QuoteCryptoDto>> GetQuoteStream(IEnumerable<string> symbols);
	}
}
