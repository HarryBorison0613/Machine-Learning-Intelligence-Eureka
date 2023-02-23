using FinanceProcessor.MongoDB.Contracts.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts;

namespace FinanceProcessor.MongoDB.Core.Data.Repositories
{
    public class CryptoSymbolRepository : ICryptoSymbolRepository
    {
        private readonly IMongoCollection<CryptoSymbol> _cryptoSymbols;

        public CryptoSymbolRepository(IMongoDatabase database)
        {
            _cryptoSymbols = database.GetCollection<CryptoSymbol>(MongoCollectionNames.CryptoSymbols);
        }

        public async Task CreateOrReplaceCryptoSymbolAsync(CryptoSymbol crypto)
        {
            await _cryptoSymbols.ReplaceOneAsync(x => x.Symbol == crypto.Symbol, crypto,
				new ReplaceOptions { IsUpsert = true });
		}

        public async Task DeleteSymbolsIfNeededAsync(IEnumerable<CryptoSymbol> newSymbolsFromResponse)
        {
            var symbolsFromDB = GetAll().Select(s => s.Symbol).ToList();

            var symbols = newSymbolsFromResponse.Select(s => s.Symbol);
            var symbolsForDelete = symbolsFromDB.Except(symbols);

            await DeleteAllAsync(x => symbolsForDelete.Contains(x.Symbol));
        }

        public IEnumerable<CryptoSymbol> GetAllCryptoSymbols()
        {
            return GetAll();
        }

        public async Task AddAsync(CryptoSymbol obj)
        {
            await _cryptoSymbols.InsertOneAsync(obj);
        }

        public async Task DeleteAllAsync(Expression<Func<CryptoSymbol, bool>> predicate)
        {
            _ = await _cryptoSymbols.DeleteManyAsync(predicate);
        }

        public async Task DeleteAsync(Expression<Func<CryptoSymbol, bool>> predicate)
        {
            _ = await _cryptoSymbols.DeleteOneAsync(predicate);
        }

        public IQueryable<CryptoSymbol> GetAll()
        {
            return _cryptoSymbols.AsQueryable();
        }

        public async Task<CryptoSymbol> GetSingleAsync(Expression<Func<CryptoSymbol, bool>> predicate)
        {
            var filter = Builders<CryptoSymbol>.Filter.Where(predicate);
            return (await _cryptoSymbols.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<CryptoSymbol> UpdateAsync(CryptoSymbol obj)
        {
            return await _cryptoSymbols.FindOneAndReplaceAsync(x => x.Symbol == obj.Symbol, obj);
        }
    }
}