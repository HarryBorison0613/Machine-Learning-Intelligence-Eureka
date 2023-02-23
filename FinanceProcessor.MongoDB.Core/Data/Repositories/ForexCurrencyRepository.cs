using FinanceProcessor.MongoDB.Contracts.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts;

namespace FinanceProcessor.MongoDB.Core.Data.Repositories
{
    public class ForexCurrencyRepository : IForexCurrencyRepository
    {
        private readonly IMongoCollection<ForexCurrency> _forexCurrencies;

        public ForexCurrencyRepository(IMongoDatabase database)
        {
            _forexCurrencies = database.GetCollection<ForexCurrency>(MongoCollectionNames.ForexCurrencies);
        }

        public async Task CreateOrReplaceForexCurrencyAsync(ForexCurrency forexCurrency)
        {
            await _forexCurrencies.ReplaceOneAsync(x => x.Code == forexCurrency.Code, forexCurrency,
				new ReplaceOptions { IsUpsert = true });
		}

        public async Task DeleteForexCurrencyIfNeededAsync(IEnumerable<ForexCurrency> newForexCurrenciesFromResponse)
        {
            var symbolsFromDB = GetAll().Select(s => s.Code).ToList();

            var symbols = newForexCurrenciesFromResponse.Select(s => s.Code);
            var symbolsForDelete = symbolsFromDB.Except(symbols);

            await DeleteAllAsync(x => symbolsForDelete.Contains(x.Code));
        }

        public IEnumerable<ForexCurrency> GetAllForexCurrencies()
        {
            return GetAll();
        }

        public async Task AddAsync(ForexCurrency obj)
        {
            await _forexCurrencies.InsertOneAsync(obj);
        }

        public async Task DeleteAllAsync(Expression<Func<ForexCurrency, bool>> predicate)
        {
            _ = await _forexCurrencies.DeleteManyAsync(predicate);
        }

        public async Task DeleteAsync(Expression<Func<ForexCurrency, bool>> predicate)
        {
            _ = await _forexCurrencies.DeleteOneAsync(predicate);
        }

        public IQueryable<ForexCurrency> GetAll()
        {
            return _forexCurrencies.AsQueryable();
        }

        public async Task<ForexCurrency> GetSingleAsync(Expression<Func<ForexCurrency, bool>> predicate)
        {
            var filter = Builders<ForexCurrency>.Filter.Where(predicate);
            return (await _forexCurrencies.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<ForexCurrency> UpdateAsync(ForexCurrency obj)
        {
            return await _forexCurrencies.FindOneAndReplaceAsync(x => x.Code == obj.Code, obj);
        }
    }
}