using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.Futures.Request;
using Microsoft.AspNetCore.Mvc;
using ICoreFuturesService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.IFuturesService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class FuturesController
	{
		private readonly ICoreFuturesService _coreFuturesService;
		private readonly ILogger<FuturesController> _logger;

		public FuturesController(ICoreFuturesService coreFuturesService, ILogger<FuturesController> logger)
		{
			_coreFuturesService = coreFuturesService;
			_logger = logger;
		}

		[HttpGet("futures")]
		public Task<IEnumerable<FutureDto>> GetEndOfDayFuturesAsync(string contractSymbol, FuturesRange range, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreFuturesService.GetEndOfDayFuturesAsync(contractSymbol, range, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(OptionsController));
			}

			return null;
		}
	}
}
