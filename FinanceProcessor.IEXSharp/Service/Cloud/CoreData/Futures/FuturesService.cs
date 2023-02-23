using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.Futures.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.Futures.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.Treasuries
{
	public class FuturesService : IFuturesService
	{
		private readonly ExecutorREST executor;

		internal FuturesService(ExecutorREST executor) => this.executor = executor;

		public async Task<IEXResponse<IEnumerable<FutureResponse>>> EndOfDayFutures(string contractSymbol, FuturesRange range)
		{
			const string urlPattern = "futures/[contractSymbol]/chart";
			var queryStringBuilder = new QueryStringBuilder();
			var pathNvc = new NameValueCollection();

			if (!string.IsNullOrEmpty(contractSymbol))
			{
				pathNvc.Add("contractSymbol", contractSymbol);
			}

			if (range != null)
			{
				queryStringBuilder.Add("range", range.GetDescriptionFromEnum());
			}

			return await executor.ExecuteAsync<IEnumerable<FutureResponse>>(urlPattern, pathNvc, queryStringBuilder);
		}
	}
}
