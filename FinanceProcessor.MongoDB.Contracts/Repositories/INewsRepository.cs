using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
	public interface INewsRepository : IRepository<News>
	{
		Task<IEnumerable<News>> GetNewsBySymbolAsync(string newsId);

		Task CreateNewsAsync(News news, string cryptoSymbol);

		Task DeleteNewsAsync(string id);
	}
}
