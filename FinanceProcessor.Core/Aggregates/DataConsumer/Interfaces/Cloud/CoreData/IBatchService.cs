using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.Batch.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData
{
	public interface IBatchService
	{
		Task<BatchDto> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types, ChartRange chartRange, int? last = null);

		Task<Dictionary<string, BatchDto>> BatchByMarketAsync(IEnumerable<string> symbols, IEnumerable<BatchType> types, ChartRange chartRange, int? last = null);
	}
}