using AutoMapper;
using FinanceProcessor.Core.Aggregates.Caching;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.ForexCurrencies;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Aggregates.DataConsumer.Loaders;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class ForexCurrenciesService : IForexCurrenciesService
	{
		private readonly ILogger<ForexCurrenciesService> _logger;
		private IEXCloudClient _sandBoxClient;
		private readonly IMapper _mapper;
		private readonly ICacheService _cacheService;

		public ForexCurrenciesService(ILogger<ForexCurrenciesService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper, ICacheService cacheService)
		{
			_logger = logger;
			_mapper = mapper;
			_cacheService = cacheService;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}

		public async Task<ExchangeRateDto> GetExchangeRateAsync(string fromCurrency, string toCurrency, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start ExchangeRateAsync");

			var requestId = ForexCurrenciesRequestIdConstants.GetExchangeRate;

			var cacheKey = CacheKey.Create<ExchangeRateDto>($"{requestId}|{fromCurrency}|{toCurrency}");

			var cachedValue = await _cacheService.GetAsync<ExchangeRateDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.ForexCurrencies.ExchangeRateAsync(fromCurrency, toCurrency);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<ExchangeRateDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End ExchangeRateAsync");

			return result;
		}

		public async Task<IEnumerable<CurrencyRateDto>> GetLatestRatesAsync(string symbols, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start LatestRatesAsync");

			var requestId = ForexCurrenciesRequestIdConstants.GetLatestRates;

			var cacheKey = CacheKey.Create<CurrencyRateDto>($"{requestId}|{symbols}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<CurrencyRateDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.ForexCurrencies.LatestRatesAsync(symbols);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<IEnumerable<CurrencyRateDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End LatestRatesAsync");

			return result;
		}

		public async Task<IEnumerable<CurrencyConvertDto>> ConvertAsync(string symbols, string amount, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start ConvertAsync");

			var requestId = ForexCurrenciesRequestIdConstants.Convert;

			var cacheKey = CacheKey.Create<CurrencyConvertDto>($"{requestId}|{symbols}|{amount}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<CurrencyConvertDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.ForexCurrencies.ConvertAsync(symbols, amount);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<IEnumerable<CurrencyConvertDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End ConvertAsync");

			return result;
		}

		public async Task<IEnumerable<IEnumerable<CurrencyHistoricalRateDto>>> GetHistoricalDailyAsync(string symbols, string from, string to, int last, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start HistoricalDailyAsync");

			var requestId = ForexCurrenciesRequestIdConstants.GetHistoricalDaily;

			var cacheKey = CacheKey.Create<CurrencyHistoricalRateDto>($"{requestId}|{symbols}|{from}|{to}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<IEnumerable<CurrencyHistoricalRateDto>>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.ForexCurrencies.HistoricalDailyAsync(symbols, from, to, last);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<IEnumerable<IEnumerable<CurrencyHistoricalRateDto>>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End HistoricalDailyAsync");

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
