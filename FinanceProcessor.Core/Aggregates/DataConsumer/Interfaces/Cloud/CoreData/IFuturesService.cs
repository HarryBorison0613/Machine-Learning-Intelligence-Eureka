using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.Futures.Request;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface IFuturesService
	{
		Task<IEnumerable<FutureDto>> GetEndOfDayFuturesAsync(string contractSymbol, FuturesRange range, CancellationToken cancellationToken = default);
	}
}