using AutoMapper;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp;
using FinanceProcessor.IEXSharp.Model.CoreData.ReferenceData.Request;
using FinanceProcessor.IEXSharp.Options;
using FinanceProcessor.MongoDB.Contracts.Repositories;
using FinanceProcessor.MongoDB.Contracts.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Services.Cloud.CoreData
{
	public class ReferencesService : IReferencesService
	{
		private readonly ILogger<ReferencesService> _logger;
		private readonly ISymbolRepository _symbolRepository;
		private readonly IForexPairRepository _forexPairRepository;
		private readonly IForexCurrencyRepository _forexCurrencyRepository;
		private readonly ICryptoSymbolRepository _cryptoSymbolRepository;
		private readonly IIEXSymbolRepository _iEXSymbolRepository;
		private readonly ISectorRepository _sectorRepository;
		private readonly ITagRepository _tagRepository;
		private readonly IMutualFundsSymbolRepository _mutualFundsSymbolRepository;
		private readonly IOTCSymbolRepository _otcSymbolRepository;
		private readonly IExchangeUSRepository _exchangeUSRepository;
		private readonly IInternationalExchangeRepository _internationalExchangeRepository;
		private readonly IMapper _mapper;
		private IEXCloudClient _sandBoxClient;

		public ReferencesService(IDataService ds, ILogger<ReferencesService> logger, IMapper mapper, IOptionsSnapshot<EXCloudClientOptions> EXCloudClientConfiguration)
		{
			_symbolRepository = ds.Symbols;
			_cryptoSymbolRepository = ds.CryptoSymbols;
			_iEXSymbolRepository = ds.IEXSymbols;
			_sectorRepository = ds.Sectors;
			_tagRepository = ds.Tags;
			_forexPairRepository = ds.ForexPairs;
			_forexCurrencyRepository = ds.ForexCurrencies;
			_mutualFundsSymbolRepository = ds.MutualFundsSymbols;
			_otcSymbolRepository = ds.OTCSymbols;
			_exchangeUSRepository = ds.ExchangesUS;
			_internationalExchangeRepository = ds.InternationalExchanges;
			_logger = logger;
			_mapper = mapper;

			EXBaseOptions EXBaseOptions = EXCloudClientConfiguration.Value.UseSandbox
				? EXCloudClientConfiguration.Value.Sandbox
				: EXCloudClientConfiguration.Value.EXCloud;

			_sandBoxClient = new IEXCloudClient(EXBaseOptions, signRequest: false);
		}

		public async Task<IEnumerable<SymbolDto>> GetSymbolsAsync()
		{
			_logger.LogInformation("Start GetSymbolsAsync");

			var symbolsFromDB = _symbolRepository.GetAllSymbols();

			if (symbolsFromDB.Any())
				return _mapper.Map<List<SymbolDto>>(symbolsFromDB);

			var response = await _sandBoxClient.ReferenceData.SymbolsAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<SymbolDto>();

			return _mapper.Map<List<SymbolDto>>(response.Data);
		}

		public async Task<IEnumerable<ForexPairDto>> GetForexPairsSymbolsAsync()
		{
			_logger.LogInformation("Start GetForexPairsSymbols");

			var symbolsFromDB = _forexPairRepository.GetAllForexPairs();

			if (symbolsFromDB.Any())
				return _mapper.Map<List<ForexPairDto>>(symbolsFromDB);

			var response = await _sandBoxClient.ReferenceData.SymbolFXAsync();

			if (response?.Data?.pairs.Any() != true)
				return Array.Empty<ForexPairDto>();

			return _mapper.Map<List<ForexPairDto>>(response.Data.pairs);
		}

		public async Task<IEnumerable<ForexCurrencyDto>> GetForexCurrenciesAsync()
		{
			_logger.LogInformation("Start GetForexCurrencies");

			var symbolsFromDB = _forexCurrencyRepository.GetAllForexCurrencies();

			if (symbolsFromDB.Any())
				return _mapper.Map<List<ForexCurrencyDto>>(symbolsFromDB);

			var response = await _sandBoxClient.ReferenceData.SymbolFXAsync();

			if (response?.Data?.currencies.Any() != true)
				return Array.Empty<ForexCurrencyDto>();

			return _mapper.Map<List<ForexCurrencyDto>>(response.Data.currencies);
		}

		public async Task<IEnumerable<CryptoSymbolDto>> GetCryptoSymbolsAsync()
		{
			_logger.LogInformation("Start GetCryptoSymbols");

			var symbolsFromDB = _cryptoSymbolRepository.GetAllCryptoSymbols();

			if (symbolsFromDB.Any())
				return _mapper.Map<List<CryptoSymbolDto>>(symbolsFromDB);

			var response = await _sandBoxClient.ReferenceData.SymbolCryptoAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<CryptoSymbolDto>();

			return _mapper.Map<List<CryptoSymbolDto>>(response.Data);
		}

		public async Task<IEnumerable<MutualFundsSymbolDto>> GetMutualFundsSymbolsAsync()
		{
			_logger.LogInformation("Start GetMutualFundsSymbols");

			var symbolsFromDB = _mutualFundsSymbolRepository.GetAllMutualFundsSymbols();

			if (symbolsFromDB.Any())
				return _mapper.Map<List<MutualFundsSymbolDto>>(symbolsFromDB);

			var response = await _sandBoxClient.ReferenceData.SymbolsMutualFundAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<MutualFundsSymbolDto>();

			return _mapper.Map<List<MutualFundsSymbolDto>>(response.Data);
		}

		public async Task<IEnumerable<OTCSymbolDto>> GetOTCSymbolsAsync()
		{
			_logger.LogInformation("Start GetOTCSymbols");

			var symbolsFromDB = _otcSymbolRepository.GetAllOTCSymbols();

			if (symbolsFromDB.Any())
				return _mapper.Map<List<OTCSymbolDto>>(symbolsFromDB);

			var response = await _sandBoxClient.ReferenceData.SymbolsOTCAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<OTCSymbolDto>();

			return _mapper.Map<List<OTCSymbolDto>>(response.Data);
		}

		public async Task<IEnumerable<IEXSymbolDto>> GetIEXSymbolsAsync()
		{
			_logger.LogInformation("Start GetIEXSymbols");

			var symbolsFromDB = _iEXSymbolRepository.GetAllIEXSymbols();

			if (symbolsFromDB.Any())
				return _mapper.Map<List<IEXSymbolDto>>(symbolsFromDB);

			var response = await _sandBoxClient.ReferenceData.SymbolsIEXAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<IEXSymbolDto>();

			return _mapper.Map<List<IEXSymbolDto>>(response.Data);
		}

		public async Task<IEnumerable<SectorDto>> GetAllSectorsAsync()
		{
			_logger.LogInformation("Start GetAllSectors");

			var symbolsFromDB = _sectorRepository.GetAllSectors();

			if (symbolsFromDB.Any())
				return _mapper.Map<List<SectorDto>>(symbolsFromDB);

			var response = await _sandBoxClient.ReferenceData.SectorsAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<SectorDto>();

			return _mapper.Map<List<SectorDto>>(response.Data);
		}

		public async Task<IEnumerable<TagDto>> GetAllTagsAsync()
		{
			_logger.LogInformation("Start GetAllTags");

			var symbolsFromDB = _tagRepository.GetAllTags();

			if (symbolsFromDB.Any())
				return _mapper.Map<List<TagDto>>(symbolsFromDB);

			var response = await _sandBoxClient.ReferenceData.TagsAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<TagDto>();

			return _mapper.Map<List<TagDto>>(response.Data);
		}

		public async Task<IEnumerable<InternationalSymbolDto>> GetSymbolsInternationalRegionAsync(string region)
		{
			_logger.LogInformation("Start GetSymbolsInternationalRegion");

			var response = await _sandBoxClient.ReferenceData.SymbolsInternationalRegionAsync(region);

			if (response?.Data.Any() != true)
				return Array.Empty<InternationalSymbolDto>();

			return _mapper.Map<List<InternationalSymbolDto>>(response.Data);
		}

		public async Task<IEnumerable<InternationalSymbolDto>> GetSymbolsInternationalExchangeAsync(string exchange)
		{
			_logger.LogInformation("Start GetSymbolsInternationalExchangeAsync");

			var response = await _sandBoxClient.ReferenceData.SymbolsInternationalExchangeAsync(exchange);

			if (response?.Data.Any() != true)
				return Array.Empty<InternationalSymbolDto>();

			return _mapper.Map<List<InternationalSymbolDto>>(response.Data);
		}

		public async Task<IEnumerable<FutureSymbolUnderlyingDto>> GetSymbolsFuturesUnderlyingAsync(string underlying)
		{
			_logger.LogInformation("Start GetSymbolsFuturesUnderlyingAsync");

			var response = await _sandBoxClient.ReferenceData.SymbolsFuturesUnderlyingAsync(underlying);

			if (response?.Data.Any() != true)
				return Array.Empty<FutureSymbolUnderlyingDto>();

			return _mapper.Map<List<FutureSymbolUnderlyingDto>>(response.Data);
		}

		public async Task<IEnumerable<SearchDto>> GetSearchAsync(string fragment)
		{
			_logger.LogInformation("Start GetSearchAsync");

			var response = await _sandBoxClient.ReferenceData.SearchAsync(fragment);

			if (response?.Data.Any() != true)
				return Array.Empty<SearchDto>();

			return _mapper.Map<List<SearchDto>>(response.Data);
		}

		public async Task<IEnumerable<HolidaysAndTradingDatesUSDto>> GetHolidaysAndTradingDatesUSAsync(
			DateType type, DirectionType direction = DirectionType.Next, int last = 1, DateTime? startDate = null)
		{
			_logger.LogInformation("Start GetHolidaysAndTradingDatesUSAsync");

			var response = await _sandBoxClient.ReferenceData.HolidaysAndTradingDatesUSAsync(type, direction, last, startDate);

			if (response?.Data.Any() != true)
				return Array.Empty<HolidaysAndTradingDatesUSDto>();

			return _mapper.Map<List<HolidaysAndTradingDatesUSDto>>(response.Data);
		}

		public async Task<IEnumerable<MappingDto>> GetISINMappingAsync(string isin)
		{
			_logger.LogInformation("Start GetISINMappingAsync");

			var response = await _sandBoxClient.ReferenceData.ISINMappingAsync(isin);

			if (response?.Data.Any() != true)
				return Array.Empty<MappingDto>();

			return _mapper.Map<List<MappingDto>>(response.Data);
		}

		public async Task<IEnumerable<MappingDto>> GetRICMappingAsync(string ric)
		{
			_logger.LogInformation("Start GetRICMappingAsync");

			var response = await _sandBoxClient.ReferenceData.RICMappingAsync(ric);

			if (response?.Data.Any() != true)
				return Array.Empty<MappingDto>();

			return _mapper.Map<List<MappingDto>>(response.Data);
		}

		public async Task<IEnumerable<MappingDto>> GetFIGIMappingAsync(string figi)
		{
			_logger.LogInformation("Start GetFIGIMappingAsync");

			var response = await _sandBoxClient.ReferenceData.FIGIMappingAsync(figi);

			if (response?.Data.Any() != true)
				return Array.Empty<MappingDto>();

			return _mapper.Map<List<MappingDto>>(response.Data);
		}

		public async Task<IEnumerable<ExchangeUSDto>> GetExchangesUSAsync()
		{
			_logger.LogInformation("Start GetExchangesUS");

			var symbolsFromDB = _exchangeUSRepository.GetAllExchangesUS();

			if (symbolsFromDB.Any())
				return _mapper.Map<List<ExchangeUSDto>>(symbolsFromDB);

			var response = await _sandBoxClient.ReferenceData.ExchangeUSAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<ExchangeUSDto>();

			return _mapper.Map<List<ExchangeUSDto>>(response.Data);
		}

		public async Task<IEnumerable<InternationalExchangeDto>> GetInternationalExchangesAsync()
		{
			_logger.LogInformation("Start GetInternationalExchanges");

			var symbolsFromDB = _internationalExchangeRepository.GetAllInternationalExchanges();

			if (symbolsFromDB.Any())
				return _mapper.Map<List<InternationalExchangeDto>>(symbolsFromDB);

			var response = await _sandBoxClient.ReferenceData.ExchangeInternationalAsync();

			if (response?.Data.Any() != true)
				return Array.Empty<InternationalExchangeDto>();

			return _mapper.Map<List<InternationalExchangeDto>>(response.Data);
		}
	}
}
