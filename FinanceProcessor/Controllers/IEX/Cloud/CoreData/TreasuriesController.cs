using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.Treasuries.Request;
using Microsoft.AspNetCore.Mvc;
using ICoreTreasuriesService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.ITreasuriesService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class TreasuriesController
	{
		private readonly ICoreTreasuriesService _coreTreasuriesService;
		private readonly ILogger<TreasuriesController> _logger;

		public TreasuriesController(ICoreTreasuriesService coreTreasuriesService, ILogger<TreasuriesController> logger)
		{
			_coreTreasuriesService = coreTreasuriesService;
			_logger = logger;
		}

		[HttpGet("dataPoints")]
		public Task<decimal> GetDataPointAsync(TreasuryRateSymbol symbol, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreTreasuriesService.GetDataPointAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreTreasuriesService));
			}

			return null;
		}

		[HttpGet("timeSeries")]
		public Task<IEnumerable<TimeSeriesDto>> GetTimeSeriesAsync(TreasuryRateSymbol symbol, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreTreasuriesService.GetTimeSeriesAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreTreasuriesService));
			}

			return null;
		}
	}
}
