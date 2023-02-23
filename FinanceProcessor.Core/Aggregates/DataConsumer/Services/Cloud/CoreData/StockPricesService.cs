using AutoMapper;
using FinanceProcessor.Core.Aggregates.Caching;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.StockPrices;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Aggregates.DataConsumer.Loaders;
using FinanceProcessor.Core.Aggregates.Helper;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request;
using FinanceProcessor.IEXSharp.Model.Shared.Response;
using FinanceProcessor.IEXSharp.Options;
using FinanceProcessor.MongoDB.Contracts.Entities;
using FinanceProcessor.MongoDB.Contracts.Repositories;
using FinanceProcessor.MongoDB.Contracts.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class StockPricesService : IStockPricesService
	{
		private readonly ILogger<StockPricesService> _logger;
		private readonly IIntradayPriceRepository _db;
		private IEXCloudClient _sandBoxClient;
		private readonly IMapper _mapper;
		private readonly ICacheService _cacheService;

		public StockPricesService(IDataService ds, ILogger<StockPricesService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper, ICacheService cacheService)
		{
			_db = ds.IntradayPrices;
			_logger = logger;
			_mapper = mapper;
			_cacheService = cacheService;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}

		public async Task<Dictionary<string, IntradayPriceDto[]>> GetIntradayPricesForMostPopularSymbol(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetMostPopularSymbolIntradayPrices");

			var tasks = new List<Task<IEnumerable<IntradayPrice>>>();

			foreach (var symbol in Symbols.PopularSymbols)
			{
				var task = _db.GetIntradayPricesBySymbolAsync(symbol);
				tasks.Add(task);
			}

			await Task.WhenAll(tasks);

			var intradayPrices = tasks
				.Where(t => t.IsCompletedSuccessfully)
				.SelectMany(t => _mapper.Map<IEnumerable<IntradayPriceDto>>(t.Result))
				.GroupBy(x => x.Symbol)
				.ToDictionary(g => g.Key, g => g.Select(x => x)
				.ToArray());

			return intradayPrices;
		}

		public async Task<IEnumerable<IntradayPriceDto>> GetIntradayPricesAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetIntradayPricesAsync");

			var requestId = StockPricesRequestIdConstants.GetIntradayPrices;

			var cacheKey = CacheKey.Create<IntradayPriceDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<IntradayPriceDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockPrices.IntradayPricesAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<IntradayPriceDto>();

			var result = _mapper.Map<List<IntradayPriceDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetIntradayPricesAsync");

			return result;
		}

		public async Task<IEnumerable<HistoricalPriceDto>> GetHistoricalPriceAsync(string symbol, ChartRange range = ChartRange.OneMonth, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetHistoricalPriceAsync");

			var requestId = StockPricesRequestIdConstants.GetHistoricalPrice;

			var cacheKey = CacheKey.Create<HistoricalPriceDto>($"{requestId}|{symbol}|{range.GetDescriptionFromEnum()}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<HistoricalPriceDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockPrices.HistoricalPriceAsync(symbol, range);

			if (response?.Data.Any() != true)
				return Array.Empty<HistoricalPriceDto>();

			var result = _mapper.Map<List<HistoricalPriceDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetHistoricalPriceAsync");

			return result;
		}

		public async Task<IEnumerable<IntradayPriceDto>> GetHistoricalPriceByDateAsync(string symbol, DateTime date, bool chartByDay = false, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetHistoricalPriceByDateAsync");

			var requestId = StockPricesRequestIdConstants.GetHistoricalPriceByDate;

			var cacheKey = CacheKey.Create<IntradayPriceDto>($"{requestId}|{symbol}{date.Date}|{chartByDay}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<IntradayPriceDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockPrices.HistoricalPriceByDateAsync(symbol, date, chartByDay);

			if (response?.Data.Any() != true)
				return Array.Empty<IntradayPriceDto>();

			var result = _mapper.Map<List<IntradayPriceDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetHistoricalPriceByDateAsync");

			return result;
		}

		public async Task<HistoricalPriceDynamicDto> GetHistoricalPriceDynamicAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetHistoricalPriceDynamicAsync");

			var requestId = StockPricesRequestIdConstants.GetHistoricalPriceDynamic;

			var cacheKey = CacheKey.Create<HistoricalPriceDynamicDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<HistoricalPriceDynamicDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockPrices.HistoricalPriceDynamicAsync(symbol);

			if (response?.Data?.data.Any() != true)
				return new HistoricalPriceDynamicDto();


			var result = new HistoricalPriceDynamicDto
			{
				HistoricalPriceDtos = _mapper.Map<List<IntradayPriceDto>>(response.Data.data),
				Range = response.Data.range
			};

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetHistoricalPriceDynamicAsync");

			return result;
		}

		public async Task<BookDto> GetBookAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetBookAsync");

			var requestId = StockPricesRequestIdConstants.GetBook;

			var cacheKey = CacheKey.Create<BookDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<BookDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockPrices.BookAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<BookDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetBookAsync");

			return result;
		}

		public async Task<DelayedQuoteDto> GetDelayedQuoteAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetDelayedQuoteAsync");

			var requestId = StockPricesRequestIdConstants.GetDelayedQuote;

			var cacheKey = CacheKey.Create<DelayedQuoteDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<DelayedQuoteDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockPrices.DelayedQuoteAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<DelayedQuoteDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetDelayedQuoteAsync");

			return result;
		}

		public async Task<IEnumerable<LargestTradeDto>> GetLargestTradesAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetLargestTradesAsync");

			var requestId = StockPricesRequestIdConstants.GetLargestTrades;

			var cacheKey = CacheKey.Create<LargestTradeDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<LargestTradeDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockPrices.LargestTradesAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<LargestTradeDto>();

			var result = _mapper.Map<IEnumerable<LargestTradeDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetLargestTradesAsync");

			return result;
		}

		public async Task<OHLCDto> GetOHLCAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetOHLCAsync");

			var requestId = StockPricesRequestIdConstants.GetOHLC;

			var cacheKey = CacheKey.Create<OHLCDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<OHLCDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockPrices.OHLCAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<OHLCDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetOHLCAsync");

			return result;
		}

		public async Task<HistoricalPriceDto> GetPreviousDayPriceAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetPreviousDayPriceAsync");

			var requestId = StockPricesRequestIdConstants.GetPreviousDayPrice;

			var cacheKey = CacheKey.Create<HistoricalPriceDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<HistoricalPriceDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockPrices.PreviousDayPriceAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<HistoricalPriceDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetPreviousDayPriceAsync");

			return result;
		}

		public async Task<decimal> GetPriceAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetPriceAsync");

			var requestId = StockPricesRequestIdConstants.GetPrice;

			var cacheKey = CacheKey.Create<decimal>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<decimal>(cacheKey, cancellationToken);

			if (cachedValue != default(decimal))
				return cachedValue;

			var response = await _sandBoxClient.StockPrices.PriceAsync(symbol);

			if (response?.Data == null)
				return default(decimal);

			var result = response.Data;

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetPriceAsync");

			return result;
		}

		public async Task<QuoteDto> GetQuoteAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetQuoteAsync");

			var requestId = StockPricesRequestIdConstants.GetQuote;

			var cacheKey = CacheKey.Create<QuoteDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<QuoteDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockPrices.QuoteAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<QuoteDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetQuoteAsync");

			return result;
		}

		public async Task<string> GetQuoteFieldAsync(string symbol, string field, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetQuoteFieldAsync");

			var requestId = StockPricesRequestIdConstants.GetQuoteField;

			var cacheKey = CacheKey.Create<string>($"{requestId}|{symbol}|{field}");

			var cachedValue = await _cacheService.GetAsync<string>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockPrices.QuoteFieldAsync(symbol, field);

			if (string.IsNullOrWhiteSpace(response?.Data))
				return string.Empty;

			var result = response.Data;

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetQuoteFieldAsync");

			return result;
		}

		public async Task<IEnumerable<VolumeByVenueDto>> GetVolumeByVenueAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetVolumeByVenueAsync");

			var requestId = StockPricesRequestIdConstants.GetVolumeByVenue;

			var cacheKey = CacheKey.Create<VolumeByVenueDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<VolumeByVenueDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockPrices.VolumeByVenueAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<VolumeByVenueDto>();

			var result = _mapper.Map<List<VolumeByVenueDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetVolumeByVenueAsync");

			return result;
		}

		public async Task<IEnumerable<QuoteSSEDto>> GetQuoteStream(IEnumerable<string> symbols, bool UTP, StockQuoteSSEInterval interval, CancellationToken cancellationToken = default)
		{
			var quoteResponse = new List<QuoteSSE>();

			var requestId = StockPricesRequestIdConstants.GetQuoteStream;

			var cacheKey = CacheKey.Create<QuoteSSEDto>($"{requestId}|{string.Join("|", symbols)}|{UTP}|{interval.GetDescriptionFromEnum()}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<QuoteSSEDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			_logger.LogInformation("Start QuoteStream");
			using var sseClient = _sandBoxClient.StockPrices.QuoteStream(symbols, UTP, interval);
			sseClient.Error += (s, e) =>
			{
				sseClient.Close();
			};
			sseClient.MessageReceived += (s, m) =>
			{
				quoteResponse = m.ToList();
				sseClient.Close();
			};
			await sseClient.StartAsync();

			var result = _mapper.Map<List<QuoteSSEDto>>(quoteResponse);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End QuoteStream");

			return result;
		}

		private async void SetCacheAsync<T>(CacheKey key, T item, string requestId, DateTime now, CancellationToken cancellationToken = default)
		{
			var expirationDate = RequestUpdateSchedule.GetClosestDateToUpdate(requestId, now);

			var cacheOptions = new CacheOptions(expirationDate);

			await _cacheService.SetAsync(
				key,
				item,
				cacheOptions,
				cancellationToken);
		}
	}
}
