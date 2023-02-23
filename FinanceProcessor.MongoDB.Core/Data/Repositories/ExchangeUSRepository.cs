using FinanceProcessor.MongoDB.Contracts.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts;

namespace FinanceProcessor.MongoDB.Core.Data.Repositories
{
    public class ExchangeUSRepository : IExchangeUSRepository
    {
        private readonly IMongoCollection<ExchangeUS> _exchangesUS;

        public ExchangeUSRepository(IMongoDatabase database)
        {
            _exchangesUS = database.GetCollection<ExchangeUS>(MongoCollectionNames.ExchangesUS);
        }

        public async Task CreateOrReplaceExchangeUSAsync(ExchangeUS exchangeUS)
        {
            await _exchangesUS.ReplaceOneAsync(x => x.Mic == exchangeUS.Mic, exchangeUS,
				new ReplaceOptions { IsUpsert = true });
		}

        public IEnumerable<ExchangeUS> GetAllExchangesUS()
        {
            return GetAll();
        }

        public async Task AddAsync(ExchangeUS obj)
        {
            await _exchangesUS.InsertOneAsync(obj);
        }

        public async Task DeleteExchangesUSIfNeededAsync(IEnumerable<ExchangeUS> newExchangesUSFromResponse)
        {
            var exchangeUSsFromDB = GetAll().Select(s => s.Mic).ToList();

            var exchangeUSs = newExchangesUSFromResponse.Select(s => s.Mic);
            var exchangeUSsForDelete = exchangeUSsFromDB.Except(exchangeUSs);

          await DeleteAllAsync(x => exchangeUSsForDelete.Contains(x.Mic));
        }

        public async Task DeleteAllAsync(Expression<Func<ExchangeUS, bool>> predicate)
        {
            _ = await _exchangesUS.DeleteManyAsync(predicate);
        }

        public async Task DeleteAsync(Expression<Func<ExchangeUS, bool>> predicate)
        {
            _ = await _exchangesUS.DeleteOneAsync(predicate);
        }

        public IQueryable<ExchangeUS> GetAll()
        {
            return _exchangesUS.AsQueryable();
        }

        public async Task<ExchangeUS> GetSingleAsync(Expression<Func<ExchangeUS, bool>> predicate)
        {
            var filter = Builders<ExchangeUS>.Filter.Where(predicate);
            return (await _exchangesUS.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<ExchangeUS> UpdateAsync(ExchangeUS obj)
        {
            return await _exchangesUS.FindOneAndReplaceAsync(x => x.Mic == obj.Mic, obj);
        }
    }
}