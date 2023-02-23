using FinanceProcessor.Core.Models;
using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
	public interface ISymbolRepository : IRepository<Symbol>
    {
        Task CreateOrReplaceSymbolAsync(Symbol model);
        IEnumerable<Symbol> GetAllSymbols();
        Task DeleteSymbolsIfNeededAsync(IEnumerable<Symbol> newSymbolsFromResponse);
    }
}
