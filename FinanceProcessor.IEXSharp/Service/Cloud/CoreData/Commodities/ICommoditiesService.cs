using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.Commodities.Request;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.Commodities
{
	public interface ICommoditiesService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#commodities"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<decimal>> DataPointAsync(CommoditySymbol symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#commodities"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<TimeSeriesResponse>>> TimeSeriesAsync(CommoditySymbol symbol);
	}
}
