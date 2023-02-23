using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.EconomicData.Request;
using AutoMapper;
using FinanceProcessor.Core.Aggregates.Caching;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FinanceProcessor.Core.Aggregates.DataConsumer.Loaders;
using FinanceProcessor.Core.Aggregates.Helper;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.EconomicData;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class EconomicDataService : IEconomicDataService
	{
		private readonly ILogger<EconomicDataService> _logger;
		private IEXCloudClient _sandBoxClient;
		private readonly IMapper _mapper;
		private readonly ICacheService _cacheService;

		public EconomicDataService(ILogger<EconomicDataService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper, ICacheService cacheService)
		{
			_logger = logger;
			_mapper = mapper;
			_cacheService = cacheService;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}

		public async Task<decimal> GetDataPointAsync(EconomicDataSymbol symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start DataPointAsync");

			var requestId = EconomicDataRequestIdConstants.GetDataPoint;

			var cacheKey = CacheKey.Create<decimal>($"{requestId}|{symbol.GetDescriptionFromEnum()}");

			var cachedValue = await _cacheService.GetAsync<decimal>(cacheKey, cancellationToken);

			if (cachedValue != default(decimal))
				return cachedValue;

			var response = await _sandBoxClient.EconomicData.DataPointAsync(symbol);

			if (response?.Data == null)
				return default(decimal);

			var result = response.Data;

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End DataPointAsync");

			return result;
		}

		public async Task<IEnumerable<TimeSeriesDto>> GetTimeSeriesAsync(EconomicDataTimeSeriesSymbol symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start TimeSeriesAsync");

			var requestId = EconomicDataRequestIdConstants.GetTimeSeries;

			var cacheKey = CacheKey.Create<TimeSeriesDto>($"{requestId}|{symbol.GetDescriptionFromEnum()}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<TimeSeriesDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.EconomicData.TimeSeriesAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<TimeSeriesDto>();

			var result = _mapper.Map<List<TimeSeriesDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End TimeSeriesAsync");

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
