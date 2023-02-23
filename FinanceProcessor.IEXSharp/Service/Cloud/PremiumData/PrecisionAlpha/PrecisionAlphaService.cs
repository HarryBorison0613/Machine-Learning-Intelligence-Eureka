using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.PremiumData.PrecisionAlpha.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.PremiumData.PrecisionAlpha
{
	public class PrecisionAlphaService : IPrecisionAlphaService
	{
		private readonly ExecutorREST executor;

		internal PrecisionAlphaService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<PriceDynamicsResponse>>> PriceDynamicsAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<PriceDynamicsResponse>>($"time-series/PREMIUM_PRECISION_ALPHA_PRICE_DYNAMICS/{symbol}");
	}
}