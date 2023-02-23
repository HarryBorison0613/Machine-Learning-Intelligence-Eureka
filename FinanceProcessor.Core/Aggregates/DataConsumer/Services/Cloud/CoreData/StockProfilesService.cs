using AutoMapper;
using FinanceProcessor.Core.Aggregates.Caching;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.StockProfiles;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Aggregates.DataConsumer.Loaders;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class StockProfilesService : IStockProfilesService
	{
		private readonly ILogger<StockProfilesService> _logger;
		private IEXCloudClient _sandBoxClient;
		private readonly IMapper _mapper;
		private readonly ICacheService _cacheService;

		public StockProfilesService(ILogger<StockProfilesService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper, ICacheService cacheService)
		{
			_logger = logger;
			_mapper = mapper;
			_cacheService = cacheService;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}

		public async Task<CompanyDto> GetCompanyAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetCompanyAsync");

			var requestId = StockProfilesRequestIdConstants.GetCompany;

			var cacheKey = CacheKey.Create<CompanyDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<CompanyDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockProfiles.CompanyAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<CompanyDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetCompanyAsync");

			return result;
		}

		public async Task<IEnumerable<InsiderRosterDto>> GetInsiderRosterAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetInsiderRosterAsync");

			var requestId = StockProfilesRequestIdConstants.GetInsiderRoster;

			var cacheKey = CacheKey.Create<InsiderRosterDto>($"{requestId}|{symbol}");
			var cachedValue = await _cacheService.GetAsync<IEnumerable<InsiderRosterDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockProfiles.InsiderRosterAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<InsiderRosterDto>();

			var result = _mapper.Map<List<InsiderRosterDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetInsiderRosterAsync");

			return result;
		}

		public async Task<IEnumerable<InsiderSummaryDto>> GetInsiderSummaryAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetInsiderSummaryAsync");

			var requestId = StockProfilesRequestIdConstants.GetInsiderSummary;

			var cacheKey = CacheKey.Create<InsiderSummaryDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<InsiderSummaryDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockProfiles.InsiderSummaryAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<InsiderSummaryDto>();

			var result = _mapper.Map<List<InsiderSummaryDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.Now, cancellationToken);

			_logger.LogInformation("End GetInsiderSummaryAsync");

			return result;
		}

		public async Task<IEnumerable<InsiderTransactionDto>> GetInsiderTransactionsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetInsiderTransactionsAsync");

			var requestId = StockProfilesRequestIdConstants.GetInsiderTransactions;

			var cacheKey = CacheKey.Create<InsiderTransactionDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<InsiderTransactionDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockProfiles.InsiderTransactionsAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<InsiderTransactionDto>();

			var result = _mapper.Map<List<InsiderTransactionDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetInsiderTransactionsAsync");

			return result;
		}

		public async Task<LogoDto> GetLogoAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetLogoAsync");

			var requestId = StockProfilesRequestIdConstants.GetLogo;

			var cacheKey = CacheKey.Create<LogoDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<LogoDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockProfiles.LogoAsync(symbol);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<LogoDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetLogoAsync");

			return result;
		}

		public async Task<IEnumerable<string>> GetPeerGroupsAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetPeerGroupsAsync");

			var requestId = StockProfilesRequestIdConstants.GetPeerGroups;

			var cacheKey = CacheKey.Create<string>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<string>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockProfiles.PeerGroupsAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<string>();

			var result = _mapper.Map<List<string>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetPeerGroupsAsync");

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
