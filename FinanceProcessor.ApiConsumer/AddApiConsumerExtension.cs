using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using QuartzWithScopedServices;
using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FinanceProcessor.ApiConsumer.Jobs.Cloud.CoreData;

namespace FinanceProcessor.ApiConsumer;
public static class AddApiConsumerExtension
{
    public static void AddApiConsumer(this IServiceCollection services, IConfiguration configuration)
    {
		services.Configure<EXCloudClientOptions>(options => configuration.GetSection(EXCloudClientOptions.EXCloudClient).Bind(options));

		services.Configure<AuthorizationOptions>(options => configuration.GetSection(AuthorizationOptions.SECTION_NAME).Bind(options));

		services.AddSingleton<IJobFactory, JobFactory>();
        services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
		services.AddSingleton<QuartzJobRunner>();
        services.AddHostedService<QuartzHostedService>();

		services.AddScoped<NewsJob>(); 
		services.AddScoped<MutualFundsSymbolJob>();
		services.AddScoped<IntradayPriceJob>();
		services.AddScoped<SymbolJob>();
		services.AddScoped<IEXSymbolJob>();
		services.AddScoped<CryptoSymbolJob>();
		services.AddScoped<SectorJob>();
		services.AddScoped<TagJob>();
		services.AddScoped<FXSymbolJob>();
		services.AddScoped<ExchangeUSJob>();
		services.AddScoped<InternationalExchangeJob>();
		services.AddScoped<OTCSymbolJob>();

		services.AddSingleton(new JobSchedule(
			jobType: typeof(NewsJob),
			cronExpression: $"0 {DateTime.Now.Minute + 1} * ? * * *")); // once for when start app(for test)
																		// cronExpression: "0 0 23 ? * * *"));  // i would call it maybe everyday at 23

		services.AddSingleton(new JobSchedule(
			jobType: typeof(SymbolJob),
			cronExpression: $"0 {DateTime.Now.Minute + 1} * ? * * *")); // once for when start app(for test)
																		// cronExpression: "0 0 0 ? * SUN *"));  // i would call it maybe once a week(sunday)
		services.AddSingleton(new JobSchedule(
			jobType: typeof(IEXSymbolJob),
			cronExpression: $"0 {DateTime.Now.Minute + 1} * ? * * *")); // once for when start app(for test)
																		// cronExpression: "0 0 0 ? * SUN *"));  // i would call it maybe once a week(sunday)

		services.AddSingleton(new JobSchedule(
			jobType: typeof(CryptoSymbolJob),
			cronExpression: $"0 {DateTime.Now.Minute + 1} * ? * * *")); // once for when start app(for test)
																		// cronExpression: "0 0 0 ? * SUN *"));  // i would call it maybe once a week(sunday)

		services.AddSingleton(new JobSchedule(
			jobType: typeof(SectorJob),
			cronExpression: $"0 {DateTime.Now.Minute + 1} * ? * * *")); // once for when start app(for test)
																		// cronExpression: "0 0 0 ? * SUN *"));  // i would call it maybe once a week(sunday)

		services.AddSingleton(new JobSchedule(
			jobType: typeof(TagJob),
			cronExpression: $"0 {DateTime.Now.Minute + 1} * ? * * *")); // once for when start app(for test)
																		// cronExpression: "0 0 0 ? * SUN *"));  // i would call it maybe once a week(sunday)

		services.AddSingleton(new JobSchedule(
			jobType: typeof(IntradayPriceJob),
			cronExpression: $"0 {DateTime.Now.Minute + 1} * ? * * *")); // once for when start app(for test)
																		// cronExpression: "0 0 13-17 ? * * *")); // i would call it every hour between 13-17 everyday.

		services.AddSingleton(new JobSchedule(
			jobType: typeof(FXSymbolJob),
			cronExpression: $"0 {DateTime.Now.Minute + 1} * ? * * *")); // once for when start app(for test)
																		// cronExpression: "0 0 13-17 ? * * *")); // i would call it every hour between 13-17 everyday.

		services.AddSingleton(new JobSchedule(
			jobType: typeof(MutualFundsSymbolJob),
			cronExpression: $"0 {DateTime.Now.Minute + 1} * ? * * *")); // once for when start app(for test)
																		// cronExpression: "0 0 13-17 ? * * *")); // i would call it every hour between 13-17 everyday.

		services.AddSingleton(new JobSchedule(
			jobType: typeof(OTCSymbolJob),
			cronExpression: $"0 {DateTime.Now.Minute + 1} * ? * * *")); // once for when start app(for test)
																		// cronExpression: "0 0 13-17 ? * * *")); // i would call it every hour between 13-17 everyday.

		services.AddSingleton(new JobSchedule(
			jobType: typeof(ExchangeUSJob),
			cronExpression: $"0 {DateTime.Now.Minute + 1} * ? * * *")); // once for when start app(for test)
																		// cronExpression: "0 0 13-17 ? * * *")); // i would call it every hour between 13-17 everyday.

		services.AddSingleton(new JobSchedule(
			jobType: typeof(InternationalExchangeJob),
			cronExpression: $"0 {DateTime.Now.Minute + 1} * ? * * *")); // once for when start app(for test)
																		// cronExpression: "0 0 13-17 ? * * *")); // i would call it every hour between 13-17 everyday.
	}
}