using FinanceProcessor.IEXSharp.Model;
using System.Threading.Tasks;
using FinanceProcessor.IEXSharp.Helper;
using FinanceProcessor.IEXSharp.Model.APISystemMetadata.Response;

namespace FinanceProcessor.IEXSharp.Service.Cloud.APISystemMetadata
{
	internal class APISystemMetadata : IAPISystemMetadataService
	{
		private readonly ExecutorREST executor;

		internal APISystemMetadata(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<StatusResponse>> StatusAsync() =>
			await executor.NoParamExecute<StatusResponse>("status");
	}
}