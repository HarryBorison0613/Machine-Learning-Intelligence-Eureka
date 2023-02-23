using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.CeoCompensation;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.Commodities;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.CorporateActions;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.EconomicData;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.ForexCurrencies;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.Futures;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.MarketInfo;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.Options;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.StockFundamentals;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.StockPrices;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.StockProfiles;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.StockResearch;
using FinanceProcessor.Core.Aggregates.DataConsumer.Constants.Treasuries;
using FinanceProcessor.Core.Aggregates.Helper;

namespace FinanceProcessor.Core.Aggregates.DataConsumer.Loaders
{
	public static class RequestUpdateSchedule
	{
		private static readonly DayOfWeek[] _allWeekDays;
		private static readonly List<RequestUpdateDateTimeInfo> _requestUpdateDateTimeInfo;
		private static readonly Dictionary<string, RequestUpdateDateTimeInfo[]> _requestUpdateDateTimeInfos;

		static RequestUpdateSchedule()
		{
			_allWeekDays = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday };

			_requestUpdateDateTimeInfo = new List<RequestUpdateDateTimeInfo>();
			_requestUpdateDateTimeInfo.AddRange(FillMarketInfoRequestIds());
			_requestUpdateDateTimeInfo.AddRange(FillCorporateActionsRequestIds());
			_requestUpdateDateTimeInfo.AddRange(FillStockPricesRequestIds());
			_requestUpdateDateTimeInfo.AddRange(FillCeoCompensationsRequestIds());
			_requestUpdateDateTimeInfo.AddRange(FillStockProfilesRequestIds());
			_requestUpdateDateTimeInfo.AddRange(FillStockResearchRequestIds());
			_requestUpdateDateTimeInfo.AddRange(FillStockFundamentalsRequestIds());
			_requestUpdateDateTimeInfo.AddRange(FillForexCurrenciesRequestIds());
			_requestUpdateDateTimeInfo.AddRange(FillCommoditiesRequestIds());
			_requestUpdateDateTimeInfo.AddRange(FillEconomicDataRequestIds());
			_requestUpdateDateTimeInfo.AddRange(FillOptionsRequestIds());
			_requestUpdateDateTimeInfo.AddRange(FillTreasuriesRequestIds());
			_requestUpdateDateTimeInfo.AddRange(FillFuturesRequestIdConstants());

			 _requestUpdateDateTimeInfos = _requestUpdateDateTimeInfo
				.GroupBy(x => x.RequestId)
				.ToDictionary(x => x.Key, x => x.ToArray());
		}

		public static DateTime GetClosestDateToUpdate(string requestId, DateTime now)
		{
			var datesToUpdate = new List<DateTime>();

			_requestUpdateDateTimeInfos.TryGetValue(requestId, out var datesInfo);

			if (datesInfo?.Any() != true)
				throw new NullReferenceException();

			foreach (var dateInfo in datesInfo)
			{
				var updateTimes = dateInfo.UpdateTimeAtList.Select(x => now.ToString(x));

				foreach (var updateTime in updateTimes)
				{
					datesToUpdate.AddRange(DateTime.Parse(updateTime).StartOfWeeks(dateInfo.DaysOfWeek));
				}
			}

			var closestDateInFuture = datesToUpdate.Where(d => d > now).OrderBy(d => d).First();

			return closestDateInFuture;
		}

		// TODO: It's aplroximate schedule as we don't have everything in documentation of sandbox
		private static List<RequestUpdateDateTimeInfo> FillMarketInfoRequestIds()
		{
			return new List<RequestUpdateDateTimeInfo>
			{
				//-----------GetCollectionsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetCollectionsList,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetCollectionsSector,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetCollectionsTag,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetListAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetListMostactive,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetListGainers,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetListLosers,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetListIexvolume,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetListIexPercent,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetUpcomingDividendsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetUpcomingDividends,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetUpcomingEarningsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetUpcomingEarnings,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetUpcomingSplitsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetUpcomingSplits,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetUpcomingEventsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetUpcomingEvents,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetUpcomingIposAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetUpcomingIpos,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetUpcomingEventMarketAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetUpcomingEventMarket,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetUpcomingEarningsMarketAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetUpcomingEarningsMarket,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetUpcomingDividendsMarketAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetUpcomingDividendsMarket,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetUpcomingSplitsMarketAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetUpcomingSplitsMarket,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetUpcomingIposMarketAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetUpcomingIPOsMarket,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetMarketVolumeUSAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetMarketVolumeUS,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 07:45:00", "MM/dd/yyyy 08:45:00", "MM/dd/yyyy 09:45:00", "MM/dd/yyyy 10:45:00", "MM/dd/yyyy 11:45:00", "MM/dd/yyyy 12:45:00", "MM/dd/yyyy 13:45:00", "MM/dd/yyyy 14:45:00", "MM/dd/yyyy 15:45:00", "MM/dd/yyyy 16:45:00", "MM/dd/yyyy 17:15:00" },
				},
				//-----------GetSectorPerformanceAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetSectorPerformance,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 09:00:00", "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 11:00:00","MM/dd/yyyy 12:00:00", "MM/dd/yyyy 13:00:00", "MM/dd/yyyy 14:00:00", "MM/dd/yyyy 15:00:00", "MM/dd/yyyy 16:00:00", "MM/dd/yyyy 17:00:00" },
				},
				//-----------GetIPOCalendarAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetIPOCalendarTodayIpos,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 10:30:00", }
				},
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetIPOCalendarUpcomingIpos,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList =  new string[] { "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 10:30:00", }
				},
				//-----------GetEarningsToday-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetEarningsToday,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:00:00", "MM/dd/yyyy 11:30:00", "MM/dd/yyyy 12:00:00" },
				},
				//-----------GetMarketAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = MarketInfoRequestIdConstants.GetMarket,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 09:00:00", "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 11:00:00","MM/dd/yyyy 12:00:00", "MM/dd/yyyy 13:00:00", "MM/dd/yyyy 14:00:00", "MM/dd/yyyy 15:00:00", "MM/dd/yyyy 16:00:00", "MM/dd/yyyy 17:00:00" },
				},
			};
		}

		private static List<RequestUpdateDateTimeInfo> FillCorporateActionsRequestIds()
		{
			return new List<RequestUpdateDateTimeInfo>
			{
				//-----------GetBonusIssueAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CorporateActionsRequestIdConstants.GetBonusIssue,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 20:00:00" }
				},
				//-----------GetDistributionAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CorporateActionsRequestIdConstants.GetDistribution,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 20:00:00" }
				},
				//-----------GetDividendsAdvancedAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CorporateActionsRequestIdConstants.GetDividendsAdvanced,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 20:00:00" }
				},
				//-----------GetReturnOfCapitalAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CorporateActionsRequestIdConstants.GetReturnOfCapital,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 20:00:00" }
				},
				//-----------GetRightsIssueAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CorporateActionsRequestIdConstants.GetRightsIssue,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 20:00:00" }
				},
				//-----------GetRightToPurchaseAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CorporateActionsRequestIdConstants.GetRightToPurchase,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 20:00:00" }
				},
				//-----------GetSecurityReclassificationAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CorporateActionsRequestIdConstants.GetSecurityReclassification,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 20:00:00" }
				},
				//-----------GetSecuritySwapAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CorporateActionsRequestIdConstants.GetSecuritySwap,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 20:00:00" }
				},
				//-----------GetSpinOffAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CorporateActionsRequestIdConstants.GetSpinOff,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 20:00:00" }
				},
				//-----------GetSplitsAdvancedAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CorporateActionsRequestIdConstants.GetSplitsAdvanced,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 20:00:00" }
				},
				//-----------GetDividendsForecastAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CorporateActionsRequestIdConstants.GetDividendsForecast,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 9:00:00", "MM/dd/yyyy 10:00:00", "11:00:00", "12:00:00", "13:00:00", "14:00:00", "15:00:00", "16:00:00", "17:00:00" }
				}
			};
		}

		// TODO: It's aplroximate schedule as we don't have everything in documentation of sandbox
		private static List<RequestUpdateDateTimeInfo> FillStockPricesRequestIds()
		{
			return new List<RequestUpdateDateTimeInfo>
			{
				//-----------GetBookAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetBook,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetBookAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetDelayedQuote,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 04:30:00", "MM/dd/yyyy 05:30:00", "MM/dd/yyyy 06:30:00", "MM/dd/yyyy 07:30:00", "MM/dd/yyyy 08:30:00", "MM/dd/yyyy 09:30:00", "MM/dd/yyyy 10:30:00", "MM/dd/yyyy 11:30:00","MM/dd/yyyy 12:30:00", "MM/dd/yyyy 13:30:00", "MM/dd/yyyy 14:30:00", "MM/dd/yyyy 15:30:00", "MM/dd/yyyy 16:30:00", "MM/dd/yyyy 17:30:00", "MM/dd/yyyy 18:30:00", "MM/dd/yyyy 19:30:00"  },
				},
				//-----------GetHistoricalPriceAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetHistoricalPrice,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 04:30:00"  },
				},
				//-----------GetHistoricalPriceByDateAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetHistoricalPriceByDate,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 04:30:00"  },
				},
				//-----------GetHistoricalPriceDynamicAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetHistoricalPriceDynamic,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 04:30:00"  }
				},				
				//-----------GetIntradayPricesAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetIntradayPrices,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:30:00", "MM/dd/yyyy 10:30:00", "MM/dd/yyyy 11:30:00","MM/dd/yyyy 12:30:00", "MM/dd/yyyy 13:30:00", "MM/dd/yyyy 14:30:00", "MM/dd/yyyy 15:30:00", "MM/dd/yyyy 16:00:00" }
				},
				//-----------GetLargestTradesAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetLargestTrades,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:30:00", "MM/dd/yyyy 10:30:00", "MM/dd/yyyy 11:30:00","MM/dd/yyyy 12:30:00", "MM/dd/yyyy 13:30:00", "MM/dd/yyyy 14:30:00", "MM/dd/yyyy 15:30:00", "MM/dd/yyyy 16:00:00" },
				},
				//-----------GetOHLCAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetOHLC,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:30:00", "MM/dd/yyyy 10:30:00", "MM/dd/yyyy 11:30:00","MM/dd/yyyy 12:30:00", "MM/dd/yyyy 13:30:00", "MM/dd/yyyy 14:30:00", "MM/dd/yyyy 15:30:00", "MM/dd/yyyy 16:30:00", "MM/dd/yyyy 17:00:00" }
				},
				//-----------GetPreviousDayPriceAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetPreviousDayPrice,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 04:30:00"  }
				},
				//-----------GetPriceAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetPrice,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 04:30:00", "MM/dd/yyyy 05:30:00", "MM/dd/yyyy 06:30:00", "MM/dd/yyyy 07:30:00", "MM/dd/yyyy 08:30:00", "MM/dd/yyyy 09:30:00", "MM/dd/yyyy 10:30:00", "MM/dd/yyyy 11:30:00","MM/dd/yyyy 12:30:00", "MM/dd/yyyy 13:30:00", "MM/dd/yyyy 14:30:00", "MM/dd/yyyy 15:30:00", "MM/dd/yyyy 16:30:00", "MM/dd/yyyy 17:30:00", "MM/dd/yyyy 18:30:00", "MM/dd/yyyy 19:30:00"  },
				},
				//-----------GetQuateAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetQuote,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 04:30:00", "MM/dd/yyyy 05:30:00", "MM/dd/yyyy 06:30:00", "MM/dd/yyyy 07:30:00", "MM/dd/yyyy 08:30:00", "MM/dd/yyyy 09:30:00", "MM/dd/yyyy 10:30:00", "MM/dd/yyyy 11:30:00","MM/dd/yyyy 12:30:00", "MM/dd/yyyy 13:30:00", "MM/dd/yyyy 14:30:00", "MM/dd/yyyy 15:30:00", "MM/dd/yyyy 16:30:00", "MM/dd/yyyy 17:30:00", "MM/dd/yyyy 18:30:00", "MM/dd/yyyy 19:30:00"  },
				},
				//-----------GetQuateFieldAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetQuoteField,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 04:30:00", "MM/dd/yyyy 05:30:00", "MM/dd/yyyy 06:30:00", "MM/dd/yyyy 07:30:00", "MM/dd/yyyy 08:30:00", "MM/dd/yyyy 09:30:00", "MM/dd/yyyy 10:30:00", "MM/dd/yyyy 11:30:00","MM/dd/yyyy 12:30:00", "MM/dd/yyyy 13:30:00", "MM/dd/yyyy 14:30:00", "MM/dd/yyyy 15:30:00", "MM/dd/yyyy 16:30:00", "MM/dd/yyyy 17:30:00", "MM/dd/yyyy 18:30:00", "MM/dd/yyyy 19:30:00"  },
				},
				//-----------GetVolumeByVenueAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetVolumeByVenue,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:30:00", "MM/dd/yyyy 10:30:00", "MM/dd/yyyy 11:30:00","MM/dd/yyyy 12:30:00", "MM/dd/yyyy 13:30:00", "MM/dd/yyyy 14:30:00", "MM/dd/yyyy 15:30:00", "MM/dd/yyyy 16:00:00" },
				},
				//-----------GetQuoteStream-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockPricesRequestIdConstants.GetQuoteStream,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 04:30:00", "MM/dd/yyyy 05:30:00", "MM/dd/yyyy 06:30:00", "MM/dd/yyyy 07:30:00", "MM/dd/yyyy 08:30:00", "MM/dd/yyyy 09:30:00", "MM/dd/yyyy 10:30:00", "MM/dd/yyyy 11:30:00","MM/dd/yyyy 12:30:00", "MM/dd/yyyy 13:30:00", "MM/dd/yyyy 14:30:00", "MM/dd/yyyy 15:30:00", "MM/dd/yyyy 16:30:00", "MM/dd/yyyy 17:30:00", "MM/dd/yyyy 18:30:00", "MM/dd/yyyy 19:30:00"  }
				},
			};
		}

		private static List<RequestUpdateDateTimeInfo> FillTreasuriesRequestIds()
		{
			return new List<RequestUpdateDateTimeInfo>
			{
				//-----------GetTimeSeriesAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = TreasuriesRequestIdConstants.GetTimeSeries,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 06:00:00", "MM/dd/yyyy 11:00:00" }
				},
				//-----------GetDataPointAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = TreasuriesRequestIdConstants.GetDataPoint,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 06:00:00", "MM/dd/yyyy 11:00:00" }
				}
			};
		}

		private static List<RequestUpdateDateTimeInfo> FillCommoditiesRequestIds()
		{
			return new List<RequestUpdateDateTimeInfo>
			{
				//-----------GetTimeSeriesAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CommoditiesRequestIdConstants.GetTimeSeries,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 06:00:00" }
				},
				//-----------GetDataPointAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CommoditiesRequestIdConstants.GetDataPoint,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 06:00:00" }
				}
			};
		}

		private static List<RequestUpdateDateTimeInfo> FillEconomicDataRequestIds()
		{
			return new List<RequestUpdateDateTimeInfo>
			{
				//-----------GetTimeSeriesAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = EconomicDataRequestIdConstants.GetTimeSeries,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 06:00:00" }
				},
				//-----------GetDataPointAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = EconomicDataRequestIdConstants.GetDataPoint,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 06:00:00" }
				}
			};
		}

		private static List<RequestUpdateDateTimeInfo> FillForexCurrenciesRequestIds()
		{
			return new List<RequestUpdateDateTimeInfo>
			{
				//-----------GetHistoricalDailyAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = ForexCurrenciesRequestIdConstants.GetHistoricalDaily,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 01:00:00" }
				},
				//-----------GetLatestRatesAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = ForexCurrenciesRequestIdConstants.GetLatestRates,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 17:00:00" }
				},
				//-----------ConvertAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = ForexCurrenciesRequestIdConstants.Convert,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 17:00:00" }
				},
				//-----------GetExchangeRateAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = ForexCurrenciesRequestIdConstants.GetExchangeRate,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 17:00:00" }
				}
			};
		}

		
		private static List<RequestUpdateDateTimeInfo> FillOptionsRequestIds()
		{
			return new List<RequestUpdateDateTimeInfo>
			{
				//-----------GetOptionsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = OptionsRequestIdConstants.Options,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },                    
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:30:00" }
				},				
				//-----------GetOptionsWithExpirationAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = OptionsRequestIdConstants.OptionsWithExpiration,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:30:00" }
				},				
				//-----------GetOptionsWithOptionSideAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = OptionsRequestIdConstants.OptionsWithOptionSide,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:30:00" }
				},
			};
		}

		private static List<RequestUpdateDateTimeInfo> FillCeoCompensationsRequestIds()
		{
			return new List<RequestUpdateDateTimeInfo>
			{
				//-----------GetCeoCompensationAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = CeoCompensationRequestIdConstants.GetCeoCompensation,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 01:00:00" }
				}
			};
		}

		private static List<RequestUpdateDateTimeInfo> FillFuturesRequestIdConstants()
		{
			return new List<RequestUpdateDateTimeInfo>
			{
				//-----------GetFuturesRequestIdConstantsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = FuturesRequestIdConstants.GetEndOfDayFutures,
					DaysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:35:00" }
				}
			};
		}

		private static List<RequestUpdateDateTimeInfo> FillStockResearchRequestIds()
		{
			return new List<RequestUpdateDateTimeInfo>
			{
				//-----------GetAdvancedStatsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockResearchRequestIdConstants.GetAdvancedStats,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 04:00:00", "MM/dd/yyyy 05:00:00" }
				},
				//-----------GetAnalystRecommendationsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockResearchRequestIdConstants.GetAnalystRecommendations,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:00:00", "MM/dd/yyyy 11:00:00", "MM/dd/yyyy 12:00:00" }
				},
				//-----------GetEstimatesAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockResearchRequestIdConstants.GetEstimates,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:00:00", "MM/dd/yyyy 11:00:00", "MM/dd/yyyy 12:00:00" }
				},
				//-----------GetEstimateFieldAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockResearchRequestIdConstants.GetEstimateField,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:00:00", "MM/dd/yyyy 11:00:00", "MM/dd/yyyy 12:00:00" }
				},
				//-----------GetFundOwnershipAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockResearchRequestIdConstants.GetFundOwnership,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 06:00:00" }
				},
				//-----------GetInstitutionalOwnerShipAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockResearchRequestIdConstants.GetInstitutionalOwnerShip,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 06:00:00" }
				},
				//-----------GetKeyStatsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockResearchRequestIdConstants.GetKeyStats,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 09:00:00" }
				},
				//-----------GetKeyStatsStatAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockResearchRequestIdConstants.GetKeyStatsStat,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 09:00:00" }
				},
				//-----------GetPriceTargetAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockResearchRequestIdConstants.GetPriceTarget,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 10:00:00", "MM/dd/yyyy 11:00:00", "MM/dd/yyyy 12:00:00" }
				},
				//-----------GetTechnicalIndicatorsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockResearchRequestIdConstants.GetTechnicalIndicators,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:00:00" }
				},
				//-----------GetRelevantStocksAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockResearchRequestIdConstants.GetRelevantStocks,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:00:00" }
				},
			};
		}

		private static List<RequestUpdateDateTimeInfo> FillStockProfilesRequestIds()
		{
			return new List<RequestUpdateDateTimeInfo>
			{
				//-----------GetCompanyAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockProfilesRequestIdConstants.GetCompany,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 04:00:00", "MM/dd/yyyy 05:00:00" }
				},
				//-----------GetInsiderRosterAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockProfilesRequestIdConstants.GetInsiderRoster,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 06:00:00" }
				},
				//-----------GetInsiderSummaryAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockProfilesRequestIdConstants.GetInsiderSummary,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 05:00:00", "MM/dd/yyyy 06:00:00" }
				},
				//-----------GetInsiderTransactionsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockProfilesRequestIdConstants.GetInsiderTransactions,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 04:00:00", "MM/dd/yyyy 05:00:00" }
				},
				//-----------GetLogoAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockProfilesRequestIdConstants.GetLogo,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00" }
				},
				//-----------GetPeerGroupsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockProfilesRequestIdConstants.GetPeerGroups,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00" }
				}
			};
		}

		private static List<RequestUpdateDateTimeInfo> FillStockFundamentalsRequestIds()
		{
			return new List<RequestUpdateDateTimeInfo>
			{
				//-----------GetAdvancedFundamentalsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetAdvancedFundamentals,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 12:30:00" }
				},
				//-----------GetFundamentalValuationsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetFundamentalValuations,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 06:00:00", "MM/dd/yyyy 07:00:00", "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 11:00:00", "MM/dd/yyyy 12:00:00", "MM/dd/yyyy 15:00:00" }
				},
				//-----------GetBalanceSheetAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetBalanceSheet,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 09:00:00" }
				},
				//-----------GetBalanceSheetFieldAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetBalanceSheetField,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 09:00:00" }
				},
				//-----------GetCashFlowAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetCashFlow,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 09:00:00" }
				},
				//-----------GetCashFlowFieldAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetCashFlowField,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 09:00:00" }
				},
				//-----------GetDividendsBasicAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetDividendsBasic,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:00:00" }
				},
				//-----------GetEarningAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetEarning,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:00:00", "MM/dd/yyyy 11:00:00", "MM/dd/yyyy 12:00:00" }
				},
				//-----------GetEarningFieldAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetEarningField,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:00:00", "MM/dd/yyyy 11:00:00", "MM/dd/yyyy 12:00:00" }
				},
				//-----------GetFinancialAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetFinancial,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 09:00:00" }
				},
				//-----------GetFinancialFieldAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetFinancialField,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 09:00:00" }
				},
				//-----------GetIncomeStatementAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetIncomeStatement,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 09:00:00" }
				},
				//-----------GetIncomeStatementFieldAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetIncomeStatementField,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 08:00:00", "MM/dd/yyyy 09:00:00" }
				},
				//-----------GetReportedFinancialsAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetReportedFinancials,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:00:00" }
				},
				//-----------GetGetSplitsBasicAsync-----------//
				new RequestUpdateDateTimeInfo
				{
					RequestId = StockFundamentalsRequestIdConstants.GetSplitsBasic,
					DaysOfWeek = _allWeekDays,
					UpdateTimeAtList = new string[] { "MM/dd/yyyy 09:00:00" }
				}
			};
		}
	}
}
