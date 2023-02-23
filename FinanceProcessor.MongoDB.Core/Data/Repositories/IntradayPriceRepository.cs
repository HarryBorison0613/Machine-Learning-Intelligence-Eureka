using FinanceProcessor.MongoDB.Contracts.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts;

namespace FinanceProcessor.MongoDB.Core.Data.Repositories
{
    public class IntradayPriceRepository : IIntradayPriceRepository
    {
        private readonly IMongoCollection<IntradayPrice> _intradayPrices;

        public IntradayPriceRepository(IMongoDatabase database)
        {
            _intradayPrices = database.GetCollection<IntradayPrice>(MongoCollectionNames.IntradayPrices);
        }

        public async Task<bool> IsExist(string cryptoSymbol, string date, string minute)
        {
            return await GetSingleAsync(i => i.Symbol == cryptoSymbol
                                    && i.Date == date
                                    && i.Minute == minute) is not null;
        }

        public async Task<IEnumerable<IntradayPrice>> GetIntradayPricesBySymbolAsync(string symbol)
        {
             return await GetIntradayPricesAsync(x => x.Symbol == symbol);
        }

        public async Task CreateIntradayPriceAsync(IntradayPrice intradayPrice, string symbol)
        {
            var isExist = await IsExist(symbol, intradayPrice.Date, intradayPrice.Minute);

            if (isExist) return;

            intradayPrice.Symbol = symbol;

            await AddAsync(intradayPrice);
        }

        public async Task DeleteIntradayPriceAsync(string id)
        {
            await DeleteAsync(x => x.Id == id);
        }

        #region IRepository implementation

        public async Task AddAsync(IntradayPrice obj)
        {
            await _intradayPrices.InsertOneAsync(obj);
        }

        public async Task DeleteAllAsync(Expression<Func<IntradayPrice, bool>> predicate)
        {
            _ = await _intradayPrices.DeleteManyAsync(predicate);
        }

        public async Task DeleteAsync(Expression<Func<IntradayPrice, bool>> predicate)
        {
            _ = await _intradayPrices.DeleteOneAsync(predicate);
        }

        public IQueryable<IntradayPrice> GetAll()
        {
            return _intradayPrices.AsQueryable();
        }

        public async Task<IntradayPrice> GetSingleAsync(Expression<Func<IntradayPrice, bool>> predicate)
        {
            var filter = Builders<IntradayPrice>.Filter.Where(predicate);
            return (await _intradayPrices.FindAsync(filter)).FirstOrDefault();
        }

        private async Task<IEnumerable<IntradayPrice>> GetIntradayPricesAsync(Expression<Func<IntradayPrice, bool>> predicate)
        {
            var filter = Builders<IntradayPrice>.Filter.Where(predicate);

            return (await _intradayPrices.FindAsync(filter)).ToEnumerable();
        }

		public async Task<IntradayPrice> UpdateAsync(IntradayPrice obj)
		{
            return await _intradayPrices.FindOneAndReplaceAsync(x => x.Id == obj.Id, obj);
        }
        #endregion
    }
}