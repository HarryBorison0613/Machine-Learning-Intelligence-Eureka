namespace FinanceProcessor.PayPalSubscriptions.Models
{
    public record SubscriptionRatesDto
    {
        public int Id { get; init; }
        public int? UserRoleNume { get; init; }
        public string? UserRoleName { get; init; }
        public int SubscriptionPrice { get; init; }
        public TimeSpan Period { get; init; }
        public string? IntervalUnit { get; init; }
        public byte TotalCycles { get; init; }
        public TimeSpan TotalPeriod { get; init; }
    }
}
