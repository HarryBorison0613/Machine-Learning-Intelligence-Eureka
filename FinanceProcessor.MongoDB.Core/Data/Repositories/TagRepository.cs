using MongoDB.Driver;
using System.Linq.Expressions;
using FinanceProcessor.MongoDB.Contracts;
using FinanceProcessor.MongoDB.Contracts.Repositories;

using Tag = FinanceProcessor.MongoDB.Contracts.Entities.Tag;

namespace FinanceProcessor.MongoDB.Core.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly IMongoCollection<Tag> _tags;

        public TagRepository(IMongoDatabase database)
        {
            _tags = database.GetCollection<Tag>(MongoCollectionNames.Tags);
        }

        public async Task CreateOrReplaceTagAsync(Tag tag)
        {
            await _tags.ReplaceOneAsync(x => x.Name == tag.Name, tag,
				new ReplaceOptions { IsUpsert = true });
		}

        public IEnumerable<Tag> GetAllTags()
        {
            return GetAll();
        }

        public async Task AddAsync(Tag obj)
        {
            await _tags.InsertOneAsync(obj);
        }

        public async Task DeleteTagsIfNeededAsync(IEnumerable<Tag> newTagsFromResponse)
        {
            var tagsFromDB = GetAll().Select(s => s.Name).ToList();

            var tags = newTagsFromResponse.Select(s => s.Name);
            var tagsForDelete = tagsFromDB.Except(tags);

          await DeleteAllAsync(x => tagsForDelete.Contains(x.Name));
        }

        public async Task DeleteAllAsync(Expression<Func<Tag, bool>> predicate)
        {
            _ = await _tags.DeleteManyAsync(predicate);
        }

        public async Task DeleteAsync(Expression<Func<Tag, bool>> predicate)
        {
            _ = await _tags.DeleteOneAsync(predicate);
        }

        public IQueryable<Tag> GetAll()
        {
            return _tags.AsQueryable();
        }

        public async Task<Tag> GetSingleAsync(Expression<Func<Tag, bool>> predicate)
        {
            var filter = Builders<Tag>.Filter.Where(predicate);
            return (await _tags.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<Tag> UpdateAsync(Tag obj)
        {
            return await _tags.FindOneAndReplaceAsync(x => x.Name == obj.Name, obj);
        }
    }
}