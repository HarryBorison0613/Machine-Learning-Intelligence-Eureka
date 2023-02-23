using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
	public interface IMutualFundsSymbolRepository : IRepository<MutualFundsSymbol>
    {
        Task CreateOrReplaceMutualFundsSymbolAsync(MutualFundsSymbol model);
        IEnumerable<MutualFundsSymbol> GetAllMutualFundsSymbols();
        Task DeleteSymbolsIfNeededAsync(IEnumerable<MutualFundsSymbol> newSymbolsFromResponse);
    }
}
