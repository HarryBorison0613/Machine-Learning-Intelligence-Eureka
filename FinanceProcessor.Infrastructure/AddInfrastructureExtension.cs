using FinanceProcessor.Core.Aggregates.Customer.Repository;
using FinanceProcessor.Infrastructure.Repositories;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceProcessor.Infrastructure;

public static class AddInfrastructureExtension
{
    public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<ISubscriptionRatesRepositoriy, SubscriptionRatesRepositoriy>();
    }
}