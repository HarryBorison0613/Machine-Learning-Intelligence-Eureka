using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData;
using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.ReferenceData.Request;
using FinanceProcessor.Static;
using Microsoft.AspNetCore.Mvc;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class ReferencesController : Controller
	{
		private readonly IReferencesService _referencesService;
		private readonly ILogger<ReferencesController> _logger;

		public ReferencesController(IReferencesService referencesService, ILogger<ReferencesController> logger)
		{
			_referencesService = referencesService;
			_logger = logger;
		}

		// This endpoint returns the list of symbols that IEX Cloud supports for intraday price updates.
		[HttpGet("existingSymbols")]
		public async Task<IEnumerable<SymbolDto>> GetSymbolsAsync()
		{
			try
			{
				return await _referencesService.GetSymbolsAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<SymbolDto>();
		}

		// This endpoint returns the list of symbols that IEX Cloud supports for Forex endpoints.
		[HttpGet("existingForexPairsSymbol")]
		public async Task<IEnumerable<ForexPairDto>> GetForexPairsSymbolAsync()
		{
			try
			{
				return await _referencesService.GetForexPairsSymbolsAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<ForexPairDto>();
		}

		// This endpoint returns the list of symbols that IEX Cloud supports for Forex endpoints.
		[HttpGet("existingForexCurrencies")]
		public async Task<IEnumerable<ForexCurrencyDto>> GetForexCurrenciesAsync()
		{
			try
			{
				return await _referencesService.GetForexCurrenciesAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<ForexCurrencyDto>();
		}

		// This provides a full list of supported cryptocurrencies by IEX Cloud.
		[HttpGet("existingCryptoSymbols")]
		public async Task<IEnumerable<CryptoSymbolDto>> GetCryptoSymbolsAsync()
		{
			try
			{
				return await _referencesService.GetCryptoSymbolsAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<CryptoSymbolDto>();
		}

		// This endpoint returns an array of symbols the Investors Exchange supports for trading. This list is updated daily as of 7:45 a.m. ET. Symbols may be added or removed by the Investors Exchange after the list was produced.
		[HttpGet("existingIEXSymbols")]
		public async Task<IEnumerable<IEXSymbolDto>> GetIEXSymbolsAsync()
		{
			try
			{
				return await _referencesService.GetIEXSymbolsAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<IEXSymbolDto>();
		}

		[HttpGet("existingSectors")]
		public async Task<IEnumerable<SectorDto>> GetSectorsAsync([FromServices] IHostEnvironment env)
		{
			try
			{
				if (env.IsDevelopment())
				{
					return Sectors.GetList();
				}
				
				return await _referencesService.GetAllSectorsAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<SectorDto>();
		}

		[HttpGet("existingTags")]
		public async Task<IEnumerable<TagDto>> GetTagsAsync([FromServices] IHostEnvironment env)
		{
			try
			{
				if (env.IsDevelopment())
				{
					return Tags.GetList();
				}

				return await _referencesService.GetAllTagsAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<TagDto>();
		}

		[HttpGet("symbolsInternationalRegionAsync")]
		public async Task<IEnumerable<InternationalSymbolDto>> GetSymbolsInternationalRegionAsync(string region)
		{
			try
			{
				return await _referencesService.GetSymbolsInternationalRegionAsync(region);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<InternationalSymbolDto>();
		}

		[HttpGet("symbolsInternationalExchangeAsync")]
		public async Task<IEnumerable<InternationalSymbolDto>> GetSymbolsInternationalExchangeAsync(string exchange)
		{
			try
			{
				return await _referencesService.GetSymbolsInternationalExchangeAsync(exchange);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<InternationalSymbolDto>();
		}

		[HttpGet("getSearch")]
		public async Task<IEnumerable<SearchDto>> GetSearchAsync(string fragment)
		{
			try
			{
				return await _referencesService.GetSearchAsync(fragment);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<SearchDto>();
		}

		[HttpGet("mutualFundsSymbols")]
		public async Task<IEnumerable<MutualFundsSymbolDto>> GetMutualFundsSymbolsAsync()
		{
			try
			{
				return await _referencesService.GetMutualFundsSymbolsAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<MutualFundsSymbolDto>();
		}

		[HttpGet("OTCSymbols")]
		public async Task<IEnumerable<OTCSymbolDto>> GetOTCSymbolsAsync()
		{
			try
			{
				return await _referencesService.GetOTCSymbolsAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<OTCSymbolDto>();
		}

		[HttpGet("exchangesUS")]
		public async Task<IEnumerable<ExchangeUSDto>> GetExchangesUSAsync()
		{
			try
			{
				return await _referencesService.GetExchangesUSAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<ExchangeUSDto>();
		}

		[HttpGet("internationalExchanges")]
		public async Task<IEnumerable<InternationalExchangeDto>> GetInternationalExchangesAsync()
		{
			try
			{
				return await _referencesService.GetInternationalExchangesAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<InternationalExchangeDto>();
		}

		[HttpGet("FIGIMapping")]
		public async Task<IEnumerable<MappingDto>> GetFIGIMappingAsync(string figi)
		{
			try
			{
				return await _referencesService.GetFIGIMappingAsync(figi);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<MappingDto>();
		}

		[HttpGet("RICMapping")]
		public async Task<IEnumerable<MappingDto>> GetRICMappingAsync(string ric)
		{
			try
			{
				return await _referencesService.GetRICMappingAsync(ric);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<MappingDto>();
		}

		[HttpGet("ISINMapping")]
		public async Task<IEnumerable<MappingDto>> GetISINMappingAsync(string isin)
		{
			try
			{
				return await _referencesService.GetISINMappingAsync(isin);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<MappingDto>();
		}

		[HttpGet("holidaysAndTradingDatesUS")]
		public async Task<IEnumerable<HolidaysAndTradingDatesUSDto>> GetHolidaysAndTradingDatesUSAsync(
			DateType type, DirectionType direction = DirectionType.Next, int last = 1, DateTime? startDate = null)
		{
			try
			{
				return await _referencesService.GetHolidaysAndTradingDatesUSAsync(type, direction, last, startDate);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<HolidaysAndTradingDatesUSDto>();
		}

		[HttpGet("symbolsFuturesUnderlying")]
		public async Task<IEnumerable<FutureSymbolUnderlyingDto>> GetSymbolsFuturesUnderlyingAsync(string underlying)
		{
			try
			{
				return await _referencesService.GetSymbolsFuturesUnderlyingAsync(underlying);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(IReferencesService));
			}

			return Array.Empty<FutureSymbolUnderlyingDto>();
		}
	}
}
