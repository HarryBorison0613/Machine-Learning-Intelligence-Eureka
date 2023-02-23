using FinanceProcessor.MongoDB.Contracts.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts;

namespace FinanceProcessor.MongoDB.Core.Data.Repositories
{
	public class ForexPairRepository : IForexPairRepository
	{
		private readonly IMongoCollection<ForexPair> _forexPairs;

		public ForexPairRepository(IMongoDatabase database)
		{
			_forexPairs = database.GetCollection<ForexPair>(MongoCollectionNames.ForexPairs);
		}

		public async Task CreateOrReplaceForexPairAsync(ForexPair forexPair)
		{
			await _forexPairs.ReplaceOneAsync(x => x.Symbol == forexPair.Symbol, forexPair,
				new ReplaceOptions { IsUpsert = true });
		}

		public async Task DeleteForexPairIfNeededAsync(IEnumerable<ForexPair> newForexPairsFromResponse)
		{
			var symbolsFromDB = GetAll().Select(s => s.Symbol).ToList();

			var symbols = newForexPairsFromResponse.Select(s => s.Symbol);
			var symbolsForDelete = symbolsFromDB.Except(symbols);

			await DeleteAllAsync(x => symbolsForDelete.Contains(x.Symbol));
		}

		public IEnumerable<ForexPair> GetAllForexPairs()
		{
			return GetAll();
		}

		public async Task AddAsync(ForexPair obj)
		{
			await _forexPairs.InsertOneAsync(obj);
		}

		public async Task DeleteAllAsync(Expression<Func<ForexPair, bool>> predicate)
		{
			_ = await _forexPairs.DeleteManyAsync(predicate);
		}

		public async Task DeleteAsync(Expression<Func<ForexPair, bool>> predicate)
		{
			_ = await _forexPairs.DeleteOneAsync(predicate);
		}

		public IQueryable<ForexPair> GetAll()
		{
			return _forexPairs.AsQueryable();
		}

		public async Task<ForexPair> GetSingleAsync(Expression<Func<ForexPair, bool>> predicate)
		{
			var filter = Builders<ForexPair>.Filter.Where(predicate);
			return (await _forexPairs.FindAsync(filter)).FirstOrDefault();
		}

		public async Task<ForexPair> UpdateAsync(ForexPair obj)
		{
			return await _forexPairs.FindOneAndReplaceAsync(x => x.Symbol == obj.Symbol, obj);
		}
	}
}