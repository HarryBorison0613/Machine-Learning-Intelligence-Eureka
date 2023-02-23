using FinanceProcessor.MongoDB.Contracts.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts;

namespace FinanceProcessor.MongoDB.Core.Data.Repositories
{
    public class OTCSymbolRepository : IOTCSymbolRepository
    {
        private readonly IMongoCollection<OTCSymbol> _otcSymbols;

        public OTCSymbolRepository(IMongoDatabase database)
        {
            _otcSymbols = database.GetCollection<OTCSymbol>(MongoCollectionNames.OTCSymbols);
        }

        public async Task CreateOrReplaceOTCSymbolAsync(OTCSymbol otc)
        {
            await _otcSymbols.ReplaceOneAsync(x => x.Symbol == otc.Symbol, otc,
				new ReplaceOptions { IsUpsert = true });
		}

        public async Task DeleteSymbolsIfNeededAsync(IEnumerable<OTCSymbol> newSymbolsFromResponse)
        {
            var symbolsFromDB = GetAll().Select(s => s.Symbol).ToList();

            var symbols = newSymbolsFromResponse.Select(s => s.Symbol);
            var symbolsForDelete = symbolsFromDB.Except(symbols);

            await DeleteAllAsync(x => symbolsForDelete.Contains(x.Symbol));
        }

        public IEnumerable<OTCSymbol> GetAllOTCSymbols()
        {
            return GetAll();
        }

        public async Task AddAsync(OTCSymbol obj)
        {
            await _otcSymbols.InsertOneAsync(obj);
        }

        public async Task DeleteAllAsync(Expression<Func<OTCSymbol, bool>> predicate)
        {
            _ = await _otcSymbols.DeleteManyAsync(predicate);
        }

        public async Task DeleteAsync(Expression<Func<OTCSymbol, bool>> predicate)
        {
            _ = await _otcSymbols.DeleteOneAsync(predicate);
        }

        public IQueryable<OTCSymbol> GetAll()
        {
            return _otcSymbols.AsQueryable();
        }

        public async Task<OTCSymbol> GetSingleAsync(Expression<Func<OTCSymbol, bool>> predicate)
        {
            var filter = Builders<OTCSymbol>.Filter.Where(predicate);
            return (await _otcSymbols.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<OTCSymbol> UpdateAsync(OTCSymbol obj)
        {
            return await _otcSymbols.FindOneAndReplaceAsync(x => x.Symbol == obj.Symbol, obj);
        }
    }
}