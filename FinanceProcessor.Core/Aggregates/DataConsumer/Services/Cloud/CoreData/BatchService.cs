using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.IEXSharp.Model.CoreData.Batch.Request;
using AutoMapper;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.Batch.Response;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class BatchService : IBatchService
	{
		private readonly ILogger<BatchService> _logger;
		private IEXCloudClient _sandBoxClient;
		private readonly IMapper _mapper;

		public BatchService(ILogger<BatchService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_logger = logger;
			_mapper = mapper;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}


		public async Task<BatchDto> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types, ChartRange chartRange, int? last = null)
		{
			_logger.LogInformation("Start BatchBySymbolAsync");

			var response = await _sandBoxClient.Batch.BatchBySymbolAsync(symbol, types, chartRange, last);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<BatchDto>(response.Data);

			_logger.LogInformation("End BatchBySymbolAsync");

			return result;
		}

		public async Task<Dictionary<string, BatchDto>> BatchByMarketAsync(IEnumerable<string> symbols, IEnumerable<BatchType> types, ChartRange chartRange, int? last = null)
		{
			_logger.LogInformation("Start BatchByMarketAsync");

			var response = await _sandBoxClient.Batch.BatchByMarketAsync(symbols, types, chartRange, last);

			if (response?.Data == null)
				return null;

			var result = Map(response?.Data);

			_logger.LogInformation("End BatchByMarketAsync");

			return result;
		}

		private Dictionary<string, BatchDto> Map(Dictionary<string, BatchResponse> responses)
		{
			var collection = new Dictionary<string, BatchDto>();
			foreach (var response in responses)
				collection.Add(response.Key, _mapper.Map<BatchDto>(response.Value));

			return collection;
		}
	}
}
