using FinanceProcessor.MongoDB.Contracts.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts;

namespace FinanceProcessor.MongoDB.Core.Data.Repositories
{
    public class IEXSymbolRepository : IIEXSymbolRepository
    {
        private readonly IMongoCollection<IEXSymbol> _iEXSymbols;

        public IEXSymbolRepository(IMongoDatabase database)
        {
            _iEXSymbols = database.GetCollection<IEXSymbol>(MongoCollectionNames.IEXSymbols);
        }

        public async Task CreateOrReplaceIEXSymbolAsync(IEXSymbol iEX)
        {
            await _iEXSymbols.ReplaceOneAsync(x => x.Symbol == iEX.Symbol, iEX,
				new ReplaceOptions { IsUpsert = true });
		}

        public IEnumerable<IEXSymbol> GetAllIEXSymbols()
        {
            return GetAll();
        }

        public async Task AddAsync(IEXSymbol obj)
        {
            await _iEXSymbols.InsertOneAsync(obj);
        }

        public async Task DeleteSymbolsIfNeededAsync(IEnumerable<IEXSymbol> newSymbolsFromResponse)
        {
            var symbolsFromDB = GetAll().Select(s => s.Symbol).ToList();

            var symbols = newSymbolsFromResponse.Select(s => s.Symbol);
            var symbolsForDelete = symbolsFromDB.Except(symbols);

            await DeleteAllAsync(x => symbolsForDelete.Contains(x.Symbol));
        }
        public async Task DeleteAllAsync(Expression<Func<IEXSymbol, bool>> predicate)
        {
            _ = await _iEXSymbols.DeleteManyAsync(predicate);
        }

        public async Task DeleteAsync(Expression<Func<IEXSymbol, bool>> predicate)
        {
            _ = await _iEXSymbols.DeleteOneAsync(predicate);
        }

        public IQueryable<IEXSymbol> GetAll()
        {
            return _iEXSymbols.AsQueryable();
        }

        public async Task<IEXSymbol> GetSingleAsync(Expression<Func<IEXSymbol, bool>> predicate)
        {
            var filter = Builders<IEXSymbol>.Filter.Where(predicate);
            return (await _iEXSymbols.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<IEXSymbol> UpdateAsync(IEXSymbol obj)
        {
            return await _iEXSymbols.FindOneAndReplaceAsync(x => x.Symbol == obj.Symbol, obj);
        }
    }
}