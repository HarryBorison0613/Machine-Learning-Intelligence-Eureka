using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Models;
using AutoMapper;
using FinanceProcessor.Core.Aggregates.Caching;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FinanceProcessor.Core.Aggregates.DataConsumer.Loaders;
using FinanceProcessor.Core.Aggregates.Helper;
using FinanceProcessor.IEXSharp.Model.CoreData.Futures.Request;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.Futures;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class FuturesService : IFuturesService
	{
		private readonly ILogger<FuturesService> _logger;
		private IEXCloudClient _sandBoxClient;
		private readonly IMapper _mapper;
		private readonly ICacheService _cacheService;

		public FuturesService(ILogger<FuturesService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper, ICacheService cacheService)
		{
			_logger = logger;
			_mapper = mapper;
			_cacheService = cacheService;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}
		public async Task<IEnumerable<FutureDto>> GetEndOfDayFuturesAsync(string contractSymbol, FuturesRange range, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetEndOfDayFuturesAsync");

			var requestId = FuturesRequestIdConstants.GetEndOfDayFutures;

			var cacheKey = CacheKey.Create<FutureDto>($"{requestId}|{contractSymbol}|{range.GetDescriptionFromEnum()}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<FutureDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.FuturesService.EndOfDayFutures(contractSymbol, range);

			if (response?.Data.Any() != true)
				return Array.Empty<FutureDto>();

			var result = _mapper.Map<List<FutureDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetEndOfDayFuturesAsync");

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
