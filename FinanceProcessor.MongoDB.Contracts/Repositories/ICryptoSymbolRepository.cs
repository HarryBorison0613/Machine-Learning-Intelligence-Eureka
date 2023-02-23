using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
	public interface ICryptoSymbolRepository : IRepository<CryptoSymbol>
    {
        Task CreateOrReplaceCryptoSymbolAsync(CryptoSymbol model);
        IEnumerable<CryptoSymbol> GetAllCryptoSymbols();
        Task DeleteSymbolsIfNeededAsync(IEnumerable<CryptoSymbol> newSymbolsFromResponse);
    }
}
