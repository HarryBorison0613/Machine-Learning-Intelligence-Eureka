using FinanceProcessor.MongoDB.Contracts.Entities;

namespace FinanceProcessor.MongoDB.Contracts.Repositories
{
	public interface ITagRepository : IRepository<Tag>
    {
        Task CreateOrReplaceTagAsync(Tag model);
        IEnumerable<Tag> GetAllTags();
        Task DeleteTagsIfNeededAsync(IEnumerable<Tag> newSymbolsFromResponse);
    }
}
