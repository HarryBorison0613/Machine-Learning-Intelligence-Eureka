using AutoMapper;
using FinanceProcessor.Core.Aggregates.Caching;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.MarketInfo;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Aggregates.DataConsumer.Loaders;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Model.CoreData.MarketInfo.Request;
using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class MarketInfoService : IMarketInfoService
	{
		private readonly ILogger<StockPricesService> _logger;
		private IEXCloudClient _sandBoxClient;
		private readonly IMapper _mapper;
		private readonly ICacheService _cacheService;

		public MarketInfoService(ILogger<StockPricesService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper, ICacheService cacheService)
		{
			_logger = logger;
			_mapper = mapper;
			_cacheService = cacheService;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}

		public async Task<IEnumerable<QuoteDto>> GetCollectionsAsync(CollectionType collectionType, string collectionName, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetCollectionsAsync");

			var requestId = collectionType switch
			{
				CollectionType.Tag => MarketInfoRequestIdConstants.GetCollectionsTag,
				CollectionType.Sector => MarketInfoRequestIdConstants.GetCollectionsSector,
				CollectionType.List => MarketInfoRequestIdConstants.GetCollectionsList,
				_ => throw new NotImplementedException()
			};

			var cacheKey = CacheKey.Create<QuoteDto>($"{requestId}|{collectionName}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<QuoteDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.CollectionsAsync(collectionType, collectionName);

			if (response?.Data.Any() != true)
				return Array.Empty<QuoteDto>();

			var result = _mapper.Map<List<QuoteDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetCollectionsAsync");

			return result;
		}

		public async Task<IEnumerable<QuoteDto>> GetListAsync(ListType listType, bool displayPercent = false,
			int listLimit = 10, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetListAsync");

			var requestId = listType switch
			{
				ListType.MostActive => MarketInfoRequestIdConstants.GetListMostactive,
				ListType.Gainers => MarketInfoRequestIdConstants.GetListGainers,
				ListType.Losers => MarketInfoRequestIdConstants.GetListLosers,
				ListType.IexVolume => MarketInfoRequestIdConstants.GetListIexvolume,
				ListType.IexPercent => MarketInfoRequestIdConstants.GetListIexPercent,
				_ => throw new NotImplementedException()
			};

			var cacheKey = CacheKey.Create<QuoteDto>($"{requestId}|{displayPercent}|{listLimit}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<QuoteDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.ListAsync(listType, displayPercent,
			listLimit);

			if (response?.Data.Any() != true)
				return Array.Empty<QuoteDto>();

			var result = _mapper.Map<List<QuoteDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetListAsync");

			return result;
		}

		public async Task<IEnumerable<DividendDto>> GetUpcomingDividendsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetUpcomingDividendsAsync");

			var requestId = MarketInfoRequestIdConstants.GetUpcomingDividends;

			var cacheKey = CacheKey.Create<DividendDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<DividendDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.UpcomingDividendsAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<DividendDto>();

			var result = _mapper.Map<List<DividendDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetUpcomingDividendsAsync");

			return result;
		}

		public async Task<IEnumerable<UpcomingEarningsDto>> GetUpcomingEarningsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GeUpcomingEarningsAsync");

			var requestId = MarketInfoRequestIdConstants.GetUpcomingEarnings;

			var cacheKey = CacheKey.Create<UpcomingEarningsDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<UpcomingEarningsDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.UpcomingEarningsAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<UpcomingEarningsDto>();

			var result = _mapper.Map<List<UpcomingEarningsDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GeUpcomingEarningsAsync");

			return result;
		}

		public async Task<IEnumerable<SplitDto>> GetUpcomingSplitsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GeUpcomingSplitsAsync");

			var requestId = MarketInfoRequestIdConstants.GetUpcomingSplits;

			var cacheKey = CacheKey.Create<SplitDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<SplitDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.UpcomingSplitsAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<SplitDto>();

			var result = _mapper.Map<List<SplitDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GeUpcomingSplitsAsync");

			return result;
		}

		public async Task<UpcomingEventMarketDto> GetUpcomingEventsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetUpcomingEventsAsync");

			var requestId = MarketInfoRequestIdConstants.GetUpcomingEvents;

			var cacheKey = CacheKey.Create<UpcomingEventMarketDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<UpcomingEventMarketDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.UpcomingEventsAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<UpcomingEventMarketDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetUpcomingEventsAsync");

			return result;
		}

		public async Task<IPOCalendarDto> GetUpcomingIposAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GeUpcomingIposAsync");

			var requestId = MarketInfoRequestIdConstants.GetUpcomingIpos;

			var cacheKey = CacheKey.Create<IPOCalendarDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IPOCalendarDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.UpcomingIposAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<IPOCalendarDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GeUpcomingIposAsync");

			return result;
		}

		public async Task<IEnumerable<UpcomingEventMarketDto>> GetUpcomingEventMarketAsync(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetUpcomingEventMarketAsync");

			var requestId = MarketInfoRequestIdConstants.GetUpcomingEventMarket;

			var cacheKey = CacheKey.Create<UpcomingEventMarketDto>($"{requestId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<UpcomingEventMarketDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.UpcomingEventsMarketAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<UpcomingEventMarketDto>();

			var result = _mapper.Map<List<UpcomingEventMarketDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetUpcomingEventMarketAsync");

			return result;
		}

		public async Task<IEnumerable<UpcomingEarningsDto>> GetUpcomingEarningsMarketAsync(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetUpcomingEarningsMarketAsync");

			var requestId = MarketInfoRequestIdConstants.GetUpcomingEarningsMarket;

			var cacheKey = CacheKey.Create<UpcomingEarningsDto>($"{requestId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<UpcomingEarningsDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.UpcomingEarningsMarketAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<UpcomingEarningsDto>();

			var result = _mapper.Map<List<UpcomingEarningsDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetUpcomingEarningsMarketAsync");

			return result;
		}

		public async Task<IEnumerable<DividendDto>> GetUpcomingDividendsMarketAsync(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetUpcomingDividendsMarketAsync");

			var requestId = MarketInfoRequestIdConstants.GetUpcomingDividendsMarket;

			var cacheKey = CacheKey.Create<DividendDto>($"{requestId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<DividendDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.UpcomingDividendsMarketAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<DividendDto>();

			var result = _mapper.Map<List<DividendDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetUpcomingDividendsMarketAsync");

			return result;
		}

		public async Task<IEnumerable<SplitDto>> GetUpcomingSplitsMarketAsync(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetUpcomingSplitsMarketAsync");

			var requestId = MarketInfoRequestIdConstants.GetUpcomingSplitsMarket;

			var cacheKey = CacheKey.Create<SplitDto>($"{requestId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<SplitDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.UpcomingSplitsMarketAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<SplitDto>();

			var result = _mapper.Map<List<SplitDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetUpcomingSplitsMarketAsync");

			return result;
		}

		public async Task<IEnumerable<IPOCalendarDto>> GetUpcomingIposMarketAsync(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetUpcomingIPOsMarketAsync");

			var requestId = MarketInfoRequestIdConstants.GetUpcomingIPOsMarket;

			var cacheKey = CacheKey.Create<IPOCalendarDto>($"{requestId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<IPOCalendarDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.UpcomingIPOsMarketAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<IPOCalendarDto>();

			var result = _mapper.Map<IEnumerable<IPOCalendarDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetUpcomingIPOsMarketAsync");

			return result;
		}

		public async Task<IEnumerable<MarketVolumeUSDto>> GetMarketVolumeUSAsync(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetMarketVolumeUSAsync");

			var requestId = MarketInfoRequestIdConstants.GetMarketVolumeUS;

			var cacheKey = CacheKey.Create<MarketVolumeUSDto>($"{requestId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<MarketVolumeUSDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.MarketVolumeUSAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<MarketVolumeUSDto>();

			var result = _mapper.Map<List<MarketVolumeUSDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetMarketVolumeUSAsync");

			return result;
		}

		public async Task<IEnumerable<SectorPerformanceDto>> GetSectorPerformanceAsync(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetSectorPerformanceAsync");

			var requestId = MarketInfoRequestIdConstants.GetSectorPerformance;

			var cacheKey = CacheKey.Create<SectorPerformanceDto>($"{requestId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<SectorPerformanceDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.SectorPerformanceAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<SectorPerformanceDto>();

			var result = _mapper.Map<List<SectorPerformanceDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetSectorPerformanceAsync");

			return result;
		}

		public async Task<IEnumerable<IPOCalendarDto>> GetIPOCalendarAsync(IPOType ipoType, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetIPOCalendarAsync");

			var requestId = ipoType switch
			{
				IPOType.Today => MarketInfoRequestIdConstants.GetIPOCalendarTodayIpos,
				IPOType.Upcoming => MarketInfoRequestIdConstants.GetIPOCalendarUpcomingIpos,
				_ => throw new NotImplementedException()
			};

			var cacheKey = CacheKey.Create<IPOCalendarDto>($"{requestId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<IPOCalendarDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.IPOCalendarAsync(ipoType);

			if (response?.Data.Any() != true)
				return Array.Empty<IPOCalendarDto>();

			var result = _mapper.Map<IEnumerable<IPOCalendarDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetIPOCalendarAsync");

			return result;
		}

		// needs permission
		public async Task<IEnumerable<object>> GetEarningsTodayAsync(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetEarningsTodayAsync");

			var requestId = MarketInfoRequestIdConstants.GetEarningsToday;

			var cacheKey = CacheKey.Create<object>($"{requestId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<object>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.EarningsTodayAsync();

			if (response?.Data == null)
				return Array.Empty<object>();

			var result = _mapper.Map<List<object>>(response?.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetEarningsTodayAsync");

			return result;
		}

		public async Task<IEnumerable<MarketVolumeUSDto>> GetMarketAsync(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetMarketAsync");

			var requestId = MarketInfoRequestIdConstants.GetMarket;

			var cacheKey = CacheKey.Create<MarketVolumeUSDto>($"{requestId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<MarketVolumeUSDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.MarketInfoService.MarketAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<MarketVolumeUSDto>();

			var result = _mapper.Map<List<MarketVolumeUSDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetMarketAsync");

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
