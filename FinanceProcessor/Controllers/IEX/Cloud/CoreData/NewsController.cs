using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.CorporateActions.Request;
using Microsoft.AspNetCore.Mvc;

using ICoreNewsService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.INewsService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class NewsController : Controller
	{
		private readonly ICoreNewsService _newsServiceCore;
		private readonly ILogger<StockPricesController> _logger;

		public NewsController(ICoreNewsService stockPricesServiceCore, ILogger<StockPricesController> logger)
		{
			_newsServiceCore = stockPricesServiceCore;
			_logger = logger;
		}

		[HttpGet("lastNewsForMostPopularSymbols")]
		public Task<Dictionary<string, NewsDto[]>> GetLastNewsForMostPopularSymbolsAsync()
		{
			try
			{
				return _newsServiceCore.GetLastNewsForMostPopularSymbolsAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreNewsService));
			}

			return null;
		}

		[HttpGet("intradayNewsAsync")]
		public Task<IEnumerable<NewsDto>> GetIntradayNewsAsync(string symbol, int last = 1)
		{
			try
			{
				return _newsServiceCore.GetIntradayNewsAsync(symbol, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreNewsService));
			}

			return null;
		}

		[HttpGet("historicalNews")]
		public Task<IEnumerable<NewsDto>> GetHistoricalNewsAsync(string symbol, TimeSeriesRange? timeSeriesRange = null, int? limit = null)
		{
			try
			{
				return _newsServiceCore.GetHistoricalNewsAsync(symbol, timeSeriesRange, limit);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreNewsService));
			}

			return null;
		}

		[HttpPost("newsStream")]
		public Task<IEnumerable<NewsDto>> GetNewsStreamAsync([FromBody] IEnumerable<string> symbols)
		{
			try
			{
				return _newsServiceCore.GetNewsStreamAsync(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreNewsService));
			}

			return null;
		}
	}
}
