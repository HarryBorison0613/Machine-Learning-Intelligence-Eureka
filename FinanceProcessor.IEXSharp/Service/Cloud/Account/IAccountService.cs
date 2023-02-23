using FinanceProcessor.IEXSharp.Model;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Model.Account.Request;
using FinanceProcessor.IEXSharp.Model.Account.Response;
using System.Collections.Generic;

namespace FinanceProcessor.IEXSharp.Service.Cloud.Account
{
	public interface IAccountService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#metadata"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<MetadataResponse>> MetadataAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#usage"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<UsageResponse>> UsageAsync(UsageType type);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#usage"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<MessageUsageResponse>> MessageUsageAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#pay-as-you-go"/>
		/// </summary>
		Task PayAsYouGoAsync(bool allow);
	}
}