using Microsoft.AspNetCore.Mvc;
using ICoreOptionsService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.IOptionsService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class OptionsController
	{
		private readonly ICoreOptionsService _coreOptionsService;
		private readonly ILogger<OptionsController> _logger;

		public OptionsController(ICoreOptionsService coreOptionsService, ILogger<OptionsController> logger)
		{
			_coreOptionsService = coreOptionsService;
			_logger = logger;
		}

		[HttpGet("options")]
		public Task<IEnumerable<string>> GetOptionsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreOptionsService.GetOptionsAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(OptionsController));
			}

			return null;
		}
	}
}
