using FinanceProcessor.Core.Aggregates.Customer.Enums;
using FinanceProcessor.SharedKernel.BaseInterfaces;
using Microsoft.AspNetCore.Identity;

namespace FinanceProcessor.Core.Aggregates.Customer.Models;

public class FinanceUser : IdentityUser/*<int>*/, IAggregateRoot
{
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUserRoleUpdated { get; set; }
    public DateTime LastUpdated { get; set; }
    public UserRole? UserFinanceRole { get; set; }
    public Status Status { get; set; }
    public bool IsDeleted { get; set; } = false;
    public SubscriptionRates? SubscriptionRates { get; set; }
    //public string? UserName { get; set; }
    //public string? Email { get; init; }
    //public string? LastName { get; init; }
    public string? Address { get; set; }
    public string? AptSuite { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public string? AboutMe { get; set; }
    public string? AdminAria { get; set; }
    public string? RegionCode { get; set; }
}