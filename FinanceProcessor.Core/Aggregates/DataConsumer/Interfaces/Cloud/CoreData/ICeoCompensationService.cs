using FinanceProcessor.Core.Models;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface ICeoCompensationService
	{
		Task<CeoCompensationDto> GetCeoCompensationAsync(string symbol, CancellationToken cancellationToken = default);
	}
}