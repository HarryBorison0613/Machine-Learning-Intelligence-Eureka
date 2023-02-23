using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.PremiumData.FraudFactors.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.PremiumData.FraudFactors
{
	public interface IFraudFactorsService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#similiarity-index"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<SimilarityIndexResponse>>> SimilarityIndexAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#non-timely-filings"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<NonTimelyFilingsResponse>>> NonTimelyFilingsAsync(string symbol);
	}
}
