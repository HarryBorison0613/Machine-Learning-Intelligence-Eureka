namespace FinanceProcessor.Core.Aggregates.Customer.Models;

public class SubscriptionRates
{
    public int Id { get; set; }
    public int? UserRoleNume { get; set; }
    public string? UserRoleName { get; set; }
    public int SubscriptionPrice { get; set; }
    //public TimeSpan Period { get; set; }
    public string? IntervalUnit { get; set; }
    public byte TotalCycles { get; set; }
    //public TimeSpan TotalPeriod { get; set; }

}
