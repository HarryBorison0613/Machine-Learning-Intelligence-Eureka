using FinanceProcessor.Core.Models;
using Microsoft.AspNetCore.Mvc;
using ICoreCeoCompensationService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.ICeoCompensationService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class CeoCompensationController
	{
		private readonly ICoreCeoCompensationService _coreCeoCompensationService;
		private readonly ILogger<CeoCompensationController> _logger;

		public CeoCompensationController(ICoreCeoCompensationService coreCeoCompensationService, ILogger<CeoCompensationController> logger)
		{
			_coreCeoCompensationService = coreCeoCompensationService;
			_logger = logger;
		}

		[HttpGet("ceoCompensation")]
		public Task<CeoCompensationDto> GetCeoCompensationAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCeoCompensationService.GetCeoCompensationAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCeoCompensationService));
			}

			return null;
		}
	}
}
