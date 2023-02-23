using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace FinanceProcessor.Core.Aggregates.Caching
{
	public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<MemoryCacheService> _logger;

        public MemoryCacheService(
            IMemoryCache cache,
            ILogger<MemoryCacheService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public Task<T> GetAsync<T>(CacheKey key, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var result = _cache.Get<T>(key.Value);

                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return Task.FromResult<T>(default);
            }
        }

        public Task<IDictionary<CacheKey, T>> GetAllAsync<T>(IEnumerable<CacheKey> keys, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var result = new Dictionary<CacheKey, T>();

                foreach (var key in keys)
                {
                    var keyValue = key.Value;
                    var value = _cache.Get<T>(keyValue);
                    result[key] = value;
                }

                return Task.FromResult<IDictionary<CacheKey, T>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return Task.FromResult<IDictionary<CacheKey, T>>(default);
            }
        }

        public Task RemoveAsync(CacheKey key, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                _cache.Remove(key.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        public Task SetAsync<T>(CacheKey key, T item, CacheOptions options, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = options.AbsoluteExpiration
                };

                _cache.Set(key.Value, item, cacheEntryOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        public async Task SetItemsAsync<T>(CacheKey itemsKey, IDictionary<string, T> items, CacheOptions options, CancellationToken cancellationToken = default)
        {
            await SetAsync(itemsKey, items, options, cancellationToken);
        }

        public async Task SetItemAsync<T>(CacheKey itemsKey, string key, T item, CacheOptions options, CancellationToken cancellationToken = default)
        {
            var items = await GetAsync<IDictionary<string, T>>(itemsKey, cancellationToken);

            items[key] = item;

            await SetItemsAsync(itemsKey, items, options, cancellationToken);
        }

        public async Task<ICollection<T>> GetItemsAsync<T>(CacheKey key, CancellationToken cancellationToken = default)
        {
            var items = await GetAsync<IDictionary<string, T>>(key, cancellationToken);

            return items?.Select(x => x.Value).ToArray();
        }

        public async Task<T> GetItemAsync<T>(CacheKey itemsKey, string itemKey, CancellationToken cancellationToken = default)
        {
            var items = await GetAsync<IDictionary<string, T>>(itemsKey, cancellationToken);

            return items.TryGetValue(itemKey, out var item)
				? item
				: default;
        }

        public async Task RemoveItemAsync<T>(CacheKey itemsKey, string itemKey, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var items = await GetAsync<IDictionary<string, T>>(itemsKey, cancellationToken);

                items.Remove(itemKey);

                await SetItemsAsync(itemsKey, items, new CacheOptions(DateTimeOffset.UtcNow.AddMinutes(30)), cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
