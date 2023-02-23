using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
	public interface IExchangeUSRepository : IRepository<ExchangeUS>
    {
        Task CreateOrReplaceExchangeUSAsync(ExchangeUS model);
        IEnumerable<ExchangeUS> GetAllExchangesUS();
        Task DeleteExchangesUSIfNeededAsync(IEnumerable<ExchangeUS> newExchangesUSFromResponse);
    }
}
