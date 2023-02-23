using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.Futures.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.Futures.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.Treasuries
{
	public interface IFuturesService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#futures"/>
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<FutureResponse>>> EndOfDayFutures(string contractSymbol, FuturesRange range);
	}
}
