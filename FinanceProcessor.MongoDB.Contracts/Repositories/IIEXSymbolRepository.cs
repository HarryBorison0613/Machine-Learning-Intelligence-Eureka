using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
	public interface IIEXSymbolRepository : IRepository<IEXSymbol>
    {
        Task CreateOrReplaceIEXSymbolAsync(IEXSymbol model);
        IEnumerable<IEXSymbol> GetAllIEXSymbols();
        Task DeleteSymbolsIfNeededAsync(IEnumerable<IEXSymbol> newSymbolsFromResponse);
    }
}
