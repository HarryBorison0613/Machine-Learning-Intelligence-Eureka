using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
	public interface IOTCSymbolRepository : IRepository<OTCSymbol>
    {
        Task CreateOrReplaceOTCSymbolAsync(OTCSymbol model);
        IEnumerable<OTCSymbol> GetAllOTCSymbols();
        Task DeleteSymbolsIfNeededAsync(IEnumerable<OTCSymbol> newSymbolsFromResponse);
    }
}
