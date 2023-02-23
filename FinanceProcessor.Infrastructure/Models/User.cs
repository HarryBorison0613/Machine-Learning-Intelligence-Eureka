using FinanceProcessor.Core.Aggregates.Customer.Enums;
using FinanceProcessor.Core.Aggregates.Customer.Models;

namespace FinanceProcessor.Infrastructure.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NickName { get; set; }
        public string? CellPhone { get; set; }
        public string? Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime Deleted { get; set; }
        public UserRole UserRole { get; set; }
        public SubscriptionRates SubscriptionRates { get; set;}
    }
}
