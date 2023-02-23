using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.Options.Request;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface IOptionsService
	{
		Task<IEnumerable<string>> GetOptionsAsync(string symbol, CancellationToken cancellationToken);
		Task<IEnumerable<string>> GetOptionsWithExpirationAsync(string symbol, string expiration, CancellationToken cancellationToken);
		Task<IEnumerable<OptionDto>> GetOptionsWithOptionSideAsync(string symbol, string expiration, OptionSide optionSide, CancellationToken cancellationToken);
	}
}
