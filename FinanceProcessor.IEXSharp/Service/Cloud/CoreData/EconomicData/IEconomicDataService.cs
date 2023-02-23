using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.EconomicData.Request;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.EconomicData
{
	public interface IEconomicDataService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#economic-data"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<decimal>> DataPointAsync(EconomicDataSymbol symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#economic-data"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<TimeSeriesResponse>>> TimeSeriesAsync(EconomicDataTimeSeriesSymbol symbol);
	}
}