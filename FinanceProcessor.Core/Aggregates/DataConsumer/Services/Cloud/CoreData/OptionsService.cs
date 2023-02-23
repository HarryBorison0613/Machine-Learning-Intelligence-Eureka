using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using AutoMapper;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.Options.Request;
using FinanceProcessor.Core.Aggregates.Caching;
using FinanceProcessor.Core.Aggregates.DataConsumer.Loaders;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.Options;
using FinanceProcessor.Core.Aggregates.Helper;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class OptionsService : IOptionsService
	{
		private readonly ILogger<OptionsService> _logger;
		private IEXCloudClient _sandBoxClient;
		private readonly IMapper _mapper;
		private readonly ICacheService _cacheService;

		public OptionsService(ILogger<OptionsService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper, ICacheService cacheService)
		{
			_logger = logger;
			_mapper = mapper;
			_cacheService = cacheService;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}

		public async Task<IEnumerable<string>> GetOptionsAsync(string symbol, CancellationToken cancellationToken)
		{
			_logger.LogInformation("Start GetOptionsAsync");

			var requestId = OptionsRequestIdConstants.Options;

			var cacheKey = CacheKey.Create<string>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<string>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.Options.OptionsAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<IEnumerable<string>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetOptionsAsync");

			return result;
		}

		public async Task<IEnumerable<string>> GetOptionsWithExpirationAsync(string symbol, string expiration, CancellationToken cancellationToken)
		{
			_logger.LogInformation("Start GetOptionsWithExpirationAsync");

			var requestId = OptionsRequestIdConstants.OptionsWithExpiration;

			var cacheKey = CacheKey.Create<OptionDto>($"{requestId}|{symbol}|{expiration}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<string>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.Options.OptionsAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<IEnumerable<string>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetOptionsWithExpirationAsync");

			return result;
		}

		public async Task<IEnumerable<OptionDto>> GetOptionsWithOptionSideAsync(string symbol, string expiration, OptionSide optionSide, CancellationToken cancellationToken)
		{
			_logger.LogInformation("Start GetOptionsWithOptionSideAsync");

			var requestId = OptionsRequestIdConstants.OptionsWithOptionSide;

			var cacheKey = CacheKey.Create<OptionDto>($"{requestId}|{symbol}|{expiration}|{optionSide.GetDescriptionFromEnum()}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<OptionDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.Options.OptionsAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<IEnumerable<OptionDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetOptionsWithOptionSideAsync");

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
