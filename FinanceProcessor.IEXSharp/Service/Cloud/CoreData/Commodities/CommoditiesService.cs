using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.Commodities.Request;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.Commodities
{
	public class CommoditiesService : ICommoditiesService
	{
		private readonly ExecutorREST executor;

		internal CommoditiesService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<decimal>> DataPointAsync(CommoditySymbol symbol) =>
			await executor.SymbolExecuteAsync<decimal>("data-points/market/[symbol]", symbol.GetDescriptionFromEnum());

		public async Task<IEXResponse<IEnumerable<TimeSeriesResponse>>> TimeSeriesAsync(CommoditySymbol symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<TimeSeriesResponse>>("time-series/energy/[symbol]", symbol.GetDescriptionFromEnum());
	}
}
