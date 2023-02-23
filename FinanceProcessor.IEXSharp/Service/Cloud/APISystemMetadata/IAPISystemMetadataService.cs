using FinanceProcessor.IEXSharp.Model;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Model.APISystemMetadata.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.APISystemMetadata
{
	public interface IAPISystemMetadataService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#status"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<StatusResponse>> StatusAsync();
	}
}