using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.Commodities.Request;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface ICommoditiesService
	{
		Task<decimal> GetDataPointAsync(CommoditySymbol symbol, CancellationToken cancellationToken = default);
		Task<IEnumerable<TimeSeriesDto>> GetTimeSeriesAsync(CommoditySymbol symbol, CancellationToken cancellationToken = default);
	}
}
