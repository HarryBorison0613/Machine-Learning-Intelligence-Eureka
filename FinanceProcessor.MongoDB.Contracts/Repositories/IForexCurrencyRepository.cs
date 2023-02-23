using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
	public interface IForexCurrencyRepository : IRepository<ForexCurrency>
    {
        Task CreateOrReplaceForexCurrencyAsync(ForexCurrency model);
        IEnumerable<ForexCurrency> GetAllForexCurrencies();
        Task DeleteForexCurrencyIfNeededAsync(IEnumerable<ForexCurrency> newForexCurrenciesFromResponse);
    }
}
