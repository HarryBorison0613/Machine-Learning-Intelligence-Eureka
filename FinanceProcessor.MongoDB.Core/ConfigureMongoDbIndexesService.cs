using FinanceProcessor.MongoDB.Contracts;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Core.Data;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace FinanceProcessor.MongoDB.Core
{
    public class ConfigureMongoDbIndexesService : IHostedService
    {
        private readonly MongoContext _dbContext;

        public ConfigureMongoDbIndexesService(MongoContext dbContext)
        {
            _dbContext = dbContext;
        }

		[Obsolete]
		public async Task StartAsync(CancellationToken cancellationToken)
        {
            var intradayPriceCollection = _dbContext.Database.GetCollection<IntradayPrice>(MongoCollectionNames.IntradayPrices);

            await intradayPriceCollection.Indexes.CreateOneAsync(Builders<IntradayPrice>.IndexKeys.Combine(
               Builders<IntradayPrice>.IndexKeys.Ascending(intradayPrice => intradayPrice.Symbol),
               Builders<IntradayPrice>.IndexKeys.Ascending(intradayPrice => intradayPrice.Date),
               Builders<IntradayPrice>.IndexKeys.Ascending(intradayPrice => intradayPrice.Minute)),
               new CreateIndexOptions()
               {
                   Unique = true,
                   Sparse = true
               });

			var symbolCollection = _dbContext.Database.GetCollection<Symbol>(MongoCollectionNames.Symbols);

			await symbolCollection.Indexes.CreateOneAsync(Builders<Symbol>.IndexKeys.Ascending(symbol => symbol.SymbolId),
			   new CreateIndexOptions()
			   {
				   Unique = true,
				   Sparse = true
			   });
		}


        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
