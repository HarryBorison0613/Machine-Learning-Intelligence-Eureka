using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Model;
using FinanceProcessor.IEXSharp.Model.CoreData.CeoCompensation.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.CoreData.CeoCompensation
{
	public interface ICeoCompensationService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#ceo-compensation"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<CeoCompensationResponse>> CeoCompensationAsync(string symbol);
	}
}
