using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.Commodities.Request;
using Microsoft.AspNetCore.Mvc;
using ICoreCommoditiesService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.ICommoditiesService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class CommoditiesController
	{
		private readonly ICoreCommoditiesService _coreCommoditiesService;
		private readonly ILogger<CommoditiesController> _logger;

		public CommoditiesController(ICoreCommoditiesService coreCommoditiesService, ILogger<CommoditiesController> logger)
		{
			_coreCommoditiesService = coreCommoditiesService;
			_logger = logger;
		}

		[HttpGet("dataPoints")]
		public Task<decimal> GetDataPointAsync(CommoditySymbol symbol, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreCommoditiesService.GetDataPointAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCommoditiesService));
			}

			return null;
		}

		[HttpGet("timeSeries")]
		public Task<IEnumerable<TimeSeriesDto>> GetTimeSeriesAsync(CommoditySymbol symbol, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreCommoditiesService.GetTimeSeriesAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCommoditiesService));
			}

			return null;
		}
	}
}
