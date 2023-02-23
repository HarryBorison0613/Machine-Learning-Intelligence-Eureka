using AutoMapper;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Model.CoreData.InvestorsExchangeData.Response;
using FinanceProcessor.IEXSharp.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class InvestorsExchangeDataService : IInvestorsExchangeDataService
	{
		private readonly ILogger<StockPricesService> _logger;
		private IEXCloudClient _sandBoxClient;
		private readonly IMapper _mapper;

		public InvestorsExchangeDataService(ILogger<StockPricesService> logger, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration, IMapper mapper)
		{
			_logger = logger;
			_mapper = mapper;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}

		public async Task<DeepDto> DeepAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start DeepAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.DeepAsync(symbols);

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<DeepDto>(response.Data);

			_logger.LogInformation("End DeepAsync");

			return result;
		}

		public async Task<StatsRecordDto> StatsRecordAsync(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start StatsRecordAsync");
			
			var response = await _sandBoxClient.InvestorsExchangeDataService.StatsRecordAsync();

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<StatsRecordDto>(response.Data);

			_logger.LogInformation("End StatsRecordAsync");

			return result;
		}

		public async Task<StatsIntradayDto> StatsIntradayAsync(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start StatsIntradayAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.StatsIntradayAsync();

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<StatsIntradayDto>(response.Data);

			_logger.LogInformation("End StatsIntradayAsync");

			return result;
		}
		public async Task<DeepSystemEventDto> DeepSystemEventAsync(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start DeepSystemEventAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.DeepSystemEventAsync();

			if (response?.Data == null)
				return null;

			var result = _mapper.Map<DeepSystemEventDto>(response.Data);

			_logger.LogInformation("End DeepSystemEventAsync");

			return result;
		}

		public async Task<IEnumerable<DeepAuctionDto>> DeepAuctionAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start DeepAuctionAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.DeepAuctionAsync(symbols);

			if (response?.Data == null)
				return null;

			var result = Map(response.Data);

			_logger.LogInformation("End DeepAuctionAsync");

			return result;
		}

		public async Task<IEnumerable<DeepBookDto>> DeepBookAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start DeepBookAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.DeepBookAsync(symbols);

			if (response?.Data == null)
				return null;

			var result = Map(response.Data);

			_logger.LogInformation("End DeepBookAsync");

			return result;
		}

		public async Task<IEnumerable<DeepOperationalHaltStatusDto>> DeepOperationHaltStatusAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start DeepOperationHaltStatusAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.DeepOperationHaltStatusAsync(symbols);

			if (response?.Data == null)
				return null;

			var result = Map(response.Data);

			_logger.LogInformation("End DeepOperationHaltStatusAsync");

			return result;
		}

		public async Task<IEnumerable<DeepOfficialPriceDto>> DeepOfficialPriceAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start DeepOfficialPriceAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.DeepOfficialPriceAsync(symbols);

			if (response?.Data == null)
				return null;

			var result = Map(response.Data);

			_logger.LogInformation("End DeepOfficialPriceAsync");

			return result;
		}

		public async Task<IEnumerable<DeepSecurityEventDto>> DeepSecurityEventAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start DeepSecurityEventAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.DeepSecurityEventAsync(symbols);

			if (response?.Data == null)
				return null;

			var result = Map(response.Data);

			_logger.LogInformation("End DeepSecurityEventAsync");

			return result;
		}

		public async Task<IEnumerable<DeepShortSalePriceTestStatusDto>> DeepShortSalePriceTestStatusAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start DeepShortSalePriceTestStatusAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.DeepShortSalePriceTestStatusAsync(symbols);

			if (response?.Data == null)
				return null;

			var result = Map(response.Data);

			_logger.LogInformation("End DeepShortSalePriceTestStatusAsync");

			return result;
		}

		public async Task<IEnumerable<DeepTradingStatusDto>> DeepTradingStatusAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start DeepTradingStatusAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.DeepTradingStatusAsync(symbols);

			if (response?.Data == null)
				return null;

			var result = Map(response.Data);

			_logger.LogInformation("End DeepTradingStatusAsync");

			return result;
		}

		public async Task<IEnumerable<LastDto>> LastAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start LastAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.LastAsync(symbols);

			if (response?.Data.Any() != true)
				return Array.Empty<LastDto>();

			var result = _mapper.Map<List<LastDto>>(response.Data);

			_logger.LogInformation("End LastAsync");

			return result;
		}

		public async Task<IEnumerable<ListedRegulationSHOThresholdSecuritiesListDto>> ListedRegulationSHOThresholdSecuritiesListAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start ListedRegulationSHOThresholdSecuritiesListAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.ListedRegulationSHOThresholdSecuritiesListAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<ListedRegulationSHOThresholdSecuritiesListDto>();

			var result = _mapper.Map<List<ListedRegulationSHOThresholdSecuritiesListDto>>(response.Data);

			_logger.LogInformation("End ListedRegulationSHOThresholdSecuritiesListAsync");

			return result;
		}

		public async Task<IEnumerable<ListedShortInterestListDto>> ListedShortInterestListAsync(string symbol, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start ListedShortInterestListAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.ListedShortInterestListAsync(symbol);

			if (response?.Data.Any() != true)
				return Array.Empty<ListedShortInterestListDto>();

			var result = _mapper.Map<List<ListedShortInterestListDto>>(response.Data);

			_logger.LogInformation("End ListedShortInterestListAsync");

			return result;
		}

		public async Task<IEnumerable<StatsHisoricalDailyDto>> StatsHistoricalDailyByDateAsync(string date, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start StatsHistoricalDailyByDateAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.StatsHistoricalDailyByDateAsync(date);

			if (response?.Data.Any() != true)
				return Array.Empty<StatsHisoricalDailyDto>();

			var result = _mapper.Map<List<StatsHisoricalDailyDto>>(response.Data);

			_logger.LogInformation("End StatsHistoricalDailyByDateAsync");

			return result;
		}

		public async Task<IEnumerable<StatsHisoricalDailyDto>> StatsHistoricalDailyByLastAsync(int last, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start StatsHistoricalDailyByLastAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.StatsHistoricalDailyByLastAsync(last);

			if (response?.Data.Any() != true)
				return Array.Empty<StatsHisoricalDailyDto>();

			var result = _mapper.Map<List<StatsHisoricalDailyDto>>(response.Data);

			_logger.LogInformation("End StatsHistoricalDailyByLastAsync");

			return result;
		}

		public async Task<IEnumerable<StatsHistoricalSummaryDto>> StatsHistoricalSummaryAsync(DateTime? date = null, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start StatsHistoricalSummaryAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.StatsHistoricalSummaryAsync(date);

			if (response?.Data.Any() != true)
				return Array.Empty<StatsHistoricalSummaryDto>();

			var result = _mapper.Map<List<StatsHistoricalSummaryDto>>(response.Data);

			_logger.LogInformation("End StatsHistoricalSummaryAsync");

			return result;
		}

		public async Task<IEnumerable<StatsRecentDto>> StatsRecentAsync(CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start StatsRecentAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.StatsRecentAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<StatsRecentDto>();

			var result = _mapper.Map<List<StatsRecentDto>>(response.Data);

			_logger.LogInformation("End StatsRecentAsync");

			return result;
		}

		public async Task<IEnumerable<TOPSDto>> TOPSAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start TOPSAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.TOPSAsync(symbols);

			if (response?.Data.Any() != true)
				return Array.Empty<TOPSDto>();

			var result = _mapper.Map<List<TOPSDto>>(response.Data);

			_logger.LogInformation("End TOPSAsync");

			return result;
		}

		public async Task<Dictionary<string, IEnumerable<DeepTradeDto>>> DeepTradeAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start DeepTradeAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.DeepTradeAsync(symbols);

			if (response?.Data == null)
				return null;

			var result = Map(response.Data);

			_logger.LogInformation("End DeepTradeAsync");

			return result;
		}

		public async Task<Dictionary<string, IEnumerable<DeepTradeDto>>> DeepTradeBreaksAsync(IEnumerable<string> symbols, CancellationToken cancellationToken = default)
		{
			_logger.LogInformation("Start DeepTradeBreaksAsync");

			var response = await _sandBoxClient.InvestorsExchangeDataService.DeepTradeBreaksAsync(symbols);

			if (response?.Data == null)
				return null;

			var result = Map(response.Data);

			_logger.LogInformation("End DeepTradeBreaksAsync");

			return result;
		}

		private IEnumerable<DeepAuctionDto> Map(Dictionary<string, DeepAuctionResponse> responses)
		{
			var collection = new List<DeepAuctionDto>();
			foreach (var response in responses)
			{
				var current = _mapper.Map<DeepAuctionDto>(response.Value);
				current.Symbol = response.Key;
				collection.Add(current);
			}

			return collection;
		}

		private IEnumerable<DeepBookDto> Map(Dictionary<string, DeepBookResponse> responses)
		{
			var collection = new List<DeepBookDto>();
			foreach (var response in responses)
			{
				var current = _mapper.Map<DeepBookDto>(response.Value);
				current.Symbol = response.Key;
				collection.Add(current);
			}

			return collection;
		}

		private IEnumerable<DeepOperationalHaltStatusDto> Map(Dictionary<string, DeepOperationalHaltStatusResponse> responses)
		{
			var collection = new List<DeepOperationalHaltStatusDto>();
			foreach (var response in responses)
			{
				var current = _mapper.Map<DeepOperationalHaltStatusDto>(response.Value);
				current.Symbol = response.Key;
				collection.Add(current);
			}

			return collection;
		}

		private IEnumerable<DeepOfficialPriceDto> Map(Dictionary<string, DeepOfficialPriceResponse> responses)
		{
			var collection = new List<DeepOfficialPriceDto>();
			foreach (var response in responses)
			{
				var current = _mapper.Map<DeepOfficialPriceDto>(response.Value);
				current.Symbol = response.Key;
				collection.Add(current);
			}

			return collection;
		}

		private IEnumerable<DeepSecurityEventDto> Map(Dictionary<string, DeepSecurityEventResponse> responses)
		{
			var collection = new List<DeepSecurityEventDto>();
			foreach (var response in responses)
			{
				var current = _mapper.Map<DeepSecurityEventDto>(response.Value);
				current.Symbol = response.Key;
				collection.Add(current);
			}

			return collection;
		}

		private IEnumerable<DeepShortSalePriceTestStatusDto> Map(Dictionary<string, DeepShortSalePriceTestStatusResponse> responses)
		{
			var collection = new List<DeepShortSalePriceTestStatusDto>();
			foreach (var response in responses)
			{
				var current = _mapper.Map<DeepShortSalePriceTestStatusDto>(response.Value);
				current.Symbol = response.Key;
				collection.Add(current);
			}

			return collection;
		}

		private IEnumerable<DeepTradingStatusDto> Map(Dictionary<string, DeepTradingStatusResponse> responses)
		{
			var collection = new List<DeepTradingStatusDto>();
			foreach (var response in responses)
			{
				var current = _mapper.Map<DeepTradingStatusDto>(response.Value);
				current.Symbol = response.Key;
				collection.Add(current);
			}

			return collection;
		}

		private Dictionary<string, IEnumerable<DeepTradeDto>> Map(Dictionary<string, IEnumerable<DeepTradeResponse>> responses)
		{
			var collection = new Dictionary<string, IEnumerable<DeepTradeDto>>();

			foreach (var response in responses)
				collection.Add(response.Key, _mapper.Map<IEnumerable<DeepTradeDto>>(response.Value));

			return collection;
		}
	}
}
