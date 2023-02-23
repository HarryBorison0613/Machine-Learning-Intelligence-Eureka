namespace FinanceProcessor.Core.Aggregates.Caching
{    
    public sealed class CacheOptions
    {
        public DateTimeOffset AbsoluteExpiration { get; private set; }

        public CacheOptions(DateTimeOffset absoluteExpiration)
        {
            AbsoluteExpiration = absoluteExpiration;
        }
    }
}
