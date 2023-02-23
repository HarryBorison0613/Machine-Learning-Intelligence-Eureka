using FinanceProcessor.Core.Models;
using Microsoft.AspNetCore.Mvc;
using ICoreCryptoService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.ICryptoService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class CryptoController : Controller
	{
		private readonly ICoreCryptoService _coreCryptoService;
		private readonly ILogger<CryptoController> _logger;

		public CryptoController(ICoreCryptoService coreCryptoService, ILogger<CryptoController> logger)
		{
			_coreCryptoService = coreCryptoService;
			_logger = logger;
		}

		[HttpGet("cryptoCurrencyPrice")]
		public Task<CryptoPriceDto> GetCryptoPriceAsync(string symbol)
		{
			try
			{
				return _coreCryptoService.GetPriceAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCryptoService));
			}

			return null;
		}

		[HttpGet("cryptoCurrencyQuote")]
		public Task<QuoteCryptoDto> GetQuoteAsync(string symbol)
		{
			try
			{
				return _coreCryptoService.GetQuoteAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCryptoService));
			}

			return null;
		}

		[HttpGet("cryptoCurrencyBook")]
		public Task<CryptoBookDto> BookAsync(string symbol)
		{
			try
			{
				return _coreCryptoService.BookAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCryptoService));
			}

			return null;
		}

		[HttpPost("cryptoCurrencyBookStream")]
		public Task<List<CryptoBookDto>> BookStream([FromBody] List<string> symbols)
		{
			try
			{
				return _coreCryptoService.BookStream(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCryptoService));
			}

			return null;
		}

		[HttpPost("cryptoCurrencyQuoteStream")]
		public Task<List<QuoteCryptoDto>> GetQuoteStream([FromBody] List<string> symbols)
		{
			try
			{
				return _coreCryptoService.GetQuoteStream(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCryptoService));
			}

			return null;
		}

		[HttpPost("cryptoCurrencyEventStream")]
		public Task<List<EventCryptoDto>> GetEventStream([FromBody] IEnumerable<string> symbols)
		{
			try
			{
				return _coreCryptoService.GetEventStream(symbols);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreCryptoService));
			}

			return null;
		}
	}
}
