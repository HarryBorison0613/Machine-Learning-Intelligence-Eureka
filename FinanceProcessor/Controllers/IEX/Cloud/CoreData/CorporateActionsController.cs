using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.CorporateActions.Request;
using Microsoft.AspNetCore.Mvc;
using ICoreCorporateActionsService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.ICorporateActionsService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class CorporateActionsController : Controller
	{
		private readonly ICoreCorporateActionsService _coreCorporateActionsService;
		private readonly ILogger<CorporateActionsController> _logger;

		public CorporateActionsController(ICoreCorporateActionsService coreCorporateActionsService, ILogger<CorporateActionsController> logger)
		{
			_coreCorporateActionsService = coreCorporateActionsService;
			_logger = logger;
		}

		[HttpGet("bonusIssue")]
		public Task<IEnumerable<BonusIssueDto>> GetBonusIssueAsync(
			string symbol,
			TimeSeriesRange? range = null,
			bool calendar = false,
			int? last = null,
			string? refId = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetBonusIssueAsync(symbol, range, calendar, last, refId);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("bonusIssueList")]
		public Task<IEnumerable<BonusIssueDto>> GetBonusIssueListAsync(
			TimeSeriesRange? range = null,
			bool calendar = false,
			int? last = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetBonusIssueAsync(string.Empty, range, calendar, last, string.Empty);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("distribution")]
		public Task<IEnumerable<DistributionDto>> GetDistributionAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string? refId = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetDistributionAsync(symbol, range, calendar, last, refId);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("distributionList")]
		public Task<IEnumerable<DistributionDto>> GetDistributionListAsync(
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetDistributionAsync(string.Empty, range, calendar, last, string.Empty);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("dividendsAdvanced")]
		public Task<IEnumerable<DividendAdvancedDto>> GetDividendsAdvancedAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string? refId = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetDividendsAdvancedAsync(symbol, range, calendar, last, refId);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("dividendsAdvancedList")]
		public Task<IEnumerable<DividendAdvancedDto>> GetDividendsAdvancedListAsync(
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetDividendsAdvancedAsync(string.Empty, range, calendar, last, string.Empty);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("returnOfCapital")]
		public Task<IEnumerable<ReturnOfCapitalDto>> GetReturnOfCapitalAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string? refId = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetReturnOfCapitalAsync(symbol, range, calendar, last, refId);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}


		[HttpGet("returnOfCapitalList")]
		public Task<IEnumerable<ReturnOfCapitalDto>> GetReturnOfCapitalListAsync(
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetReturnOfCapitalAsync(string.Empty, range, calendar, last, string.Empty);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("rightsIssue")]
		public Task<IEnumerable<RightsIssueDto>> GetRightsIssueAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string? refId = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetRightsIssueAsync(symbol, range, calendar, last, refId);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("rightsIssueList")]
		public Task<IEnumerable<RightsIssueDto>> GetRightsIssueListAsync(
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetRightsIssueAsync(string.Empty, range, calendar, last, string.Empty);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("rightToPurchase")]
		public Task<IEnumerable<RightToPurchaseDto>> GetRightToPurchaseAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string? refId = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetRightToPurchaseAsync(symbol, range, calendar, last, refId);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("rightToPurchaseList")]
		public Task<IEnumerable<RightToPurchaseDto>> GetRightToPurchaseListAsync(
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetRightToPurchaseAsync(string.Empty, range, calendar, last, string.Empty);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("securityReclassification")]
		public Task<IEnumerable<SecurityUpdateDto>> GetSecurityReclassificationAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string? refId = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetSecurityReclassificationAsync(symbol, range, calendar, last, refId);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("securityReclassificationList")]
		public Task<IEnumerable<SecurityUpdateDto>> GetSecurityReclassificationListAsync(
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetSecurityReclassificationAsync(string.Empty, range, calendar, last, string.Empty);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("securitySwap")]
		public Task<IEnumerable<SecurityUpdateDto>> GetSecuritySwapAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string? refId = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetSecuritySwapAsync(symbol, range, calendar, last, refId);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("spinOff")]
		public Task<IEnumerable<SpinOffDto>> GetSpinOffAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string? refId = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetSpinOffAsync(symbol, range, calendar, last, refId);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("splitsAdvanced")]
		public Task<IEnumerable<SplitAdvancedDto>> GetSplitsAdvancedAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string? refId = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetSplitsAdvancedAsync(symbol, range, calendar, last, refId);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("securitySwapList")]
		public Task<IEnumerable<SecurityUpdateDto>> GetSecuritySwapListAsync(
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetSecuritySwapAsync(string.Empty, range, calendar, last, string.Empty);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("spinOffList")]
		public Task<IEnumerable<SpinOffDto>> GetSpinOffListAsync(
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetSpinOffAsync(string.Empty, range, calendar, last, string.Empty);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("splitsAdvancedList")]
		public Task<IEnumerable<SplitAdvancedDto>> GetSplitsAdvancedListAsync(
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetSplitsAdvancedAsync(string.Empty, range, calendar, last, string.Empty);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

		[HttpGet("dividendsForecast")]
		public Task<IEnumerable<DividendForecastDto>> GetDividendsForecastAsync(
			string symbol,
			CancellationToken cancellationToken = default)
		{
			try
			{
				return _coreCorporateActionsService.GetDividendsForecastAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCorporateActionsService));
			}

			return null;
		}

	}
}
