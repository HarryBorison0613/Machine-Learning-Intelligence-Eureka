using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
	public interface IInternationalExchangeRepository : IRepository<InternationalExchange>
    {
        Task CreateOrReplaceInternationalExchangeAsync(InternationalExchange model);
        IEnumerable<InternationalExchange> GetAllInternationalExchanges();
        Task DeleteInternationalExchangesIfNeededAsync(IEnumerable<InternationalExchange> newExchangesUSFromResponse);
    }
}
