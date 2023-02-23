using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.StockResearch.Request;
using FinanceProcessor.IEXSharp.Model.Shared.Request;
using Microsoft.AspNetCore.Mvc;
using ICoreStockResearchService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.IStockResearchService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class StockResearchController
	{
		private readonly ICoreStockResearchService _coreStockResearchService;
		private readonly ILogger<StockResearchController> _logger;

		public StockResearchController(ICoreStockResearchService coreStockResearchService, ILogger<StockResearchController> logger)
		{
			_coreStockResearchService = coreStockResearchService;
			_logger = logger;
		}

		[HttpGet("advancedStats")]
		public Task<AdvancedStatsDto> GetAdvancedStatsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockResearchService.GetAdvancedStatsAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockResearchService));
			}

			return null;
		}

		[HttpGet("analystRecommendations")]
		public Task<IEnumerable<AnalystRecommendationsDto>> GetAnalystRecommendationsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockResearchService.GetAnalystRecommendationsAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockResearchService));
			}

			return null;
		}

		[HttpGet("estimateField")]
		public Task<string> GetEstimateFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockResearchService.GetEstimateFieldAsync(symbol, field, period, last, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockResearchService));
			}

			return null;
		}

		[HttpGet("estimates")]
		public Task<EstimatesDto> GetEstimatesAsync(string symbol, Period period = Period.Quarter, int last = 1, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockResearchService.GetEstimatesAsync(symbol, period, last, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockResearchService));
			}

			return null;
		}

		[HttpGet("fundOwnership")]
		public Task<IEnumerable<FundOwnershipDto>> GetFundOwnershipAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockResearchService.GetFundOwnershipAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockResearchService));
			}

			return null;
		}

		[HttpGet("institutionalOwnerShip")]
		public Task<IEnumerable<InstitutionalOwnershipDto>> GetInstitutionalOwnerShipAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockResearchService.GetInstitutionalOwnerShipAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockResearchService));
			}

			return null;
		}

		[HttpGet("keyStats")]
		public Task<KeyStatsDto> GetKeyStatsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockResearchService.GetKeyStatsAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockResearchService));
			}

			return null;
		}

		[HttpGet("keyStatsStat")]
		public Task<string> GetKeyStatsStatAsync(string symbol, string stat, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockResearchService.GetKeyStatsStatAsync(symbol, stat, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockResearchService));
			}

			return null;
		}

		[HttpGet("relevantStocks")]
		public Task<RelevantStocksDto> GetRelevantStocksAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockResearchService.GetRelevantStocksAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockResearchService));
			}

			return null;
		}

		[HttpGet("priceTarget")]
		public Task<PriceTargetDto> GetPriceTargetAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockResearchService.GetPriceTargetAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockResearchService));
			}

			return null;
		}

		[HttpGet("technicalIndicators")]
		public Task<TechnicalIndicatorsDto> GetTechnicalIndicatorsAsync(string symbol, IndicatorName indicatorName, ChartRange range, bool lastIndicator = false, bool indicatorOnly = false, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockResearchService.GetTechnicalIndicatorsAsync(symbol, indicatorName, range, lastIndicator, indicatorOnly, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockResearchService));
			}

			return null;
		}
	}
}
