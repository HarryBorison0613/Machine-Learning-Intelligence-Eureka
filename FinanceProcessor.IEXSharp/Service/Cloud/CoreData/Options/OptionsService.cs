using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.Options.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.Options.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.Options
{
	public class OptionsService : IOptionsService
	{
		private readonly ExecutorREST executor;

		internal OptionsService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<string>>> OptionsAsync(string symbol) =>
			await executor.SymbolExecuteAsync<IEnumerable<string>>("stock/[symbol]/options", symbol);

		public async Task<IEXResponse<IEnumerable<OptionResponse>>> OptionsAsync(string symbol, string expiration)
		{
			const string urlPattern = "stock/[symbol]/options/[expiration]";

			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "expiration", expiration } };

			return await executor.ExecuteAsync<IEnumerable<OptionResponse>>(urlPattern, pathNvc, qsb);
		}

		public async Task<IEXResponse<IEnumerable<OptionResponse>>> OptionsAsync(string symbol, string expiration, OptionSide optionSide)
		{
			const string urlPattern = "stock/[symbol]/options/[expiration]/[optionSide]";

			var qsb = new QueryStringBuilder();
			var pathNvc = new NameValueCollection { { "symbol", symbol }, { "expiration", expiration }, { "optionSide", optionSide.GetDescriptionFromEnum() } };

			return await executor.ExecuteAsync<IEnumerable<OptionResponse>>(urlPattern, pathNvc, qsb);
		}
	}
}
