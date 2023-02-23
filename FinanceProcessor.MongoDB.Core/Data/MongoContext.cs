using Microsoft.Extensions.Options;
using FinanceProcessor.MongoDB.Contracts;
using MongoDB.Driver;

namespace FinanceProcessor.MongoDB.Core.Data
{
    public class MongoContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoContext(IOptions<MongoOptions> dbOptions)
        {
            var settings = dbOptions.Value;
            _client = new MongoClient(settings.ConnectionString);

            _database = _client.GetDatabase(settings.DatabaseName);
        }

        public IMongoClient Client => _client;

        public IMongoDatabase Database => _database;
    }
}
