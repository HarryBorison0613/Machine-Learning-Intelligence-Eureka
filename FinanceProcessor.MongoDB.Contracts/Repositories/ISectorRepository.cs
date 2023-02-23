using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
	public interface ISectorRepository : IRepository<Sector>
    {
        Task CreateOrReplaceSectorAsync(Sector model);
        IEnumerable<Sector> GetAllSectors();
        Task DeleteSectorsIfNeededAsync(IEnumerable<Sector> newSymbolsFromResponse);
    }
}
