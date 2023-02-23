using FinanceProcessor.MongoDB.Contracts.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts;

namespace FinanceProcessor.MongoDB.Core.Data.Repositories
{
    public class MutualFundsSymbolRepository : IMutualFundsSymbolRepository
    {
        private readonly IMongoCollection<MutualFundsSymbol> _mutualFundsSymbols;

        public MutualFundsSymbolRepository(IMongoDatabase database)
        {
            _mutualFundsSymbols = database.GetCollection<MutualFundsSymbol>(MongoCollectionNames.MutualFundsSymbols);
        }

        public async Task CreateOrReplaceMutualFundsSymbolAsync(MutualFundsSymbol mutualFunds)
        {
            await _mutualFundsSymbols.ReplaceOneAsync(x => x.Symbol == mutualFunds.Symbol, mutualFunds,
				new ReplaceOptions { IsUpsert = true });
		}

        public async Task DeleteSymbolsIfNeededAsync(IEnumerable<MutualFundsSymbol> newSymbolsFromResponse)
        {
            var symbolsFromDB = GetAll().Select(s => s.Symbol).ToList();

            var symbols = newSymbolsFromResponse.Select(s => s.Symbol);
            var symbolsForDelete = symbolsFromDB.Except(symbols);

            await DeleteAllAsync(x => symbolsForDelete.Contains(x.Symbol));
        }

        public IEnumerable<MutualFundsSymbol> GetAllMutualFundsSymbols()
        {
            return GetAll();
        }

        public async Task AddAsync(MutualFundsSymbol obj)
        {
            await _mutualFundsSymbols.InsertOneAsync(obj);
        }

        public async Task DeleteAllAsync(Expression<Func<MutualFundsSymbol, bool>> predicate)
        {
            _ = await _mutualFundsSymbols.DeleteManyAsync(predicate);
        }

        public async Task DeleteAsync(Expression<Func<MutualFundsSymbol, bool>> predicate)
        {
            _ = await _mutualFundsSymbols.DeleteOneAsync(predicate);
        }

        public IQueryable<MutualFundsSymbol> GetAll()
        {
            return _mutualFundsSymbols.AsQueryable();
        }

        public async Task<MutualFundsSymbol> GetSingleAsync(Expression<Func<MutualFundsSymbol, bool>> predicate)
        {
            var filter = Builders<MutualFundsSymbol>.Filter.Where(predicate);
            return (await _mutualFundsSymbols.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<MutualFundsSymbol> UpdateAsync(MutualFundsSymbol obj)
        {
            return await _mutualFundsSymbols.FindOneAndReplaceAsync(x => x.Symbol == obj.Symbol, obj);
        }
    }
}