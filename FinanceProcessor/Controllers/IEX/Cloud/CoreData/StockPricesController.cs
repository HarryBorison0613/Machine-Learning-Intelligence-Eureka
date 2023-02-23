using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request;
using Microsoft.AspNetCore.Mvc;

using ICoreStockPricesService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.IStockPricesService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class StockPricesController : Controller
	{
		private readonly ICoreStockPricesService _stockPricesServiceCore;
		private readonly ILogger<StockPricesController> _logger;

		public StockPricesController(ICoreStockPricesService stockPricesServiceCore, ILogger<StockPricesController> logger)
		{
			_stockPricesServiceCore = stockPricesServiceCore;
			_logger = logger;
		}

		[HttpGet("intradayPricesForMostPopularSymbol")]
		public Task<Dictionary<string, IntradayPriceDto[]>> GetIntradayPricesForMostPopularSymbol()
		{
			try
			{
				return _stockPricesServiceCore.GetIntradayPricesForMostPopularSymbol();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpGet("intradayPrices")]
		public Task<IEnumerable<IntradayPriceDto>> GetIntradayPricesAsync(string symbol)
		{
			try
			{
				return _stockPricesServiceCore.GetIntradayPricesAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpGet("historicalPriceByDate")]
		public Task<IEnumerable<IntradayPriceDto>> GetHistoricalPriceByDateAsync(string symbol, DateTime dateTime)
		{
			try
			{
				return _stockPricesServiceCore.GetHistoricalPriceByDateAsync(symbol, dateTime);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpGet("historicalPrice")]
		public Task<IEnumerable<HistoricalPriceDto>> GetHistoricalPriceAsync(string symbol, ChartRange chartRange)
		{
			try
			{
				return _stockPricesServiceCore.GetHistoricalPriceAsync(symbol, chartRange);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpGet("historicalPriceDynamic")]
		public Task<HistoricalPriceDynamicDto> GetHistoricalPriceDynamicAsync(string symbol)
		{
			try
			{
				return _stockPricesServiceCore.GetHistoricalPriceDynamicAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpGet("book")]
		public Task<BookDto> GetBookAsync(string symbol)
		{
			try
			{
				return _stockPricesServiceCore.GetBookAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpGet("delayedQuoteAsync")]
		public Task<DelayedQuoteDto> GetDelayedQuoteAsync(string symbol)
		{
			try
			{
				return _stockPricesServiceCore.GetDelayedQuoteAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpGet("largestTrades")]
		public Task<IEnumerable<LargestTradeDto>> GetLargestTradesAsync(string symbol)
		{
			try
			{
				return _stockPricesServiceCore.GetLargestTradesAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpGet("OHLC")]
		public Task<OHLCDto> GetOHLCAsync(string symbol)
		{
			try
			{
				return _stockPricesServiceCore.GetOHLCAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpGet("previousDayPrice")]
		public Task<HistoricalPriceDto> GetPreviousDayPriceAsync(string symbol)
		{
			try
			{
				return _stockPricesServiceCore.GetPreviousDayPriceAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpGet("price")]
		public Task<decimal> GetPriceAsync(string symbol)
		{
			try
			{
				return _stockPricesServiceCore.GetPriceAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpGet("quote")]
		public Task<QuoteDto> GetQuoteAsync(string symbol)
		{
			try
			{
				return _stockPricesServiceCore.GetQuoteAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpGet("quoteField")]
		public Task<string> GetQuoteFieldAsync(string symbol, string field)
		{
			try
			{
				return _stockPricesServiceCore.GetQuoteFieldAsync(symbol, field);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpGet("volumeByVenue")]
		public Task<IEnumerable<VolumeByVenueDto>> GetVolumeByVenueAsync(string symbol)
		{
			try
			{
				return _stockPricesServiceCore.GetVolumeByVenueAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}

		[HttpPost("quoteStream")]
		public Task<IEnumerable<QuoteSSEDto>> GetQuoteStream(IEnumerable<string> symbols, bool UTP, StockQuoteSSEInterval interval)
		{
			try
			{
				return _stockPricesServiceCore.GetQuoteStream(symbols, UTP, interval);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreStockPricesService));
			}

			return null;
		}
	}
}
