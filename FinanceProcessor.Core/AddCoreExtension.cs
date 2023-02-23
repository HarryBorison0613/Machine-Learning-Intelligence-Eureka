using FinanceProcessor.Core.Aggregates.Caching;
using FinanceProcessor.Core.Aggregates.Customer.Services;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Payment;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User;
using FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData;
using FinanceProcessor.Core.Aggregates.DataConsumer.Services.Payments;
using FinanceProcessor.Core.Aggregates.security;
using FinanceProcessor.PayPal.Core;
using FinanceProcessor.PayPalSubscriptions.Core;

using Microsoft.Extensions.DependencyInjection;

namespace FinanceProcessor.Core;

public static class AddCoreExtension
{
    public static void AddCore(this IServiceCollection service)
    {
        service.AddTransient<IStockPricesService, StockPricesService>();
        service.AddTransient<INewsService, NewsService>();
        service.AddTransient<IReferencesService, ReferencesService>();
        service.AddTransient<ICryptoService, CryptoService>();
        service.AddTransient<IMarketInfoService, MarketInfoService>();
        service.AddScoped<ISecurity, SecurityCrypts>();
        service.AddScoped<IAuthorizationService, AuthorizationService>();
        service.AddScoped<IAuthenticationService, AuthenticationService>();
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IStockFundamentalsService, StockFundamentalsService>();
        service.AddScoped<ICacheService, MemoryCacheService>();
        service.AddScoped<ICorporateActionsService, CorporateActionsService>();
        service.AddScoped<ICeoCompensationService, CeoCompensationService>();
        service.AddScoped<IStockProfilesService, StockProfilesService>();
        service.AddScoped<IPaymentService, PaymentService>();
        service.AddScoped<IPayPalOrders, PayPalOrders>();
        service.AddScoped<IStatusChecker, StatusChecker>();
        service.AddScoped<IStockResearchService, StockResearchService>();
        service.AddScoped<IPayPalOrders, PayPalOrders>();
        service.AddScoped<IPayPalClient, PayPalClient>();
        service.AddScoped<IBatchService, BatchService>(); 
        service.AddScoped<IFuturesService, FuturesService>();
        service.AddScoped<IForexCurrenciesService, ForexCurrenciesService>();
        service.AddScoped<IOptionsService, OptionsService>();
        service.AddScoped<ITreasuriesService, TreasuriesService>();
        service.AddScoped<IEconomicDataService, EconomicDataService>();
        service.AddScoped<ICommoditiesService, CommoditiesService>();
        service.AddScoped<IInvestorsExchangeDataService, InvestorsExchangeDataService>();
        service.AddScoped<ISubscriptionManagement, SubscriptionManagement>();
        service.AddScoped<ISetupSubscriptionClient, SetupSubscriptionClient>();
    }
}