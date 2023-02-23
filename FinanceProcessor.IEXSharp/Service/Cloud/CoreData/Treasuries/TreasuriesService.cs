using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.Treasuries.Request;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.Treasuries
{
	public class TreasuriesService : ITreasuriesService
	{
		private readonly ExecutorREST executor;

		internal TreasuriesService(ExecutorREST executor) => this.executor = executor;

		public async Task<IEXResponse<decimal>> DataPointAsync(TreasuryRateSymbol symbol) =>
			await executor.SymbolExecuteAsync<decimal>("data-points/market/[symbol]", symbol.GetDescriptionFromEnum());

		public async Task<IEXResponse<IEnumerable<TimeSeriesResponse>>> TimeSeriesAsync(TreasuryRateSymbol symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<TimeSeriesResponse>>("time-series/treasury/[symbol]", symbol.GetDescriptionFromEnum());
	}
}
