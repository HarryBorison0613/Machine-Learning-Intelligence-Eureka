using AutoMapper;
using FinanceProcessor.Core.Aggregates.Caching;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.StockFundamentals;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Aggregates.DataConsumer.Loaders;
using FinanceProcessor.Core.Aggregates.Helper;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Model.CoreData.StockFundamentals.Request;
using FinanceProcessor.IEXSharp.Model.Shared.Request;
using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class StockFundamentalsService : IStockFundamentalsService
	{
		private readonly ILogger<StockFundamentalsService> _logger;
		private IEXCloudClient _sandBoxClient;
		private readonly IMapper _mapper;
		private readonly ICacheService _cacheService;

		public StockFundamentalsService(ILogger<StockFundamentalsService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper, ICacheService cacheService)
		{
			_logger = logger;
			_mapper = mapper;
			_cacheService = cacheService;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}
		
		public async Task<IEnumerable<AdvancedFundamentalsDto>> GetAdvancedFundamentalsAsync(string symbol, TimeSeriesPeriod timeSeriesPeriod, TimeSeries? timeSeries = null, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetAdvancedFundamentalsAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetAdvancedFundamentals;

			var cacheKey = CacheKey.Create<AdvancedFundamentalsDto>($"{requestId}|{symbol}|{timeSeriesPeriod.GetDescriptionFromEnum()}|{timeSeries}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<AdvancedFundamentalsDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.AdvancedFundamentalsAsync(symbol, timeSeriesPeriod, timeSeries);

			if (response?.Data.Any() != true)
				return Array.Empty<AdvancedFundamentalsDto>();

			var result = _mapper.Map<List<AdvancedFundamentalsDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetAdvancedFundamentalsAsync");

			return result;
		}

		public async Task<IEnumerable<FundamentalValuationsDto>> GetFundamentalValuationsAsync(string symbol, TimeSeriesPeriod timeSeriesPeriod, TimeSeries? timeSeries = null, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetFundamentalValuationsAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetFundamentalValuations;

			var cacheKey = CacheKey.Create<FundamentalValuationsDto>($"{requestId}|{symbol}|{timeSeriesPeriod.GetDescriptionFromEnum()}|{timeSeries}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<FundamentalValuationsDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.FundamentalValuationsAsync(symbol, timeSeriesPeriod, timeSeries);

			if (response?.Data.Any() != true)
				return Array.Empty<FundamentalValuationsDto>();

			var result = _mapper.Map<List<FundamentalValuationsDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetFundamentalValuationsAsync");

			return result;
		}

		public async Task<BalanceSheetDto> GetBalanceSheetAsync(string symbol, Period period, int last = 1, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetBalanceSheetAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetBalanceSheet;

			var cacheKey = CacheKey.Create<BalanceSheetDto>($"{requestId}|{symbol}|{period.GetDescriptionFromEnum()}|{last}");

			var cachedValue = await _cacheService.GetAsync<BalanceSheetDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.BalanceSheetAsync(symbol, period, last);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<BalanceSheetDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetBalanceSheetAsync");

			return result;
		}

		public async Task<string> GetBalanceSheetFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetBalanceSheetFieldAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetBalanceSheetField;

			var cacheKey = CacheKey.Create<string>($"{requestId}|{symbol}|{field}|{period.GetDescriptionFromEnum()}|{last}");

			var cachedValue = await _cacheService.GetAsync<string>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.BalanceSheetFieldAsync(symbol, field, period, last);

			if (string.IsNullOrWhiteSpace(response?.Data))
				return string.Empty;

			var result = response.Data;

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetBalanceSheetFieldAsync");

			return result;
		}

		public async Task<CashFlowsDto> GetCashFlowAsync(string symbol, Period period = Period.Quarter, int last = 1, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetCashFlowAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetCashFlow;

			var cacheKey = CacheKey.Create<string>($"{requestId}|{symbol}|{period.GetDescriptionFromEnum()}|{last}");

			var cachedValue = await _cacheService.GetAsync<CashFlowsDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.CashFlowAsync(symbol, period, last);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<CashFlowsDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetCashFlowAsync");

			return result;
		}

		public async Task<string> GetCashFlowFieldAsync(string symbol, string field, Period period = Period.Quarter,
			int last = 1, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetCashFlowFieldAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetCashFlowField;

			var cacheKey = CacheKey.Create<string>($"{requestId}|{symbol}|{field}|{period.GetDescriptionFromEnum()}|{last}");

			var cachedValue = await _cacheService.GetAsync<string>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.CashFlowFieldAsync(symbol, field, period, last);

			if (string.IsNullOrWhiteSpace(response?.Data))
				return string.Empty;

			var result = response.Data;

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetCashFlowFieldAsync");

			return result;
		}

		public async Task<IEnumerable<DividendBasicDto>> GetDividendsBasicAsync(string symbol, DividendRange range, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetDividendsBasicAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetDividendsBasic;

			var cacheKey = CacheKey.Create<DividendBasicDto>($"{requestId}|{symbol}|{range.GetDescriptionFromEnum()}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<DividendBasicDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.DividendsBasicAsync(symbol, range);

			if (response?.Data.Any() != true)
				return Array.Empty<DividendBasicDto>();

			var result = _mapper.Map<List<DividendBasicDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetDividendsBasicAsync");

			return result;
		}

		public async Task<EarningDto> GetEarningAsync(string symbol, int last = 1, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetEarningAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetEarning;

			var cacheKey = CacheKey.Create<EarningDto>($"{requestId}|{symbol}|{last}");

			var cachedValue = await _cacheService.GetAsync<EarningDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.EarningAsync(symbol, last);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<EarningDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetEarningAsync");

			return result;
		}

		public async Task<string> GetEarningFieldAsync(string symbol, string field, int last = 1, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetEarningFieldAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetEarningField;

			var cacheKey = CacheKey.Create<string>($"{requestId}|{symbol}|{field}|{last}");

			var cachedValue = await _cacheService.GetAsync<string>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.EarningFieldAsync(symbol, field, last);

			if (string.IsNullOrWhiteSpace(response?.Data))
				return string.Empty;

			var result = response.Data;

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetEarningFieldAsync");

			return result;
		}

		public async Task<FinancialDto> GetFinancialAsync(string symbol, int last = 1, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetFinancialAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetFinancial;

			var cacheKey = CacheKey.Create<FinancialDto>($"{requestId}|{symbol}|{last}");

			var cachedValue = await _cacheService.GetAsync<FinancialDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.FinancialAsync(symbol, last);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<FinancialDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetFinancialAsync");

			return result;
		}

		public async Task<string> GetFinancialFieldAsync(string symbol, string field, int last = 1, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetFinancialFieldAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetFinancialField;

			var cacheKey = CacheKey.Create<string>($"{requestId}|{symbol}|{field}|{last}");

			var cachedValue = await _cacheService.GetAsync<string>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.FinancialFieldAsync(symbol, field, last);

			if (string.IsNullOrWhiteSpace(response?.Data))
				return string.Empty;

			var result = response.Data;

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetFinancialFieldAsync");

			return result;
		}

		public async Task<IncomeStatementDto> GetIncomeStatementAsync(string symbol, Period period = Period.Quarter,
			int last = 1, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetIncomeStatementAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetIncomeStatement;

			var cacheKey = CacheKey.Create<IncomeStatementDto>($"{requestId}|{symbol}|{period.GetDescriptionFromEnum()}|{last}");

			var cachedValue = await _cacheService.GetAsync<IncomeStatementDto>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.IncomeStatementAsync(symbol, period, last);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<IncomeStatementDto>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetIncomeStatementAsync");

			return result;
		}

		public async Task<string> GetIncomeStatementFieldAsync(string symbol, string field, Period period = Period.Quarter, int last = 1, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetIncomeStatementFieldAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetIncomeStatementField;

			var cacheKey = CacheKey.Create<string>($"{requestId}|{symbol}|{field}||{period.GetDescriptionFromEnum()}|{last}");

			var cachedValue = await _cacheService.GetAsync<string>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.IncomeStatementFieldAsync(symbol, field, period, last);

			if (string.IsNullOrWhiteSpace(response?.Data))
				return string.Empty;

			var result = response.Data;

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetIncomeStatementFieldAsync");

			return result;
		}

		public async Task<IEnumerable<ReportedFinancialDto>> GetReportedFinancialsAsync(string symbol, Filing filing = Filing.Quarterly, TimeSeries? timeSeries = null, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetReportedFinancialsAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetReportedFinancials;

			var cacheKey = CacheKey.Create<ReportedFinancialDto>($"{requestId}|{symbol}|{filing.GetDescriptionFromEnum()}|{timeSeries}|{timeSeries}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<ReportedFinancialDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.ReportedFinancialsAsync(symbol, filing, timeSeries);

			if (response?.Data.Any() != true)
				return Array.Empty<ReportedFinancialDto>();

			var result = _mapper.Map<List<ReportedFinancialDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetReportedFinancialsAsync");

			return result;
		}

		public async Task<IEnumerable<SplitBasicDto>> GetSplitsBasicAsync(string symbol, SplitRange range = SplitRange.OneMonth, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start GetSplitsBasicAsync");

			var requestId = StockFundamentalsRequestIdConstants.GetSplitsBasic;

			var cacheKey = CacheKey.Create<SplitBasicDto>($"{requestId}|{symbol}|{range.GetDescriptionFromEnum()}");

			var cachedValue = await _cacheService.GetAsync<IEnumerable<SplitBasicDto>>(cacheKey, cancellationToken);

			if (cachedValue is not null)
				return cachedValue;

			var response = await _sandBoxClient.StockFundamentals.SplitsBasicAsync(symbol, range);

			if (response?.Data.Any() != true)
				return Array.Empty<SplitBasicDto>();

			var result = _mapper.Map<List<SplitBasicDto>>(response.Data);

			SetCacheAsync(cacheKey, result, requestId, DateTime.UtcNow, cancellationToken);

			_logger.LogInformation("End GetSplitsBasicAsync");

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
