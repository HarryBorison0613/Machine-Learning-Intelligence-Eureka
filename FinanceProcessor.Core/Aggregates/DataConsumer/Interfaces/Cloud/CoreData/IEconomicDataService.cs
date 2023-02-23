using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.EconomicData.Request;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface IEconomicDataService
	{
		Task<decimal> GetDataPointAsync(EconomicDataSymbol symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<TimeSeriesDto>> GetTimeSeriesAsync(EconomicDataTimeSeriesSymbol symbol, CancellationToken cancellationToken = default);
	}
}
