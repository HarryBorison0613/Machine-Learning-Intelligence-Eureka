using FinanceProcessor.Core.Models;
using Microsoft.AspNetCore.Mvc;
using ICoreStockProfilesService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.IStockProfilesService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class StockProfilesController
	{
		private readonly ICoreStockProfilesService _coreStockProfilesService;
		private readonly ILogger<StockProfilesController> _logger;

		public StockProfilesController(ICoreStockProfilesService coreStockProfilesService, ILogger<StockProfilesController> logger)
		{
			_coreStockProfilesService = coreStockProfilesService;
			_logger = logger;
		}

		[HttpGet("company")]
		public Task<CompanyDto> GetCompanyAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockProfilesService.GetCompanyAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockProfilesService));
			}

			return null;
		}

		[HttpGet("insiderRoster")]
		public Task<IEnumerable<InsiderRosterDto>> GetInsiderRosterAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockProfilesService.GetInsiderRosterAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockProfilesService));
			}

			return null;
		}

		[HttpGet("insiderSummary")]
		public Task<IEnumerable<InsiderSummaryDto>> GetInsiderSummaryAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockProfilesService.GetInsiderSummaryAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockProfilesService));
			}

			return null;
		}

		[HttpGet("insiderTransactionsAsync")]
		public Task<IEnumerable<InsiderTransactionDto>> GetInsiderTransactionsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockProfilesService.GetInsiderTransactionsAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockProfilesService));
			}

			return null;
		}

		[HttpGet("logo")]
		public Task<LogoDto> GetLogoAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockProfilesService.GetLogoAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockProfilesService));
			}

			return null;
		}

		[HttpGet("peerGroups")]
		public Task<IEnumerable<string>> GetPeerGroupsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreStockProfilesService.GetPeerGroupsAsync(symbol, cancellationToken);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockProfilesService));
			}

			return null;
		}
	}
}
