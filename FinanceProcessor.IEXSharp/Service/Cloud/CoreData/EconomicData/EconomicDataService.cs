using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.EconomicData.Request;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.EconomicData
{
	public class EconomicDataService : IEconomicDataService
	{
		private readonly ExecutorREST executor;

		internal EconomicDataService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<decimal>> DataPointAsync(EconomicDataSymbol symbol) =>
			await executor.SymbolExecuteAsync<decimal>("data-points/market/[symbol]", symbol.GetDescriptionFromEnum());

		public async Task<IEXResponse<IEnumerable<TimeSeriesResponse>>> TimeSeriesAsync(EconomicDataTimeSeriesSymbol symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<TimeSeriesResponse>>("time-series/economic/[symbol]", symbol.GetDescriptionFromEnum());
	}
}