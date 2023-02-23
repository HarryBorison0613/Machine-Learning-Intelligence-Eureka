using FinanceProcessor.MongoDB.Contracts.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts;

namespace FinanceProcessor.MongoDB.Core.Data.Repositories
{
	public class NewsRepository : INewsRepository
    {
        private readonly IMongoCollection<News> _news;

        public NewsRepository(IMongoDatabase database)
        {
            _news = database.GetCollection<News>(MongoCollectionNames.News);
        }

        public async Task<IEnumerable<News>> GetNewsBySymbolAsync(string symbol)
        {
            return await GetNewsAsync(x => x.Symbol == symbol);
        }

        public async Task CreateNewsAsync(News news, string symbol)
        {
            news.Symbol = symbol;

            await AddAsync(news);
        }

        public async Task DeleteNewsAsync(string id)
        {
            await DeleteAsync(x => x.Id == id);
        }

        #region IRepository implementation

        public async Task AddAsync(News obj)
        {
            await _news.InsertOneAsync(obj);
        }

        public async Task DeleteAllAsync(Expression<Func<News, bool>> predicate)
        {
            _ = await _news.DeleteManyAsync(predicate);
        }

        public async Task DeleteAsync(Expression<Func<News, bool>> predicate)
        {
            _ = await _news.DeleteOneAsync(predicate);
        }

        public IQueryable<News> GetAll()
        {
            return _news.AsQueryable();
        }

        public async Task<News> GetSingleAsync(Expression<Func<News, bool>> predicate)
        {
            var filter = Builders<News>.Filter.Where(predicate);
            return (await _news.FindAsync(filter)).FirstOrDefault();
        }

        private async Task<IEnumerable<News>> GetNewsAsync(Expression<Func<News, bool>> predicate)
        {
            var filter = Builders<News>.Filter.Where(predicate);

            return (await _news.FindAsync(filter)).ToEnumerable();
        }

        public async Task<News> UpdateAsync(News obj)
        {
            return await _news.FindOneAndReplaceAsync(x => x.Id == obj.Id, obj);
        }
        #endregion
    }
}
