namespace FinanceProcessor.Core.Aggregates.Caching
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICacheService
    {
        Task SetAsync<T>(
            CacheKey key,
            T item,
            CacheOptions options,
            CancellationToken cancellationToken = default);

        Task<T> GetAsync<T>(
            CacheKey key,
            CancellationToken cancellationToken = default);

        Task<IDictionary<CacheKey, T>> GetAllAsync<T>(
            IEnumerable<CacheKey> keys,
            CancellationToken cancellationToken = default);

        Task RemoveAsync(
            CacheKey key,
            CancellationToken cancellationToken = default);

        Task SetItemsAsync<T>(
            CacheKey itemsKey,
            IDictionary<string, T> items,
            CacheOptions options,
            CancellationToken cancellationToken = default);

        Task SetItemAsync<T>(
            CacheKey itemsKey,
            string key,
            T item,
            CacheOptions options,
            CancellationToken cancellationToken = default);

        Task<ICollection<T>> GetItemsAsync<T>(
            CacheKey key,
            CancellationToken cancellationToken = default);

        Task<T> GetItemAsync<T>(
            CacheKey itemsKey,
            string itemKey,
            CancellationToken cancellationToken = default);

        Task RemoveItemAsync<T>(
            CacheKey itemsKey,
            string itemKey,
            CancellationToken cancellationToken = default);
    }
}
