using FinanceProcessor.MongoDB.Contracts.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts;

namespace FinanceProcessor.MongoDB.Core.Data.Repositories
{
    public class SymbolRepository : ISymbolRepository
    {
        private readonly IMongoCollection<Symbol> _symbols;

        public SymbolRepository(IMongoDatabase database)
        {
            _symbols = database.GetCollection<Symbol>(MongoCollectionNames.Symbols);
        }

        public async Task CreateOrReplaceSymbolAsync(Symbol symbol)
        {
            await _symbols.ReplaceOneAsync(x => x.SymbolId == symbol.SymbolId, symbol,
				new ReplaceOptions { IsUpsert = true });
		}

        public IEnumerable<Symbol> GetAllSymbols()
        {
            return GetAll();
        }

        public async Task AddAsync(Symbol obj)
        {
            await _symbols.InsertOneAsync(obj);
        }

        public async Task DeleteSymbolsIfNeededAsync(IEnumerable<Symbol> newSymbolsFromResponse)
        {
            var symbolsFromDB = GetAll().Select(s => s.SymbolId).ToList();

            var symbols = newSymbolsFromResponse.Select(s => s.SymbolId);
            var symbolsForDelete = symbolsFromDB.Except(symbols);

          await DeleteAllAsync(x => symbolsForDelete.Contains(x.SymbolId));
        }

        public async Task DeleteAllAsync(Expression<Func<Symbol, bool>> predicate)
        {
            _ = await _symbols.DeleteManyAsync(predicate);
        }

        public async Task DeleteAsync(Expression<Func<Symbol, bool>> predicate)
        {
            _ = await _symbols.DeleteOneAsync(predicate);
        }

        public IQueryable<Symbol> GetAll()
        {
            return _symbols.AsQueryable();
        }

        public async Task<Symbol> GetSingleAsync(Expression<Func<Symbol, bool>> predicate)
        {
            var filter = Builders<Symbol>.Filter.Where(predicate);
            return (await _symbols.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<Symbol> UpdateAsync(Symbol obj)
        {
            return await _symbols.FindOneAndReplaceAsync(x => x.SymbolId == obj.SymbolId, obj);
        }
    }
}