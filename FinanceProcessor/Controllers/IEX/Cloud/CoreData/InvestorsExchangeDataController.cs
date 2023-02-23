using FinanceProcessor.Core.Models;
using Microsoft.AspNetCore.Mvc;
using ICoreInvestorsExchangeDataService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.IInvestorsExchangeDataService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class InvestorsExchangeDataController : Controller
	{
		private readonly ICoreInvestorsExchangeDataService _coreInvestorsExchangeDataService;
		private readonly ILogger<InvestorsExchangeDataController> _logger;

		public InvestorsExchangeDataController(ICoreInvestorsExchangeDataService coreInvestorsExchangeDataService, ILogger<InvestorsExchangeDataController> logger)
		{
			_coreInvestorsExchangeDataService = coreInvestorsExchangeDataService;
			_logger = logger;
		}

		[HttpPost("deep")]
		public Task<DeepDto> DeepAsync([FromQuery] IEnumerable<string> symbols, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.DeepAsync(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("deepAuction")]
		public Task<IEnumerable<DeepAuctionDto>> DeepAuctionAsync([FromQuery] IEnumerable<string> symbols, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.DeepAuctionAsync(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("deepBook")]
		public Task<IEnumerable<DeepBookDto>> DeepBookAsync([FromQuery] IEnumerable<string> symbols, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.DeepBookAsync(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("deepOperationHaltStatus")]
		public Task<IEnumerable<DeepOperationalHaltStatusDto>> DeepOperationHaltStatusAsync([FromQuery] IEnumerable<string> symbols, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.DeepOperationHaltStatusAsync(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("deepOfficialPrice")]
		public Task<IEnumerable<DeepOfficialPriceDto>> DeepOfficialPriceAsync([FromQuery] IEnumerable<string> symbols, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.DeepOfficialPriceAsync(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("deepSecurityEvent")]
		public Task<IEnumerable<DeepSecurityEventDto>> DeepSecurityEventAsync([FromQuery] IEnumerable<string> symbols, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.DeepSecurityEventAsync(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("deepShortSalePriceTestStatus")]
		public Task<IEnumerable<DeepShortSalePriceTestStatusDto>> DeepShortSalePriceTestStatusAsync([FromQuery] IEnumerable<string> symbols, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.DeepShortSalePriceTestStatusAsync(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("deepSystemEvent")]
		public Task<DeepSystemEventDto> DeepSystemEventAsync(CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.DeepSystemEventAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("deepTrade")]
		public Task<Dictionary<string, IEnumerable<DeepTradeDto>>> DeepTradeAsync([FromQuery] IEnumerable<string> symbols, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.DeepTradeAsync(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("deepTradeBreaks")]
		public Task<Dictionary<string, IEnumerable<DeepTradeDto>>> DeepTradeBreaksAsync([FromQuery] IEnumerable<string> symbols, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.DeepTradeBreaksAsync(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("deepTradingStatus")]
		public Task<IEnumerable<DeepTradingStatusDto>> DeepTradingStatusAsync([FromQuery] IEnumerable<string> symbols, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.DeepTradingStatusAsync(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}
		
		[HttpPost("last")]
		public Task<IEnumerable<LastDto>> LastAsync([FromQuery] IEnumerable<string> symbols, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.LastAsync(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("listedRegulationSHOThresholdSecuritiesList")]
		public Task<IEnumerable<ListedRegulationSHOThresholdSecuritiesListDto>> ListedRegulationSHOThresholdSecuritiesListAsync
			(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreInvestorsExchangeDataService.ListedRegulationSHOThresholdSecuritiesListAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("listedShortInterestList")]
		public Task<IEnumerable<ListedShortInterestListDto>> ListedShortInterestListAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreInvestorsExchangeDataService.ListedShortInterestListAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("statsHistoricalDailyByDate")]
		public Task<IEnumerable<StatsHisoricalDailyDto>> StatsHistoricalDailyByDateAsync(string date, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreInvestorsExchangeDataService.StatsHistoricalDailyByDateAsync(date);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("statsHistoricalDailyByLast")]
		public Task<IEnumerable<StatsHisoricalDailyDto>> StatsHistoricalDailyByLastAsync(int last, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreInvestorsExchangeDataService.StatsHistoricalDailyByLastAsync(last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("statsHistoricalSummary")]
		public Task<IEnumerable<StatsHistoricalSummaryDto>> StatsHistoricalSummaryAsync(DateTime? date = null, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.StatsHistoricalSummaryAsync(date);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("statsIntraday")]
		public Task<StatsIntradayDto> StatsIntradayAsync(CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.StatsIntradayAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("statsRecentAsync")]
		public Task<IEnumerable<StatsRecentDto>> StatsRecentAsync(CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreInvestorsExchangeDataService.StatsRecentAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("statsRecord")]
		public Task<StatsRecordDto> StatsRecordAsync(CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.StatsRecordAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}

		[HttpPost("tops")]
		public Task<IEnumerable<TOPSDto>> TOPSAsync([FromQuery] IEnumerable<string> symbols, CancellationToken cancellationToken = default) 
		{
			try
			{
				return _coreInvestorsExchangeDataService.TOPSAsync(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreInvestorsExchangeDataService));
			}

			return null;
		}
	}
}
