using AutoMapper;
using FinanceProcessor.Core.Aggregates.Caching;
using FinanceProcessor.Core.Aggregates.DataConsumer.Loaders;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FinanceProcessor.IEXSharp.Model.CoreData.CorporateActions.Request;
using FinanceProcessor.Core.Aggregates.Helper;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.CorporateActions;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class CorporateActionsService : ICorporateActionsService
	{
		private readonly ILogger<StockPricesService> _logger;
		private IEXCloudClient _sandBoxClient;
		private readonly IMapper _mapper;
		private readonly ICacheService _cacheService;

		public CorporateActionsService(ILogger<StockPricesService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper, ICacheService cacheService)
		{
			_logger = logger;
			_mapper = mapper;
			_cacheService = cacheService;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}

		public async Task<IEnumerable<BonusIssueDto>> GetBonusIssueAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string refId = null,
			CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetBonusIssueAsync");

			var requestId = CorporateActionsRequestIdConstants.GetBonusIssue;

			var cacheKey = CacheKey.Create<BonusIssueDto>($"{requestId}|{symbol}|{range?.GetDescriptionFromEnum()}|{calendar}|{last}|{refId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<BonusIssueDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.CorporateActions.BonusIssueAsync(symbol, range, calendar, last, refId);

			if (response?.Data.Any() != true)
				return Array.Empty<BonusIssueDto>();

			var result = _mapper.Map<List<BonusIssueDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetBonusIssueAsync");

			return result;
		}

		public async Task<IEnumerable<DistributionDto>> GetDistributionAsync(
			string? symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string refId = null,
			CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetDistributionAsync");

			var requestId = CorporateActionsRequestIdConstants.GetDistribution;

			var cacheKey = CacheKey.Create<DistributionDto>($"{requestId}|{symbol}|{range?.GetDescriptionFromEnum()}|{calendar}|{last}|{refId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<DistributionDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.CorporateActions.DistributionAsync(symbol, range, calendar, last, refId);

			if (response?.Data.Any() != true)
				return Array.Empty<DistributionDto>();

			var result = _mapper.Map<List<DistributionDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetDistributionAsync");

			return result;
		}

		public async Task<IEnumerable<DividendAdvancedDto>> GetDividendsAdvancedAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar,
			int? last,
			string refId,
			CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetDividendsAdvancedAsync");

			var requestId = CorporateActionsRequestIdConstants.GetDividendsAdvanced;

			var cacheKey = CacheKey.Create<DividendAdvancedDto>($"{requestId}|{symbol}|{range?.GetDescriptionFromEnum()}|{calendar}|{last}|{refId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<DividendAdvancedDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.CorporateActions.DividendsAdvancedAsync(symbol, range, calendar, last, refId);

			if (response?.Data.Any() != true)
				return Array.Empty<DividendAdvancedDto>();

			var result = _mapper.Map<List<DividendAdvancedDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetDividendsAdvancedAsync");

			return result;
		}

		public async Task<IEnumerable<ReturnOfCapitalDto>> GetReturnOfCapitalAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string refId = null,
			CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetReturnOfCapitalAsync");

			var requestId = CorporateActionsRequestIdConstants.GetReturnOfCapital;

			var cacheKey = CacheKey.Create<ReturnOfCapitalDto>($"{requestId}|{symbol}|{range?.GetDescriptionFromEnum()}|{calendar}|{last}|{refId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<ReturnOfCapitalDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.CorporateActions.ReturnOfCapitalAsync(symbol, range, calendar, last, refId);

			if (response?.Data.Any() != true)
				return Array.Empty<ReturnOfCapitalDto>();

			var result = _mapper.Map<List<ReturnOfCapitalDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetReturnOfCapitalAsync");

			return result;
		}

		public async Task<IEnumerable<RightsIssueDto>> GetRightsIssueAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string refId = null,
			CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetRightsIssueAsync");

			var requestId = CorporateActionsRequestIdConstants.GetRightsIssue;

			var cacheKey = CacheKey.Create<RightsIssueDto>($"{requestId}|{symbol}|{range?.GetDescriptionFromEnum()}|{calendar}|{last}|{refId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<RightsIssueDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.CorporateActions.RightsIssueAsync(symbol, range, calendar, last, refId);

			if (response?.Data.Any() != true)
				return Array.Empty<RightsIssueDto>();

			var result = _mapper.Map<List<RightsIssueDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetRightsIssueAsync");

			return result;
		}

		public async Task<IEnumerable<RightToPurchaseDto>> GetRightToPurchaseAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar = false,
			int? last = null,
			string refId = null,
			CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetRightToPurchaseAsync");

			var requestId = CorporateActionsRequestIdConstants.GetRightToPurchase;

			var cacheKey = CacheKey.Create<RightToPurchaseDto>($"{requestId}|{symbol}|{range?.GetDescriptionFromEnum()}|{calendar}|{last}|{refId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<RightToPurchaseDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.CorporateActions.RightToPurchaseAsync(symbol, range, calendar, last, refId);

			if (response?.Data.Any() != true)
				return Array.Empty<RightToPurchaseDto>();

			var result = _mapper.Map<List<RightToPurchaseDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetRightToPurchaseAsync");

			return result;
		}

		public async Task<IEnumerable<SecurityUpdateDto>> GetSecurityReclassificationAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar,
			int? last,
			string refId,
			CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetSecurityReclassificationAsync");

			var requestId = CorporateActionsRequestIdConstants.GetSecurityReclassification;

			var cacheKey = CacheKey.Create<SecurityUpdateDto>($"{requestId}|{symbol}|{range?.GetDescriptionFromEnum()}|{calendar}|{last}|{refId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<SecurityUpdateDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.CorporateActions.SecurityReclassificationAsync(symbol, range, calendar, last, refId);

			if (response?.Data.Any() != true)
				return Array.Empty<SecurityUpdateDto>();

			var result = _mapper.Map<List<SecurityUpdateDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetSecurityReclassificationAsync");

			return result;
		}

		public async Task<IEnumerable<SecurityUpdateDto>> GetSecuritySwapAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar,
			int? last,
			string refId,
			CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetSecuritySwapAsync");

			var requestId = CorporateActionsRequestIdConstants.GetSecuritySwap;

			var cacheKey = CacheKey.Create<SecurityUpdateDto>($"{requestId}|{symbol}|{range?.GetDescriptionFromEnum()}|{calendar}|{last}|{refId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<SecurityUpdateDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.CorporateActions.SecuritySwapAsync(symbol, range, calendar, last, refId);

			if (response?.Data.Any() != true)
				return Array.Empty<SecurityUpdateDto>();

			var result = _mapper.Map<List<SecurityUpdateDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetSecuritySwapAsync");

			return result;
		}

		public async Task<IEnumerable<SpinOffDto>> GetSpinOffAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar,
			int? last,
			string refId,
			CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetSpinOffAsync");

			var requestId = CorporateActionsRequestIdConstants.GetSpinOff;

			var cacheKey = CacheKey.Create<SpinOffDto>($"{requestId}|{symbol}|{range?.GetDescriptionFromEnum()}|{calendar}|{last}|{refId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<SpinOffDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.CorporateActions.SpinOffAsync(symbol, range, calendar, last, refId);

			if (response?.Data.Any() != true)
				return Array.Empty<SpinOffDto>();

			var result = _mapper.Map<List<SpinOffDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetSpinOffAsync");

			return result;
		}

		public async Task<IEnumerable<SplitAdvancedDto>> GetSplitsAdvancedAsync(
			string symbol,
			TimeSeriesRange? range,
			bool calendar,
			int? last,
			string refId,
			CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetSplitsAdvancedAsync");

			var requestId = CorporateActionsRequestIdConstants.GetSplitsAdvanced;

			var cacheKey = CacheKey.Create<SplitAdvancedDto>($"{requestId}|{symbol}|{range?.GetDescriptionFromEnum()}|{calendar}|{last}|{refId}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<SplitAdvancedDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.CorporateActions.SplitsAdvancedAsync(symbol, range, calendar, last, refId);

			if (response?.Data.Any() != true)
				return Array.Empty<SplitAdvancedDto>();

			var result = _mapper.Map<List<SplitAdvancedDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetSplitsAdvancedAsync");

			return result;
		}

		public async Task<IEnumerable<DividendForecastDto>> GetDividendsForecastAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetDividendsForecastAsync");

			var requestId = CorporateActionsRequestIdConstants.GetDividendsForecast;

			var cacheKey = CacheKey.Create<DividendForecastDto>($"{requestId}|{symbol}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<DividendForecastDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.CorporateActions.DividendsForecastAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<DividendForecastDto>();

			var result = _mapper.Map<List<DividendForecastDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetDividendsForecastAsync");

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
