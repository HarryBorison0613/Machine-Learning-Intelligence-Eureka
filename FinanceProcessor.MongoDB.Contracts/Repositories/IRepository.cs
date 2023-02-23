using System.Linq.Expressions;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T obj);

        Task<T> UpdateAsync(T obj);

        Task DeleteAllAsync(Expression<Func<T, bool>> predicate);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);
    }
}
