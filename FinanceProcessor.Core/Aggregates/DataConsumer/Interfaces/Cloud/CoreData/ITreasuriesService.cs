using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.Treasuries.Request;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface ITreasuriesService
	{
		Task<decimal> GetDataPointAsync(TreasuryRateSymbol symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<TimeSeriesDto>> GetTimeSeriesAsync(TreasuryRateSymbol symbol, CancellationToken cancellationToken = default);
	}
}
