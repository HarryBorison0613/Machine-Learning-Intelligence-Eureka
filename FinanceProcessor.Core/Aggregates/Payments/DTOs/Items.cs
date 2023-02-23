namespace FinanceProcessor.Core.Aggregates.Payments.DTOs
{
    public record Item
    {
        public string? Name { get; init; }
        public string? Description { get; init; }
        public int Quantity { get; init; }
        public decimal? Price { get; init; }
        public string? CurrencyCode { get; init; }
    }
}