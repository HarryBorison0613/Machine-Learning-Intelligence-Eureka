using FinanceProcessor.Core.Models;
using Microsoft.AspNetCore.Mvc;

using ICoreForexCurrenciesService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.IForexCurrenciesService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class ForexCurrenciesController
	{
		private readonly ICoreForexCurrenciesService _coreForexCurrenciesServic;
		private readonly ILogger<ForexCurrenciesController> _logger;

		public ForexCurrenciesController(ICoreForexCurrenciesService coreForexCurrenciesServic, ILogger<ForexCurrenciesController> logger)
		{
			_coreForexCurrenciesServic = coreForexCurrenciesServic;
			_logger = logger;
		}

		[HttpGet("exchangeRateAsync")]
		public Task<ExchangeRateDto> GetExchangeRateAsync(string fromForexCurrency, string toForexCurrency)
		{
			try
			{
				return _coreForexCurrenciesServic.GetExchangeRateAsync(fromForexCurrency, toForexCurrency);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreForexCurrenciesService));
			}

			return null;
		}

		[HttpGet("latestRates")]
		public Task<IEnumerable<CurrencyRateDto>> GetLatestRatesAsync(string forexSymbols)
		{
			try
			{
				return _coreForexCurrenciesServic.GetLatestRatesAsync(forexSymbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreForexCurrenciesService));
			}

			return null;
		}

		[HttpGet("convert")]
		public Task<IEnumerable<CurrencyConvertDto>> ConvertAsync(string forexSymbols, string amount)
		{
			try
			{
				return _coreForexCurrenciesServic.ConvertAsync(forexSymbols, amount);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreForexCurrenciesService));
			}

			return null;
		}

		[HttpGet("historicalDaily")]
		public Task<IEnumerable<IEnumerable<CurrencyHistoricalRateDto>>> GetHistoricalDailyAsync(string forexSymbols, string fromDate, string toDate, int last)
		{
			try
			{
				return _coreForexCurrenciesServic.GetHistoricalDailyAsync(forexSymbols, fromDate, toDate, last);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreForexCurrenciesService));
			}

			return null;
		}
	}
}
