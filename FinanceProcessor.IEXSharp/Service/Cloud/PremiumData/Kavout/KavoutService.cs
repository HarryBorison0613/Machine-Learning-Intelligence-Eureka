using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.PremiumData.Kavout.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.PremiumData.Kavout
{
	public class KavoutService : IKavoutService
	{
		private readonly ExecutorREST executor;

		internal KavoutService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<KavoutResponse>>> KScoreForUsEquitiesAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<KavoutResponse>>($"time-series/PREMIUM_KAVOUT_KSCORE/{symbol}");

		public async Task<IEXResponse<IEnumerable<KavoutResponse>>> KScoreForChinaASharesAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<KavoutResponse>>($"time-series/PREMIUM_KAVOUT_KSCORE_A_SHARES/{symbol}");
	}
}