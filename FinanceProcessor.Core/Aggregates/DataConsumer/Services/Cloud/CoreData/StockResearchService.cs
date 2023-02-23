using AutoMapper;
using FinanceProcessor.Core.Aggregates.Caching;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.StockResearch;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Aggregates.DataConsumer.Loaders;
using FinanceProcessor.Core.Aggregates.Helper;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Model.CoreData.StockPrices.Request;
using FinanceProcessor.IEXSharp.Model.CoreData.StockResearch.Request;
using FinanceProcessor.IEXSharp.Model.Shared.Request;
using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class StockResearchService : IStockResearchService
	{
		private readonly ILogger<StockResearchService> _logger;
		private IEXCloudClient _sandBoxClient;
		private readonly IMapper _mapper;
		private readonly ICacheService _cacheService;

		public StockResearchService(ILogger<StockResearchService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper, ICacheService cacheService)
		{
			_logger = logger;
			_mapper = mapper;
			_cacheService = cacheService;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}

		public async Task<AdvancedStatsDto> GetAdvancedStatsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetAdvancedStatsAsync");

			var requestId = StockResearchRequestIdConstants.GetAdvancedStats;

			var cacheKey = CacheKey.Create<AdvancedStatsDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<AdvancedStatsDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockResearch.AdvancedStatsAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<AdvancedStatsDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetAdvancedStatsAsync");

			return result;
		}

		public async Task<IEnumerable<AnalystRecommendationsDto>> GetAnalystRecommendationsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetAnalystRecommendationsAsync");

			var requestId = StockResearchRequestIdConstants.GetAnalystRecommendations;

			var cacheKey = CacheKey.Create<AnalystRecommendationsDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<AnalystRecommendationsDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockResearch.AnalystRecommendationsAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<AnalystRecommendationsDto>();

			var result = _mapper.Map<List<AnalystRecommendationsDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetAnalystRecommendationsAsync");

			return result;
		}

		public async Task<EstimatesDto> GetEstimatesAsync(string symbol, Period period = Period.Quarter, int last = 1, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetEstimatesAsync");

			var requestId = StockResearchRequestIdConstants.GetEstimates;

			var cacheKey = CacheKey.Create<EstimatesDto>($"{requestId}|{symbol}|{period.GetDescriptionFromEnum()}|{last}");

			var cachedValue = await _cacheService.GetAsync<EstimatesDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockResearch.EstimatesAsync(symbol, period, last);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<EstimatesDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetEstimatesAsync");

			return result;
		}

		public async Task<string> GetEstimateFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetEstimateFieldAsync");

			var requestId = StockResearchRequestIdConstants.GetEstimateField;

			var cacheKey = CacheKey.Create<string>($"{requestId}|{symbol}|{field}|{period.GetDescriptionFromEnum()}|{last}");

			var cachedValue = await _cacheService.GetAsync<string>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockResearch.EstimateFieldAsync(symbol, field, period, last);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<string>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetEstimateFieldAsync");

			return result;
		}

		public async Task<IEnumerable<FundOwnershipDto>> GetFundOwnershipAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetFundOwnershipAsync");

			var requestId = StockResearchRequestIdConstants.GetFundOwnership;

			var cacheKey = CacheKey.Create<FundOwnershipDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<FundOwnershipDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockResearch.FundOwnershipAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<FundOwnershipDto>();

			var result = _mapper.Map<List<FundOwnershipDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetFundOwnershipAsync");

			return result;
		}

		public async Task<IEnumerable<InstitutionalOwnershipDto>> GetInstitutionalOwnerShipAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetInstitutionalOwnerShipAsync");

			var requestId = StockResearchRequestIdConstants.GetInstitutionalOwnerShip;

			var cacheKey = CacheKey.Create<InstitutionalOwnershipDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<InstitutionalOwnershipDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockResearch.InstitutionalOwnerShipAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<InstitutionalOwnershipDto>();

			var result = _mapper.Map<List<InstitutionalOwnershipDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetInstitutionalOwnerShipAsync");

			return result;
		}

		public async Task<KeyStatsDto> GetKeyStatsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetKeyStatsAsync");

			var requestId = StockResearchRequestIdConstants.GetKeyStats;

			var cacheKey = CacheKey.Create<KeyStatsDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<KeyStatsDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockResearch.KeyStatsAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<KeyStatsDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetKeyStatsAsync");

			return result;
		}

		public async Task<string> GetKeyStatsStatAsync(string symbol, string stat, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetKeyStatsStatAsync");

			var requestId = StockResearchRequestIdConstants.GetKeyStatsStat;

			var cacheKey = CacheKey.Create<string>($"{requestId}|{symbol}|{stat}");

			var cachedValue = await _cacheService.GetAsync<string>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockResearch.KeyStatsStatAsync(symbol, stat);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<string>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetKeyStatsStatAsync");

			return result;
		}

		public async Task<PriceTargetDto> GetPriceTargetAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetPriceTargetAsync");

			var requestId = StockResearchRequestIdConstants.GetPriceTarget;

			var cacheKey = CacheKey.Create<PriceTargetDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<PriceTargetDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockResearch.PriceTargetAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<PriceTargetDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetPriceTargetAsync");

			return result;
		}

		public async Task<RelevantStocksDto> GetRelevantStocksAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetRelevantStocksAsync");

			var requestId = StockResearchRequestIdConstants.GetRelevantStocks;

			var cacheKey = CacheKey.Create<RelevantStocksDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<RelevantStocksDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockResearch.RelevantStocksAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<RelevantStocksDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetRelevantStocksAsync");

			return result;
		}

		public async Task<TechnicalIndicatorsDto> GetTechnicalIndicatorsAsync(string symbol, IndicatorName indicatorName, ChartRange range, bool lastIndicator = false, bool indicatorOnly = false, CancellationToken cancellationToken = default)
		{ 
			_logger.LogInformation("Start GetTechnicalIndicatorsAsync");

			var requestId = StockResearchRequestIdConstants.GetTechnicalIndicators;

			var cacheKey = CacheKey.Create<TechnicalIndicatorsDto>($"{requestId}|{symbol}|{indicatorName.GetDescriptionFromEnum()}|{range.GetDescriptionFromEnum()}|{lastIndicator}|{indicatorOnly}");

			var cachedValue = await _cacheService.GetAsync<TechnicalIndicatorsDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockResearch.TechnicalIndicatorsAsync(symbol, indicatorName, range, lastIndicator, indicatorOnly);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<TechnicalIndicatorsDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetTechnicalIndicatorsAsync");

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
