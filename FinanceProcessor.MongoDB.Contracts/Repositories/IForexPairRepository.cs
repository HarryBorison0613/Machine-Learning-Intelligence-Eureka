using FinanceProcessor.MongoDB.Contracts.Entities;
using System.Linq.Expressions;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
	public interface IForexPairRepository
	{
		Task AddAsync(ForexPair obj);
		Task CreateOrReplaceForexPairAsync(ForexPair forexPair);
		Task DeleteAllAsync(Expression<Func<ForexPair, bool>> predicate);
		Task DeleteAsync(Expression<Func<ForexPair, bool>> predicate);
		Task DeleteForexPairIfNeededAsync(IEnumerable<ForexPair> newForexPairsFromResponse);
		IQueryable<ForexPair> GetAll();
		IEnumerable<ForexPair> GetAllForexPairs();
		Task<ForexPair> GetSingleAsync(Expression<Func<ForexPair, bool>> predicate);
		Task<ForexPair> UpdateAsync(ForexPair obj);
	}
}