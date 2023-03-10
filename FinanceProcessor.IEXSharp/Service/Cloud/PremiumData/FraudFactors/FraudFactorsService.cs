using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.PremiumData.FraudFactors.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.PremiumData.FraudFactors
{
	public class FraudFactorsService : IFraudFactorsService
	{
		private readonly ExecutorREST executor;

		internal FraudFactorsService(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> SimilarityIndexAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<SimilarityIndexResponse>>($"time-series/PREMIUM_FRAUD_FACTORS_SIMILARITY_INDEX/{symbol}");

		public async Task<IEXResponse<IEnumerable<NonTimelyFilingsResponse>>> NonTimelyFilingsAsync(string symbol) =>
			await executor.NoParamExecute<IEnumerable<NonTimelyFilingsResponse>>($"time-series/PREMIUM_FRAUD_FACTORS_NON_TIMELY_FILINGS/{symbol}");
	}
}