using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.StockFundamentals.Request;
using FinanceProcessor.IEXSharp.Model.Shared.Request;
using Microsoft.AspNetCore.Mvc;
using ICoreStockFundamentalsService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.IStockFundamentalsService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class StockFundamentalsController : Controller
	{
		private readonly ICoreStockFundamentalsService _coreStockFundamentalsService;
		private readonly ILogger<MarketInfoController> _logger;

		public StockFundamentalsController(ICoreStockFundamentalsService coreStockFundamentalsService, ILogger<MarketInfoController> logger)
		{
			_coreStockFundamentalsService = coreStockFundamentalsService;
			_logger = logger;
		}

		[HttpGet("advancedFundamentals")]
		public Task<IEnumerable<AdvancedFundamentalsDto>> GetAdvancedFundamentalsAsync(string symbol, TimeSeriesPeriod timeSeriesPeriod)
		{
			try
			{
				return _coreStockFundamentalsService.GetAdvancedFundamentalsAsync(symbol, timeSeriesPeriod);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("fundamentalValuations")]
		public Task<IEnumerable<FundamentalValuationsDto>> GetFundamentalValuationsAsync(string symbol, TimeSeriesPeriod timeSeriesPeriod)
		{
			try
			{
				return _coreStockFundamentalsService.GetFundamentalValuationsAsync(symbol, timeSeriesPeriod);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("balanceSheet")]
		public Task<BalanceSheetDto> GetBalanceSheetAsync(string symbol, Period period, int last = 1)
		{
			try
			{
				return _coreStockFundamentalsService.GetBalanceSheetAsync(symbol, period, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("balanceSheetField")]
		public Task<string> GetBalanceSheetFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1)
		{
			try
			{
				return _coreStockFundamentalsService.GetBalanceSheetFieldAsync(symbol, field, period, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("cashFlow")]
		public Task<CashFlowsDto> GetCashFlowAsync(string symbol, Period period = Period.Quarter, int last = 1)
		{
			try
			{
				return _coreStockFundamentalsService.GetCashFlowAsync(symbol, period, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("cashFlowField")]
		public Task<string> GetCashFlowFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1)
		{
			try
			{
				return _coreStockFundamentalsService.GetCashFlowFieldAsync(symbol, field, period, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("dividendsBasic")]
		public Task<IEnumerable<DividendBasicDto>> GetDividendsBasicAsync(string symbol, DividendRange range)
		{
			try
			{
				return _coreStockFundamentalsService.GetDividendsBasicAsync(symbol, range);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("earning")]
		public Task<EarningDto> GetEarningAsync(string symbol, int last = 1)
		{
			try
			{
				return _coreStockFundamentalsService.GetEarningAsync(symbol, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("earningField")]
		public Task<string> GetEarningFieldAsync(string symbol, string field, int last = 1)
		{
			try
			{
				return _coreStockFundamentalsService.GetEarningFieldAsync(symbol, field, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("financial")]
		public Task<FinancialDto> GetFinancialAsync(string symbol, int last = 1)
		{
			try
			{
				return _coreStockFundamentalsService.GetFinancialAsync(symbol, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("financialField")]
		public Task<string> GetFinancialFieldAsync(string symbol, string field, int last = 1)
		{
			try
			{
				return _coreStockFundamentalsService.GetFinancialFieldAsync(symbol, field, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("incomeStatement")]
		public Task<IncomeStatementDto> GetIncomeStatementAsync(string symbol, Period period = Period.Quarter,
			int last = 1)
		{
			try
			{
				return _coreStockFundamentalsService.GetIncomeStatementAsync(symbol, period, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("incomeStatementField")]
		public Task<string> GetIncomeStatementFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1)
		{
			try
			{
				return _coreStockFundamentalsService.GetIncomeStatementFieldAsync(symbol, field, period, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("reportedFinancials")]
		public Task<IEnumerable<ReportedFinancialDto>> GetReportedFinancialsAsync(string symbol, Filing filing = Filing.Quarterly)
		{
			try
			{
				return _coreStockFundamentalsService.GetReportedFinancialsAsync(symbol, filing);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}

		[HttpGet("splitsBasic")]
		public Task<IEnumerable<SplitBasicDto>> GetSplitsBasicAsync(string symbol, SplitRange range = SplitRange.OneMonth)
		{
			try
			{
				return _coreStockFundamentalsService.GetSplitsBasicAsync(symbol, range);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockFundamentalsService));
			}

			return null;
		}
	}
}
