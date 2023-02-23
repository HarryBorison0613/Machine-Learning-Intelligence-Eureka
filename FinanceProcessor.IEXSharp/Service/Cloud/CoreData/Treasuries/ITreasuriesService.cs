using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.Treasuries.Request;
using FinanceProcessor.IEXSharp.Model.Shared.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.Treasuries
{
	public interface ITreasuriesService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#daily-treasury-rates"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<decimal>> DataPointAsync(TreasuryRateSymbol symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#daily-treasury-rates"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<TimeSeriesResponse>>> TimeSeriesAsync(TreasuryRateSymbol symbol);
	}
}
