using FinanceProcessor.MongoDB.Contracts.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts;

namespace FinanceProcessor.MongoDB.Core.Data.Repositories
{
    public class SectorRepository : ISectorRepository
    {
        private readonly IMongoCollection<Sector> _sectors;

        public SectorRepository(IMongoDatabase database)
        {
            _sectors = database.GetCollection<Sector>(MongoCollectionNames.Sectors);
        }

        public async Task CreateOrReplaceSectorAsync(Sector sector)
        {
            await _sectors.ReplaceOneAsync(x => x.Name == sector.Name, sector,
				new ReplaceOptions { IsUpsert = true });
		}

        public IEnumerable<Sector> GetAllSectors()
        {
            return GetAll();
        }

        public async Task AddAsync(Sector obj)
        {
            await _sectors.InsertOneAsync(obj);
        }

        public async Task DeleteSectorsIfNeededAsync(IEnumerable<Sector> newSectorsFromResponse)
        {
            var sectorsFromDB = GetAll().Select(s => s.Name).ToList();

            var sectors = newSectorsFromResponse.Select(s => s.Name);
            var sectorsForDelete = sectorsFromDB.Except(sectors);

          await DeleteAllAsync(x => sectorsForDelete.Contains(x.Name));
        }

        public async Task DeleteAllAsync(Expression<Func<Sector, bool>> predicate)
        {
            _ = await _sectors.DeleteManyAsync(predicate);
        }

        public async Task DeleteAsync(Expression<Func<Sector, bool>> predicate)
        {
            _ = await _sectors.DeleteOneAsync(predicate);
        }

        public IQueryable<Sector> GetAll()
        {
            return _sectors.AsQueryable();
        }

        public async Task<Sector> GetSingleAsync(Expression<Func<Sector, bool>> predicate)
        {
            var filter = Builders<Sector>.Filter.Where(predicate);
            return (await _sectors.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<Sector> UpdateAsync(Sector obj)
        {
            return await _sectors.FindOneAndReplaceAsync(x => x.Name == obj.Name, obj);
        }
    }
}