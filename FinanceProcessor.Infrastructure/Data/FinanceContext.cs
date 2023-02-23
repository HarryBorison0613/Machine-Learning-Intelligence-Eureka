using Duende.IdentityServer.EntityFramework.Options;

using FinanceProcessor.Core.Aggregates.Customer.Models;

using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FinanceProcessor.Infrastructure.Data;

public class FinanceContext : ApiAuthorizationDbContext<FinanceUser/*, FinanceRole, int*/>
{
    public FinanceContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
    {
    }

    public DbSet<SubscriptionRates> SubscriptionRates { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

}