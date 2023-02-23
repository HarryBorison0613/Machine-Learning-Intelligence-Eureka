using FinanceProcessor.MongoDB.Contracts.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts;

namespace FinanceProcessor.MongoDB.Core.Data.Repositories
{
    public class InternationalExchangeRepository : IInternationalExchangeRepository
    {
        private readonly IMongoCollection<InternationalExchange> _internationalExchanges;

        public InternationalExchangeRepository(IMongoDatabase database)
        {
            _internationalExchanges = database.GetCollection<InternationalExchange>(MongoCollectionNames.InternationalExchanges);
        }

        public async Task CreateOrReplaceInternationalExchangeAsync(InternationalExchange internationalExchange)
        {
            await _internationalExchanges.ReplaceOneAsync(x => x.Mic == internationalExchange.Mic, internationalExchange,
				new ReplaceOptions { IsUpsert = true });
		}

        public IEnumerable<InternationalExchange> GetAllInternationalExchanges()
        {
            return GetAll();
        }

        public async Task AddAsync(InternationalExchange obj)
        {
            await _internationalExchanges.InsertOneAsync(obj);
        }

        public async Task DeleteInternationalExchangesIfNeededAsync(IEnumerable<InternationalExchange> newInternationalExchangesFromResponse)
        {
            var internationalExchangesFromDB = GetAll().Select(s => s.Mic).ToList();

            var internationalExchanges = newInternationalExchangesFromResponse.Select(s => s.Mic);
            var internationalExchangesForDelete = internationalExchangesFromDB.Except(internationalExchanges);

          await DeleteAllAsync(x => internationalExchangesForDelete.Contains(x.Mic));
        }

        public async Task DeleteAllAsync(Expression<Func<InternationalExchange, bool>> predicate)
        {
            _ = await _internationalExchanges.DeleteManyAsync(predicate);
        }

        public async Task DeleteAsync(Expression<Func<InternationalExchange, bool>> predicate)
        {
            _ = await _internationalExchanges.DeleteOneAsync(predicate);
        }

        public IQueryable<InternationalExchange> GetAll()
        {
            return _internationalExchanges.AsQueryable();
        }

        public async Task<InternationalExchange> GetSingleAsync(Expression<Func<InternationalExchange, bool>> predicate)
        {
            var filter = Builders<InternationalExchange>.Filter.Where(predicate);
            return (await _internationalExchanges.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<InternationalExchange> UpdateAsync(InternationalExchange obj)
        {
            return await _internationalExchanges.FindOneAndReplaceAsync(x => x.Mic == obj.Mic, obj);
        }
    }
}