using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.Batch.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request;
using Microsoft.AspNetCore.Mvc;

using ICoreBatchService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.IBatchService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class BatchController
	{
		private readonly ICoreBatchService _coreBatchService;
		private readonly ILogger<BatchController> _logger;

		public BatchController(ICoreBatchService coreBatchService, ILogger<BatchController> logger)
		{
			_coreBatchService = coreBatchService;
			_logger = logger;
		}

		[HttpPost("batchBySymbol")]
		public Task<BatchDto> GetBatchBySymbolAsync(string symbol, [FromQuery] IEnumerable<BatchType> types, ChartRange chartRange, int? last = null)
		{
			try
			{
				return _coreBatchService.BatchBySymbolAsync(symbol, types, chartRange, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreBatchService));
			}

			return null;
		}

		[HttpPost("batchByMarket")]
		public Task<Dictionary<string, BatchDto>> BatchByMarketAsync([FromQuery] IEnumerable<string> symbols, [FromQuery] IEnumerable<BatchType> types, ChartRange chartRange, int? last = null)
		{
			try
			{
				return _coreBatchService.BatchByMarketAsync(symbols, types, chartRange, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreBatchService));
			}

			return null;
		}
	}
}
