using FinanceProcessor.MongoDB.Contracts;
using FinanceProcessor.MongoDB.Contracts.Services;
using FinanceProcessor.MongoDB.Core.Data;
using FinanceProcessor.MongoDB.Core.Data.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FinanceProcessor.MongoDB.Core
{
	public static class AddMongoDBCoreExtension
	{
		public static void AddMongoCore(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<MongoOptions>(options => configuration.GetSection(MongoOptions.Mongo).Bind(options));

            // ToDo: should it be like this?
            services.AddSingleton<MongoContext>();
            services.AddHostedService<ConfigureMongoDbIndexesService>();

            services.AddScoped<IDataService, DataService>();

            //services.AddFluentValidation(x =>
            //{
            //    x.DisableDataAnnotationsValidation = true;
            //    x.ImplicitlyValidateChildProperties = true;
            //});

            // ToDo: if needs validation
            // services.AddSingleton<IValidator<CreateOrUpdateIntradayPriceDto>, CreateOrUpdateIntradayPriceDtoValidator>();
        }
	}
}
