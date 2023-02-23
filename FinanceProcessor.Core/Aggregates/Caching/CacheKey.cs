namespace FinanceProcessor.Core.Aggregates.Caching
{
	public struct CacheKey : IEquatable<CacheKey>
    {
        public static CacheKey Create<T>(string id)
        {
            return new CacheKey
            {
                Category = typeof(T).Name,
                Id = id
            };
        }

        public string Id { get; set; }

        public string Category { get; set; }

        public string Value => $"{Category}|{Id}".ToLowerInvariant();

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            return obj is CacheKey cacheKey && Equals(cacheKey);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode(StringComparison.OrdinalIgnoreCase);
        }

        public static bool operator ==(CacheKey left, CacheKey right) => left.Equals(right);

        public static bool operator !=(CacheKey left, CacheKey right) => !(left == right);

        public bool Equals(CacheKey other)
        {
            return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
        }
    }
}
