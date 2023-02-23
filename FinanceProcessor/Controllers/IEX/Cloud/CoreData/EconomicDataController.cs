using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.EconomicData.Request;
using Microsoft.AspNetCore.Mvc;
using ICoreEconomicDataService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.IEconomicDataService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class EconomicDataController
	{
		private readonly ICoreEconomicDataService _coreEconomicDataService;
		private readonly ILogger<EconomicDataController> _logger;

		public EconomicDataController(ICoreEconomicDataService coreEconomicDataService, ILogger<EconomicDataController> logger)
		{
			_coreEconomicDataService = coreEconomicDataService;
			_logger = logger;
		}

		[HttpGet("dataPoints")]
		public Task<decimal> GetDataPointAsync(EconomicDataSymbol symbol, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreEconomicDataService.GetDataPointAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreEconomicDataService));
			}

			return null;
		}

		[HttpGet("timeSeries")]
		public Task<IEnumerable<TimeSeriesDto>> GetTimeSeriesAsync(EconomicDataTimeSeriesSymbol symbol, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreEconomicDataService.GetTimeSeriesAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreEconomicDataService));
			}

			return null;
		}
	}
}
