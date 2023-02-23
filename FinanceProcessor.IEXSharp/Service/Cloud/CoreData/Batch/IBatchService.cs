using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.Batch.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.Batch.Response;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.Batch
{
	public interface IBatchService
	{

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <param name="types"></param>
		/// <param name="optionalParameters"></param>
		/// <returns></returns>
		Task<IEXResponse<BatchResponse>> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types, ChartRange chartRange, int? last = null);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#batch-requests"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <param name="types"></param>
		/// <param name="optionalParameters"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, BatchResponse>>> BatchByMarketAsync(IEnumerable<string> symbols, IEnumerable<BatchType> types, ChartRange chartRange, int? last = null);
	}
}