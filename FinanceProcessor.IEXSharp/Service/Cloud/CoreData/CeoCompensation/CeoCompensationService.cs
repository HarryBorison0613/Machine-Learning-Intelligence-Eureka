using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.CeoCompensation.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.CeoCompensation
{
	public class CeoCompensationService : ICeoCompensationService
	{
		private readonly ExecutorREST executor;

		internal CeoCompensationService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<CeoCompensationResponse>> CeoCompensationAsync(string symbol) =>
			await executor.SymbolExecuteAsync<CeoCompensationResponse>("stock/[symbol]/ceo-compensation", symbol);
	}
}
