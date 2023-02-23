using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.PremiumData.PrecisionAlpha.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.PremiumData.PrecisionAlpha
{
	public interface IPrecisionAlphaService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#precision-alpha-price-dynamics" />
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<PriceDynamicsResponse>>> PriceDynamicsAsync(string symbol);
	}
}