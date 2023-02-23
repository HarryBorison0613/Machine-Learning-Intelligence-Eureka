using FinanceProcessor.Core.Models;
using FinanceProcessor.IEXSharp.Model.CoreData.MarketInfo.Request;
using Microsoft.AspNetCore.Mvc;
using ICoreMarketInfoService = FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.Cloud.CoreData.IMarketInfoService;

namespace FinanceProcessor.Controllers.IEX.Cloud.CoreData
{
	[ApiController]
	[Route("[controller]")]
	public class MarketInfoController : Controller
	{
		private readonly ICoreMarketInfoService _coreMarketInfoService;
		private readonly ILogger<MarketInfoController> _logger;

		public MarketInfoController(ICoreMarketInfoService coreMarketInfoService, ILogger<MarketInfoController> logger)
		{
			_coreMarketInfoService = coreMarketInfoService;
			_logger = logger;
		}

		[HttpGet("list")]
		public Task<IEnumerable<QuoteDto>> GetListAsync(ListType listType, bool displayPercent = false,
			int listLimit = 10)
		{
			try
			{
				return _coreMarketInfoService.GetListAsync(listType, displayPercent, listLimit);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("collections")]
		public Task<IEnumerable<QuoteDto>> GetCollectionsAsync(CollectionType collectionType, string collectionName)
		{
			try
			{
				return _coreMarketInfoService.GetCollectionsAsync(collectionType, collectionName);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("upcomingEarnings")]
		public Task<IEnumerable<UpcomingEarningsDto>> GeUpcomingEarningsAsync(string symbol)
		{
			try
			{
				return _coreMarketInfoService.GetUpcomingEarningsAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("upcomingDividends")]
		public Task<IEnumerable<DividendDto>> GetUpcomingDividendsAsync(string symbol)
		{
			try
			{
				return _coreMarketInfoService.GetUpcomingDividendsAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("upcomingIpos")]
		public Task<IPOCalendarDto> GetUpcomingIposAsync(string symbol)
		{
			try
			{
				return _coreMarketInfoService.GetUpcomingIposAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("upcomingSplits")]
		public Task<IEnumerable<SplitDto>> GeUpcomingSplitsAsync(string symbol)
		{
			try
			{
				return _coreMarketInfoService.GetUpcomingSplitsAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("upcomingEvents")]
		public Task<UpcomingEventMarketDto> GetUpcomingEventsAsync(string symbol)
		{
			try
			{
				return _coreMarketInfoService.GetUpcomingEventsAsync(symbol);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("upcomingDividendsMarket")]
		public Task<IEnumerable<DividendDto>> GetUpcomingDividendsMarketAsync()
		{
			try
			{
				return _coreMarketInfoService.GetUpcomingDividendsMarketAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("upcomingEarningsMarket")]
		public Task<IEnumerable<UpcomingEarningsDto>> GetUpcomingEarningsMarketAsync()
		{
			try
			{
				return _coreMarketInfoService.GetUpcomingEarningsMarketAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("upcomingSplitsMarket")]
		public Task<IEnumerable<SplitDto>> GeUpcomingSplitsMarketAsync()
		{
			try
			{
				return _coreMarketInfoService.GetUpcomingSplitsMarketAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("upcomingIposMarket")]
		public Task<IEnumerable<IPOCalendarDto>> GetUpcomingIposMarketAsync()
		{
			try
			{
				return _coreMarketInfoService.GetUpcomingIposMarketAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("upcomingEventMarket")]
		public Task<IEnumerable<UpcomingEventMarketDto>> GetUpcomingEventMarketAsync()
		{
			try
			{
				return _coreMarketInfoService.GetUpcomingEventMarketAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("ipoCalendar")]
		public Task<IEnumerable<IPOCalendarDto>> GetIPOCalendarAsync(IPOType ipoType)
		{
			try
			{
				return _coreMarketInfoService.GetIPOCalendarAsync(ipoType);
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("marketVolumeUSA")]
		public Task<IEnumerable<MarketVolumeUSDto>> GetMarketVolumeUSAsync()
		{
			try
			{
				return _coreMarketInfoService.GetMarketVolumeUSAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("markets")]
		public Task<IEnumerable<MarketVolumeUSDto>> GetMarketAsync()
		{
			try
			{
				return _coreMarketInfoService.GetMarketAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}

		[HttpGet("sectorPerformance")]
		public Task<IEnumerable<SectorPerformanceDto>> GetSectorPerformanceAsync()
		{
			try
			{
				return _coreMarketInfoService.GetSectorPerformanceAsync();
			}
			catch (Exception e)
			{
				_logger.LogError(e, nameof(ICoreMarketInfoService));
			}

			return null;
		}
	}
}
