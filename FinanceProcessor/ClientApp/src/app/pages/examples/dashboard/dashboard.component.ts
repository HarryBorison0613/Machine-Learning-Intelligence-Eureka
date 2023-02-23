import { Component, OnDestroy, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';

import { Table } from "primeng/table";
import Chart from "chart.js";

import { DashboardService } from "../../service/dashboardservice";
import { StockService } from "../../service/stockservice";
import { AdvancedStat, IntradayPriceForMostPopularSymbols, KeyStat, MarketVolume, Split, SplitsBasic, VolumeByVenue } from "../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";
@Component({
  selector: "app-dashboard",
  templateUrl: "./dashboard.component.html",
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  public canvas1: any;
  public canvas2: any;
  public canvas3: any;
  public ctx1: any;
  public ctx2: any;
  public ctx3: any;
  public datasets: any;
  public data: any;
  public myChartData;
  public type: string;

  listLast: number = 5000;
  temp = [];
  rows: any = [];
  activeRow: any;
  selectedSymbol: any;
  filteredSymbols: any[];

  //Common
  symbols: string[];
  rangesBasic: any[];
  ranges: any[];
  periods: any[];
  calendarOptions: any[];
  chartRanges: any[];
  collectionTypes: any[];
  collectionNames: any[];
  timeSeriesPeriods: any[];
  statuses: any[];
  getRealTimeChart: any;
  ipoTypes: any[];
  initialSymbols: string[];
  
  //Gainers
  gainers: any[];
  gainerloading: boolean = true;

  //Losers
  losers: any[];
  loserloading: boolean = true;
  selectedBiggestGainersSymbol: string;

  //Sector Performance
  sectors: any[];
  sectorloading: boolean = true;
  volumes: any[];
  volumeloading: boolean = true;
  loading: boolean = true;

  //BalanceSheet
  sheetloading: boolean = true;
  selectedSheetSymbol: string;
  selectedSheetPeriod: string;
  balancesheets: any[] = [];
  //BonusIssues
  bonusIssues: any[];
  bonusissueloading: boolean = true;
  selectedRange: string;
  selectedCalendarOption: string;
  selectedBonusIssueLast: number;

  //Books
  trades: any[] = [];
  tradesloading: boolean = true;
  selectedBookSymbol: string;

  //Cashflow
  cashflow: any[] = [];
  cashflowloading: boolean = true;
  selectedCashflowSymbol: string;
  selectedCashflowPeriod: string;

  //Collections
  selectedCollectionType: string;
  selectedCollectionName: string;
  collections: any[];
  collectionsloading: boolean = true;

  //Delayed Quote
  selectedDQuoteSymbol: string;
  dQuote: any[] = [];
  dQuoteloading: boolean = true;

  //Distribution
  distributionList: any[];
  selectedDistributionRange: string;
  selectedDistributionCalendarOption: boolean;
  selectedDistributionLast: number;
  distributionLoading: boolean = true;

  //Dividends
  dividends: any[];
  selectedDividendsRange: string;
  selectedDividendsCalendarOption: boolean;
  selectedDividendsLast: number;
  dividendsLoading: boolean = true;

  //Dividends-Basic
  dividendsBasics: any[] = [];
  selectedDividendsBasicSymbol: string;
  selectedDividendsBasicPeriod: string;
  dividendsBasicLoading: boolean = true;

  //Financials
  financials: any[] = [];
  selectedFinancialsSymbol: string;
  selectedFinancialsLast: number;
  financialsLoading: boolean = true;
  
  //CEO-Compensation
  ceo: any[] = [];
  ceoLoading: boolean = true;
  selectedCeoSymbol: string;

  //Reported Financials
  selectedReportedFinancialsSymbol: string;
  selectedReportedFinancialsPeriod: string;
  reportedFinancials: any[] = [];
  reportedFinancialsLoading: boolean = true;

  //Fundamentals
  selectedFundamentalsSymbol: string;
  selectedFundamentalsPeriod: string;
  fundamentals: any[] = [];
  fundamentalsLoading: boolean = true;

  //Insider Rosters
  selectedInsiderRosterSymbol: string;
  insiderRosters: any[] = [];
  insiderRostersLoading: boolean = true;

  //Insider Summary
  selectedInsiderSummarySymbol: string;
  insiderSummary: any[] = [];
  insiderSummaryLoading: boolean = true;

  //Insider Transactions
  selectedInsiderTransactionSymbol: string;
  insiderTransactions: any[] = [];
  insiderTransactionsLoading: boolean = true;

  //Intraday Prices
  selectedIntradayPricesSymbol: string;
  intradayPrices: any[] = [];
  intradayPricesLoading: boolean = true;

  //Dividends Forecast
  selectedDividendsForecastSymbol: string;
  dividendsForecast: any[] = [];
  dividendsForecastLoading: boolean = true;

  //Return Of Capital
  returnOfCapital: any[] = [];
  selectedReturnOfCapitalRange: string;
  selectedReturnOfCapitalCalendarOption: boolean;
  selectedReturnOfCapitalLast: number;
  returnOfCapitalLoading: boolean = true;

  //Right To Purchase
  rightToPurchase: any[] = [];
  selectedRightToPurchaseRange: string;
  selectedRightToPurchaseCalendarOption: boolean;
  selectedRightToPurchaseLast: number;
  rightToPurchaseLoading: boolean = true;

  //Rights Issue
  rightsIssue: any[] = [];
  selectedRightsIssueRange: string;
  selectedRightsIssueCalendarOption: boolean;
  selectedRightsIssueLast: number;
  rightsIssueLoading: boolean = true;

  //Security Reclassification
  securityReclassification: any[] = [];
  selectedSecurityReclassificationRange: string;
  selectedSecurityReclassificationCalendarOption: boolean;
  selectedSecurityReclassificatioinLast: number;
  securityReclassificationLoading: boolean = true;

  //Security Swap
  securitySwap: any[] = [];
  selectedSecuritySwapRange: string;
  selectedSecuritySwapCalendarOption: boolean;
  selectedSecuritySwapLast: number;
  securitySwapLoading: boolean = true;

  //Spinoff
  spinoff: any[] = [];
  selectedSpinoffRange: string;
  selectedSpinoffCalendarOption: boolean;
  selectedSpinoffLast: number;
  spinoffLoading: boolean = true;

  //Historical Prices
  selectedHistoricalPriceSymbol: string;
  selectedHistoricalPriceRange: string;
  historicalPrices: any[] = [];
  historicalPricesLoading: boolean = true;

  //Income Statements
  selectedIncomeStatementSymbol: string;
  selectedIncomeStatementPeriod: string;
  selectedIncomeStatementLast: number;
  incomeStatements: any[] = [];
  incomeStatementsLoading: boolean = true;

  //Upcoming Earnings
  upcomingEarnings: any[] = [];
  selectedUpcomingEarningsSymbol: string;
  upcomingEarningsLoading: boolean = true;

  //Upcoming Dividends
  upcomingDividends: any[] = [];
  selectedUpcomingDividendsSymbol: string;
  upcomingDividendsLoading: boolean = true;

  //Upcoming Splits
  upcomingSplits: any[] = [];
  selectedUpcomingSplitsSymbol: string;
  upcomingSplitsLoading: boolean = true;
  
  //Upcoming Ipos
  upcomingIpos: any[] = [];
  selectedUpcomingIposSymbol: string;
  upcomingIposLoading: boolean = true;
  viewData: any[];

  //Upcoming Dividends Market
  upcomingDividendsMarket: any[] = [];
  selectedUpcomingDividendsMarketSymbol: string;
  upcomingDividendsMarketLoading: boolean = true;

  //Upcoming Earnings Market
  upcomingEarningsMarket: any[] = [];
  selectedUpcomingEarningsMarketSymbol: string;
  upcomingEarningsMarketLoading: boolean = true;

  //Upcoming Splits Market
  upcomingSplitsMarket: any[] = [];
  selectedUpcomingSplitsMarketSymbol: string;
  upcomingSplitsMarketLoading: boolean = true;

  //Fundamental Valuations
  selectedFundamentalValuationsSymbol: string;
  selectedFundamentalValuationsPeriod: string;
  fundamentalValuations: any[] = [];
  fundamentalValuationsLoading: boolean = true;

  //Institutional Ownership
  selectedInstitutionalOwnershipSymbol: string;
  institutionalOwnership: any[] = [];
  institutionalOwnershipLoading: boolean = true;

  //Volume By Venue
  selectedVolumeByVenueSymbol: string;
  volumeByVenue: VolumeByVenue[] = [];
  volumeByVenueLoading: boolean = true;

  //Stats
  advancedStats: AdvancedStat[] = [];
  selectedAdvancedStatsSymbol: string;
  advancedStatsLoading: boolean = true;

  //Stats(basic)
  keyStats: KeyStat[] = [];
  selectedKeyStatsSymbol: string;
  keyStatsLoading: boolean = true;

  //Markets
  markets: MarketVolume[] = [];
  marketsLoading: boolean = true;

  //Company
  selectedCompanySymbol: string;
  companySummary: any[] = [];
  companyTags: string[];
  companyDescription: string;
  companyLoading: boolean = true;

  //Peer groups
  selectedPeerGroupsSymbol: string;
  peerGroups: any[] = [];
  peerGroupsLoading: boolean = true;

  //Previous Day Price
  selectedPreviousDayPriceSymbol: string;
  previousDayPrice: any[] = [];
  previousDayPriceLoading: boolean = true;

  //Quote
  selectedQuoteSymbol: string;
  quotes: any[] = [];
  quotesLoading: boolean = true;

  //Relevant Stocks
  selectedRelevantStocksSymbol: string;
  relevantStocks: any[] = [];
  relevantStocksLoading: boolean = true;

  //Splits
  splits: Split[] = [];
  selectedSplitsRange: string;
  selectedSplitsCalendarOption: boolean;
  selectedSplitsLast: number;
  splitsLoading: boolean = true;

  //Splits Basic
  splitsBasics: SplitsBasic[] = [];
  selectedSplitsBasicSymbol: string;
  selectedSplitsBasicRange: string;
  splitsBasicLoading: boolean = true;
  
  constructor(
    private http: HttpClient, 
    private stockService: StockService, 
    private dashboardService: DashboardService, 
    private globalVariable: GlobalVariable) {
      this.initialSymbols = ['AAPL', 'MSFT', 'GOOGL', 'TSLA', 'META', 'NFLX', 'TWTR', 'NVDA'];
    }

  ngOnInit() {
    this.onGlobalSearch(this.globalVariable.getGlobalSearchSymbolName());

    this.periods = [
      { label: 'Period', value: 'Annual' }, 
      { label: 'Annual', value: 'Annual' }, 
      { label: 'Quarter', value: 'Quarter' }
    ];
    this.rangesBasic = [
      { label: 'Range', value: 'Ytd' }, 
      { label: 'Next', value: 'Next' }, 
      { label: 'Ytd', value: 'Ytd' }, 
      { label: 'OneMonth', value: 'OneMonth' }, 
      { label: 'ThreeMonths', value: 'ThreeMonths' }, 
      { label: 'SixMonths', value: 'SixMonths' }, 
      { label: 'OneYear', value: 'OneYear' }, 
      { label: 'TwoYears', value: 'TwoYears' }, 
      { label: 'FiveYears', value: 'FiveYears' }
    ];
    this.ranges = [
      { label: 'Range', value: 'Ytd' }, 
      { label: 'Today', value: 'Today' }, 
      { label: 'Yesterday', value: 'Yesterday' }, 
      { label: 'Tomorrow', value: 'Tomorrow' }, 
      { label: 'Ytd', value: 'Ytd' }, 
      { label: 'OneMonth', value: 'OneMonth' }, 
      { label: 'ThreeMonths', value: 'ThreeMonths' }, 
      { label: 'SixMonths', value: 'SixMonths' },
      { label: 'OneYear', value: 'OneYear' }, 
      { label: 'TwoYears', value: 'TwoYears' }, 
      { label: 'FiveYears', value: 'FiveYears' }, 
      { label: 'This Week', value: 'This Week' }, 
      { label: 'ThisMonth', value: 'ThisMonth' }, 
      { label: 'ThisQuarter', value: 'ThisQuarter' },
      { label: 'LastWeek', value: 'LastWeek' }, 
      { label: 'LastMonth', value: 'LastMonth' }, 
      { label: 'LastQuarter', value: 'LastQuarter' }, 
      { label: 'NextWeek', value: 'NextWeek' }, 
      { label: 'NextMonth', value: 'NextMonth' }, 
      { label: 'NextQuarter', value: 'NextQuarter' }
    ];
    this.calendarOptions = [
      { label: 'Calendar', value: 'true' }, 
      { label: 'true', value: 'true' }, 
      { label: 'false', value: 'false '},
    ];
    this.chartRanges = [
      { label: 'Range', value: 'Ytd' },
      { label: 'Dynamic', value: 'Dynamic' },
      { label: 'Date', value: 'Date' },
      { label: 'FiveDayMinute', value: 'FiveDayMinute' },
      { label: 'FiveDay', value: 'FiveDay' },
      { label: 'OneMonthMinute', value: 'OneMonthMinute' },
      { label: 'OneMonth', value: 'OneMonth' },
      { label: 'ThreeMonths', value: 'ThreeMonths' },
      { label: 'SixMonths', value: 'SixMonths' },
    ];
    this.collectionTypes = ['Sector','Tag','List'];
    this.collectionNames = ['Technology','Energy','Financials','Materials','consumer Discretionary','Communication Services','Health Care','Utilities','Real Estate','Industries'];
    this.timeSeriesPeriods = [
      {label: 'Period', value: 'Annual' },
      {label: 'Annual', value: 'Annual' },
      {label: 'Quarterly', value: 'Quarterly' },
      {label: 'Ttm', value: 'Ttm' },
    ];
    this.statuses = [
        {label: 'close', value: 'close'},
        {label: 'previousclose', value: 'previousclose'},
    ];
    this.ipoTypes = [
      {label: 'IPO type', value: 'Today'},
      {label: 'Today', value: 'Today'},
      {label: 'Upcoming', value: 'Upcoming'},
    ];
  }

  onGlobalSearch(symbol) {
    this.selectedSheetSymbol = symbol;
    this.selectedBiggestGainersSymbol = symbol;
    this.selectedSheetPeriod = 'Annual';
    this.selectedRange = 'OneYear';
    this.selectedCalendarOption = 'true';
    this.selectedBookSymbol = symbol;
    this.selectedCashflowSymbol = symbol;
    this.selectedCashflowPeriod = 'Annual';
    this.selectedCollectionType = 'Sector';
    this.selectedCollectionName = 'Technology';
    this.selectedDQuoteSymbol = symbol;
    this.selectedDistributionRange = 'OneYear';
    this.selectedDistributionCalendarOption = true;
    this.selectedDistributionLast = 10000;
    this.selectedDividendsRange = 'OneYear';
    this.selectedDividendsCalendarOption = true;
    this.selectedDividendsLast = 10000;
    this.selectedDividendsBasicSymbol = symbol;
    this.selectedDividendsBasicPeriod = 'OneYear';
    this.selectedFinancialsSymbol = symbol;
    this.selectedFinancialsLast = 10000;
    this.selectedCeoSymbol = symbol;
    this.selectedBonusIssueLast = 10000;
    this.selectedReportedFinancialsSymbol = symbol;
    this.selectedReportedFinancialsPeriod = 'Annual';
    this.selectedFundamentalsSymbol = symbol;
    this.selectedFundamentalsPeriod = 'Annual';
    this.selectedInsiderRosterSymbol = symbol;
    this.selectedInsiderSummarySymbol = symbol;
    this.selectedInsiderTransactionSymbol = symbol;
    this.selectedIntradayPricesSymbol = symbol;
    this.selectedDividendsForecastSymbol = symbol;
    this.selectedReturnOfCapitalRange = 'OneYear';
    this.selectedReturnOfCapitalCalendarOption = true;
    this.selectedReturnOfCapitalLast = 10000;
    this.selectedRightToPurchaseRange = 'OneYear';
    this.selectedRightToPurchaseCalendarOption = true;
    this.selectedRightToPurchaseLast = 10000;
    this.selectedSecurityReclassificationRange = 'Ytd';
    this.selectedSecurityReclassificationCalendarOption = true;
    this.selectedSecurityReclassificatioinLast = 10000;
    this.selectedSecuritySwapRange = 'OneYear';
    this.selectedSecuritySwapCalendarOption = true;
    this.selectedSecuritySwapLast = 10000;
    this.selectedRightsIssueRange = 'OneYear';
    this.selectedRightsIssueCalendarOption = true;
    this.selectedRightsIssueLast = 10000;
    this.selectedSpinoffRange = 'OneYear';
    this.selectedSpinoffCalendarOption = true;
    this.selectedSpinoffLast = 10000;
    this.selectedHistoricalPriceSymbol = symbol;
    this.selectedHistoricalPriceRange = 'Ytd';
    this.selectedIncomeStatementSymbol = symbol;
    this.selectedIncomeStatementPeriod = 'Annual';
    this.selectedIncomeStatementLast = 10000;
    this.selectedFundamentalValuationsSymbol = symbol;
    this.selectedFundamentalValuationsPeriod = 'Annual';
    this.selectedInstitutionalOwnershipSymbol = symbol;
    this.selectedVolumeByVenueSymbol = symbol;
    this.selectedAdvancedStatsSymbol = symbol;
    this.selectedKeyStatsSymbol = symbol;
    this.selectedCompanySymbol = symbol;
    this.selectedPeerGroupsSymbol = symbol;
    this.selectedPreviousDayPriceSymbol = symbol;
    this.selectedQuoteSymbol = symbol;
    this.selectedRelevantStocksSymbol = symbol;
    this.selectedSplitsRange = 'OneYear';
    this.selectedSplitsCalendarOption = true;
    this.selectedSplitsLast = 10000;
    this.selectedSplitsBasicSymbol = symbol;
    this.selectedSplitsBasicRange = 'Ytd';
    this.getAllData();
  }

  getAllData() {
    this.getIntradayPricesForMostPopularSymbol();
    this.getChartDataRealTime();
    this.getExistingSymbols();
    this.getGainers(this.listLast);
    this.getLosers(this.listLast);
    this.getSectors();
    this.getVolumes();
    this.getBalanceSheets(this.selectedSheetSymbol, this.selectedSheetPeriod);
    this.getBonusIssues(this.selectedRange, this.selectedCalendarOption, 10000);
    this.getStockBooks(this.selectedBookSymbol);
    this.getCashflow(this.selectedCashflowSymbol, this.selectedCashflowPeriod);
    this.getCollections(this.selectedCollectionType, this.selectedCollectionName);
    this.getDelayedQuote(this.selectedDQuoteSymbol);
    this.getDistributionList(this.selectedDistributionRange, this.selectedDistributionCalendarOption, this.selectedDistributionLast);
    this.getDividends(this.selectedDividendsRange, this.selectedDividendsCalendarOption, this.selectedDividendsLast);
    this.getDividendsBasic( this.selectedDividendsBasicSymbol, this.selectedDividendsBasicPeriod);
    this.getFinancials(this.selectedFinancialsSymbol, this.selectedFinancialsLast);
    this.getCeoCompensation(this.selectedCeoSymbol);
    this.getReportedFinancials(this.selectedReportedFinancialsSymbol, this.selectedReportedFinancialsPeriod);
    this.getFundamentals(this.selectedFundamentalsSymbol, this.selectedFundamentalsPeriod);
    this.getInsiderRosters(this.selectedInsiderRosterSymbol);
    this.getInsiderSummary(this.selectedInsiderSummarySymbol);
    this.getInsiderTransactions(this.selectedInsiderTransactionSymbol);
    this.getIntradayPrices(this.selectedIntradayPricesSymbol);
    this.getDividendsForecast(this.selectedDividendsForecastSymbol);
    this.getReturnOfCapital(this.selectedReturnOfCapitalRange, this.selectedReturnOfCapitalCalendarOption, this.selectedReturnOfCapitalLast);
    this.getRightToPurchase(this.selectedRightToPurchaseRange, this.selectedRightToPurchaseCalendarOption, this.selectedRightToPurchaseLast);
    this.getSecuritySwap(this.selectedSecuritySwapRange, this.selectedSecuritySwapCalendarOption, this.selectedSecuritySwapLast);
    this.getSecurityReclassification(this.selectedSecurityReclassificationRange, this.selectedSecurityReclassificationCalendarOption, this.selectedSecurityReclassificatioinLast);
    this.getRightsIssue(this.selectedRightsIssueRange, this.selectedRightsIssueCalendarOption, this.selectedRightsIssueLast);
    this.getSpinoff(this.selectedSpinoffRange, this.selectedSpinoffCalendarOption, this.selectedSpinoffLast);
    this.getHistoricalPrices(this.selectedHistoricalPriceSymbol, this.selectedHistoricalPriceRange);
    this.getIncomeStatements(this.selectedIncomeStatementSymbol, this.selectedIncomeStatementPeriod, this.selectedIncomeStatementLast);
    this.getUpcomingDividendsMarket();
    this.getUpcomingEarningsMarket();
    this.getUpcomingSplitsMarket();
    this.getFundamentalValuations(this.selectedFundamentalValuationsSymbol, this.selectedFundamentalValuationsPeriod);
    this.getInstitutionalOwnership(this.selectedInstitutionalOwnershipSymbol);
    this.getVolumeByVenue(this.selectedVolumeByVenueSymbol);
    this.getAdvancedStats( this.selectedAdvancedStatsSymbol);
    this.getKeyStats( this.selectedKeyStatsSymbol);
    this.getMarkets();
    this.getCompany(this.selectedCompanySymbol);
    this.getPeerGroups(this.selectedPeerGroupsSymbol);
    this.getPreviousDayPrice(this.selectedPreviousDayPriceSymbol);
    this.getQuote(this.selectedQuoteSymbol);
    this.getRelevantStocks(this.selectedRelevantStocksSymbol);
    this.getSplits(this.selectedSplitsRange, this.selectedSplitsCalendarOption, this.selectedSplitsLast);
    this.getSplitsBasic( this.selectedSplitsBasicSymbol, this.selectedSplitsBasicRange);
  }

  filterSymbol(event) {
    let filtered: any[] = [];
    let query = event.query;
    for (let i = 0; i < this.symbols.length; i++) {
      let symbol = this.symbols[i];
      if (symbol.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(symbol);
      }
    }
    this.filteredSymbols = filtered;
  }

  public getGainers(limit): void {
    this.gainerloading = true;
    this.dashboardService.getGainers(limit).then(gainers => {
      this.gainers = gainers;
      this.gainers.map(gainer => gainer.changePercent = Math.round((gainer.changePercent + Number.EPSILON) * 10000) / 100);
      this.gainerloading = false;
    }).catch(() => {
      this.gainers = [];
      this.gainerloading = false;
    });
  }

  public getLosers(limit): void {
    this.loserloading = true;
    this.dashboardService.getLosers(limit).then(losers => {
      this.losers = losers;
      this.losers.map(loser => {
        loser.changePercent = Math.round((loser.changePercent + Number.EPSILON) * 10000) / 100;
      });
      this.loserloading = false;
    }).catch(() => {
      this.losers = [];
      this.loserloading = false;
    });
  }

  public getSectors(): void {
    this.sectorloading = true;
    this.dashboardService.getSectors().then(sectors => {
      this.sectors = sectors;
      this.sectors.forEach(sector => {
        sector.performance = Math.round((sector.performance + Number.EPSILON) * 10000) / 100;
      });
      this.sectorloading = false;
    }).catch(() => {
      this.sectors = [];
      this.sectorloading = false;
    });
  }

  public getVolumes(): void {
    this.volumeloading = true;
    this.dashboardService.getVolumes().then(volumes => {
      this.volumes = volumes;
      this.volumes.forEach(volume => {
        volume.marketPercent = Math.round((volume.marketPercent + Number.EPSILON) * 10000) / 100;
      });
      this.volumeloading = false;
    }).catch(() => {
      this.volumes = [];
      this.volumeloading = false;
    });
  }

  getBalanceSheets(symbol, period): void {
    if(symbol === "" || symbol === undefined)  {
      this.sheetloading = false;
      return;
    }
    this.sheetloading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getBalanceSheets(symbol, period).then(sheets => {
        sheets.forEach(sheet => {
          sheet.symbol = symbol;
        });
        this.balancesheets = this.balancesheets.concat(sheets);
        this.sheetloading = false;
      }).catch(() => {
        this.sheetloading = false;
      });
    });
  }

  getBonusIssues(ran, cal, last) {
    this.bonusissueloading = true;
    this.stockService.getBonusIssues(ran, cal, last).then(issues => {
      this.bonusIssues = issues;
      this.bonusissueloading = false;
    }).catch(() => {
      this.bonusIssues = [];
      this.bonusissueloading = false;
    });
  }

  getStockBooks(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.tradesloading = false;
      return;
    }
    this.tradesloading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getStockBooks(symbol).then(res => {
        res.trades.forEach(item => item.symbol = symbol);
        this.trades = this.trades.concat(res.trades);
        this.tradesloading = false;
      }).catch(() => {
        this.tradesloading = false;
      });
    });
  }

  getCashflow(symbol, period) {
    if(symbol === "" || symbol === undefined)  {
      this.cashflowloading = false;
      return;
    }
    this.cashflowloading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getCashflow(symbol, period).then(res => {
        res.cashflow.forEach(cashflow => {
          cashflow.symbol = symbol;
        });
        this.cashflow = this.cashflow.concat(res.cashflow);
        this.cashflowloading = false;
        }).catch(() => {
          this.cashflowloading = false;
      });
    });
}

  getCollections(type, name) {
    this.collectionsloading = true;
    this.stockService.getCollections(type, name).then(collections => {
      this.collections = collections;
      this.collectionsloading = false;
    }).catch(() => {
      this.collections = [];
      this.collectionsloading = false;
    });
  }

  getDelayedQuote(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.dQuoteloading = false;
      return;
    }
    this.dQuoteloading = true;
    this.dQuote = [];
    this.initialSymbols.forEach(symbol => {
      this.stockService.getDelayedQuote(symbol).then(item => {
        item.symbol = symbol;
        this.dQuote.push(item);
        this.dQuoteloading = false;
      }).catch(() => {
        this.dQuoteloading = false;
      });
    });
  }

  getDistributionList(ran, cal, last) {
    this.distributionLoading = true;
    this.stockService.getDistributionList(ran, cal, last).then(distributionList => {
      this.distributionList = [...distributionList];
      this.distributionList.map(item => {
        item.description = item.description.slice(0,30) + '...';
      });
      this.distributionLoading = false;
    }).catch(() => {
      this.distributionList = [];
      this.distributionLoading = false;
    });
  }

  getDividends(ran, cal, last) {
    this.dividendsLoading = true;
    this.stockService.getDividends(ran, cal, last).then(issues => {
      this.dividends = issues;
      this.dividendsLoading = false;
    }).catch(() => {
      this.dividends = [];
      this.dividendsLoading = false;
    });
  }

  getDividendsBasic(symbol, range) {
    if(symbol === "" || symbol === undefined)  {
      this.dividendsBasicLoading = false;
      return;
    }
    this.dividendsBasicLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getDividendsBasic(symbol, range).then(collections => {
        this.dividendsBasics = this.dividendsBasics.concat(collections);
        this.dividendsBasicLoading = false;
      }).catch(() => {
        this.dividendsBasicLoading = false;
      });
    });
  }

  getFinancials(symbol, last) {
    if(symbol === "" || symbol === undefined)  {
      this.financialsLoading = false;
      return;
    }
    this.financialsLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getFinancials(symbol, last).then(financials => {
        this.financials = this.financials.concat(financials);
        this.financialsLoading = false;
      }).catch(() => {
        this.financialsLoading = false;
      });
    });
  }

  getCeoCompensation(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.ceoLoading = false;
      return;
    }
    this.ceoLoading = true;
    this.ceo = [];
    this.initialSymbols.forEach(symbol => {
      this.stockService.getCeoCompensation(symbol).then(ceo => {
        if(ceo === undefined || ceo === null)  return;
        this.ceo.push(ceo);
        this.ceoLoading = false;
      }).catch(() => {
        this.ceoLoading = false;
      });
    });
  }

  getReportedFinancials(symbol, period) {
    if(symbol === "" || symbol === undefined)  {
      this.reportedFinancialsLoading = false;
      return;
    }
    this.reportedFinancialsLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getReportedFinancials(symbol, period).then(collections => {
        collections.map(collection => collection.symbol = symbol);
        this.reportedFinancials = this.reportedFinancials.concat(collections);
        this.reportedFinancialsLoading = false;
      }).catch(() => {
        this.reportedFinancialsLoading = false;
      });
    });
  }

  getFundamentals(symbol, period) {
    this.fundamentalsLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getFundamentals(symbol, period).then(collections => {
        this.fundamentals = this.fundamentals.concat(collections);
        this.fundamentalsLoading = false;
      }).catch(() => {
        this.fundamentalsLoading = false;
      });
    });
  }

  getInsiderRosters(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.insiderRostersLoading = false;
      return;
    }
    this.insiderRostersLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getInsiderRosters(symbol).then(collections => {
        collections.map(collections => collections.symbol = symbol);
        this.insiderRosters = this.insiderRosters.concat(collections);
        this.insiderRostersLoading = false;
      }).catch(() => {
        this.insiderRostersLoading = false;
      });
    })
  }

  getInsiderSummary(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.insiderSummaryLoading = false;
      return;
    }
    this.insiderSummaryLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getInsiderSummary(symbol).then(collections => {
        this.insiderSummary = this.insiderSummary.concat(collections);
        this.insiderSummaryLoading = false;
      }).catch(() => {
        this.insiderSummaryLoading = false;
      });
    });
  }

  getInsiderTransactions(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.insiderTransactionsLoading = false;
      return;
    }
    this.insiderTransactionsLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getInsiderTransactions(symbol).then(collections => {
        this.insiderTransactions = this.insiderTransactions.concat(collections);
        this.insiderTransactionsLoading = false;
      }).catch(() => {
        this.insiderTransactionsLoading = false;
      });
    });
  }

  getIntradayPrices(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.intradayPricesLoading = false;
      return;
    }
    this.intradayPricesLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getIntradayPrices(symbol).then(collections => {
        collections.map(collections => collections.symbol = symbol);
        this.intradayPrices = this.intradayPrices.concat(collections);
        this.intradayPricesLoading = false;
      }).catch(() => {
        this.intradayPricesLoading = false;
      });
    });
  }

  getDividendsForecast(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.dividendsForecastLoading = false;
      return;
    }
    this.dividendsForecastLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getDividendsForecast(symbol).then(collections => {
        this.dividendsForecast = this.dividendsForecast.concat(collections);
        this.dividendsForecastLoading = false;
      }).catch(() => {
        this.dividendsForecastLoading = false;
      });
    });
  }

  getReturnOfCapital(ran, cal, last) {
    this.returnOfCapitalLoading = true;
    this.stockService.getReturnOfCapital(ran, cal, last).then(collections => {
      this.returnOfCapital = collections;
      this.returnOfCapitalLoading = false;
    }).catch(() => {
      this.returnOfCapitalLoading = false;
    });
  }

  getRightToPurchase(ran, cal, last) {
    this.rightToPurchaseLoading = true;
    this.stockService.getRightToPurchase(ran, cal, last).then(collections => {
      this.rightToPurchase = collections;
      this.rightToPurchaseLoading = false;
    }).catch(() => {
      this.rightToPurchase = [];
      this.rightToPurchaseLoading = false;
    });
  }

  getRightsIssue(ran, cal, last) {
    this.rightsIssueLoading = true;
    this.stockService.getRightsIssue(ran, cal, last).then(collections => {
      this.rightsIssue = collections;
      this.rightsIssueLoading = false;
    }).catch(() => {
      this.rightsIssue = [];
      this.rightsIssueLoading = false;
    });
  }

  getSecurityReclassification(ran, cal, last) {
    this.securityReclassificationLoading = true;
    this.stockService.getSecurityReclassification(ran, cal, last).then(collections => {
      this.securityReclassification = collections;
      this.securityReclassificationLoading = false;
    }).catch(() => {
      this.securityReclassification = [];
      this.securityReclassificationLoading = false;
    });
  }

  getSecuritySwap(ran, cal, last) {
    this.securitySwapLoading = true;
    this.stockService.getSecuritySwap(ran, cal, last).then(collections => {
      this.securitySwap = collections;
      this.securitySwapLoading = false;
    }).catch(() => {
      this.securitySwap = [];
      this.securitySwapLoading = false;
    });
  }

  getSpinoff(ran, cal, last) {
    this.spinoffLoading = true;
    this.stockService.getSpinoff(ran, cal, last).then(collections => {
      this.spinoff = collections;
      this.spinoffLoading = false;
    }).catch(() => {
      this.spinoff = [];
      this.spinoffLoading = false;
    });
  }

  getHistoricalPrices(symbol, range) {
    if(symbol === "" || symbol === undefined)  {
      this.historicalPricesLoading = false;
      return;
    }
    this.historicalPricesLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getHistoricalPrices(symbol, range).then(collections => {
        collections.forEach(item => {
          item.symbol = symbol;
          item.changePercent = Math.round((item.changePercent + Number.EPSILON) * 10000) / 100;
        });
        this.historicalPrices = this.historicalPrices.concat(collections);
        this.historicalPricesLoading = false;
      }).catch(() => {
        this.historicalPricesLoading = false;
      });
    });
  }

  getIncomeStatements(symbol, period, last) {
    if(symbol === "" || symbol === undefined)  {
      this.incomeStatementsLoading = false;
      return;
    }
    this.incomeStatementsLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getIncomeStatements(symbol, period, last).then(collections => {
        collections.forEach(item => {
          item.symbol = symbol;
        });
        this.incomeStatements = this.incomeStatements.concat(collections);
        this.incomeStatementsLoading = false;
      }).catch(() => {
        this.incomeStatementsLoading = false;
      });
    });
  }

  getUpcomingDividendsMarket() {
    this.upcomingDividendsMarketLoading = true;
    this.stockService.getUpcomingDividendsMarket().then(collections => {
      this.upcomingDividendsMarket= collections;
      this.upcomingDividendsMarketLoading = false;
    }).catch(() => {
      this.upcomingDividendsMarketLoading = false;
    });
  }

  getUpcomingEarningsMarket() {
    this.upcomingEarningsMarketLoading = true;
    this.stockService.getUpcomingEarningsMarket().then(collections => {
      this.upcomingEarningsMarket = collections;
      this.upcomingEarningsMarketLoading = false;
    }).catch(() => {
      this.upcomingEarningsMarketLoading = false;
    });
  }

  getUpcomingSplitsMarket() {
    this.upcomingSplitsMarketLoading = true;
    this.stockService.getUpcomingSplitsMarket().then(collections => {
      this.upcomingSplitsMarket = collections;
      this.upcomingSplitsMarketLoading = false;
    }).catch(() => {
      this.upcomingSplitsMarketLoading = false;
    });
  }

  getFundamentalValuations(symbol, period) {
    if(symbol === "" || symbol === undefined)  {
      this.fundamentalValuationsLoading = false;
      return;
    }
    this.fundamentalValuationsLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getFundamentalValuations(symbol, period).then(collections => {
        this.fundamentalValuations = this.fundamentalValuations.concat(collections);
        this.fundamentalValuationsLoading = false;
      }).catch(() => {
        this.fundamentalValuationsLoading = false;
      });
    });
  }

  getInstitutionalOwnership(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.institutionalOwnershipLoading = false;
      return;
    }
    this.institutionalOwnershipLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getInstitutionalOwnership(symbol).then(collections => {
        this.institutionalOwnership = this.institutionalOwnership.concat(collections);
        this.institutionalOwnershipLoading = false;
      }).catch(() => {
        this.institutionalOwnershipLoading = false;
      });
    });
  }

  getVolumeByVenue(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.volumeByVenueLoading = false;
      return;
    }
    this.volumeByVenueLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getVolumeByVenue(symbol).then(collections => {
        collections.map(item => {
          item.symbol = symbol;
          item.marketPercent = Math.round((item.marketPercent + Number.EPSILON)*10000)/100;
          item.avgMarketPercent = Math.round((item.avgMarketPercent + Number.EPSILON)*10000)/100;
        });
        this.volumeByVenue = this.volumeByVenue.concat(collections);
        this.volumeByVenueLoading = false;
      }).catch(() => {
        this.volumeByVenueLoading = false;
      });
    });
  }

  getAdvancedStats(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.advancedStatsLoading = false;
      return;
    }
    this.advancedStats = [];
    this.advancedStatsLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getAdvancedStats(symbol).then(collections => {
        collections.symbol = symbol;
        this.advancedStats.push(collections);
        this.advancedStatsLoading = false;
      }).catch(() => {
        this.advancedStatsLoading = false;
      });
    });
  }

  getKeyStats(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.keyStatsLoading = false;
      return;
    }
    this.keyStats = [];
    this.keyStatsLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getKeyStats(symbol).then(collections => {
        collections.symbol = symbol;
        this.keyStats.push({...collections});
        this.keyStatsLoading = false;
      }).catch(() => {
        this.keyStatsLoading = false;
      });
    });
  }

  getMarkets() {
    this.marketsLoading = true;
    this.dashboardService.getMarkets().then(collections => {
      collections.forEach(item => {
        item.marketPercent = Math.round(item.marketPercent*10000)/100;
      });
      this.markets = collections;
      this.marketsLoading = false;
    }).catch(() => {
      this.marketsLoading = false;
    });
  }

  getCompany(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.companyLoading = false;
      return;
    }
    this.companySummary = [];
    this.companyLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getCompany(symbol).then(company => {
        delete company.tags;
        this.companySummary.push(company);
        this.companyLoading = false;
      }).catch(() => {
        this.companyLoading = false;
      });
    });
  }

  getPeerGroups(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.peerGroupsLoading = false;
      return;
    }
    this.peerGroupsLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getPeerGroups(symbol).then(peerGroups => {
        let groups = peerGroups.map(item => {
          return {
            symbol: symbol,
            groupName: item,
          }
        });
        this.peerGroups = this.peerGroups.concat(groups);
        this.peerGroupsLoading = false;
      }).catch(() => {
        this.peerGroupsLoading = false;
      });
    });
  }

  getPreviousDayPrice(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.previousDayPriceLoading = false;
      return;
    }
    this.previousDayPrice = [];
    this.previousDayPriceLoading = true;
    this.initialSymbols.map(symbol => {
      this.stockService.getPreviousDayPrice(symbol).then(collections => {
        collections.symbol = symbol;
        this.previousDayPrice.push(collections);
        this.previousDayPriceLoading = false;
      }).catch(() => {
        this.previousDayPriceLoading = false;
      });
    });
  }

  getQuote(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.quotesLoading = false;
      return;
    }
    this.quotes = [];
    this.quotesLoading = true;
    this.initialSymbols.map(symbol => {
      this.stockService.getQuote(symbol).then(collection => {
        this.quotes.push(collection);
        this.quotesLoading = false;
      }).catch(() => {
        this.quotesLoading = false;
      });
    });
  }

  getRelevantStocks(symbol) {
    if(symbol === "" || symbol === undefined)  {
      this.relevantStocksLoading = false;
      return;
    }
    this.relevantStocksLoading = true;
    this.initialSymbols.forEach(symbol => {
      this.stockService.getRelevantStocks(symbol).then(collections => {
        let processed = collections.map(item => {
          return {
            symbol: symbol,
            relevantStock: item,
          };
        });
        this.relevantStocks = this.relevantStocks.concat(processed);
        this.relevantStocksLoading = false;
      }).catch(() => {
        this.relevantStocksLoading = false;
      });
    })
  }

  getSplits(ran, cal, last) {
    this.splitsLoading = true;
    this.stockService.getSplits(ran, cal, last).then(collections => {
      this.splits = collections;
      this.splitsLoading = false;
    }).catch(() => {
      this.splitsLoading = false;
    });
  }

  getSplitsBasic(symbol, range) {
    if(symbol === "" || symbol === undefined)  {
      this.splitsBasicLoading = false;
      return;
    }
    this.splitsBasicLoading = true;
    this.initialSymbols.map(symbol => {
      this.stockService.getSplitsBasic(symbol, range).then(collections => {
        this.splitsBasics = this.splitsBasics.concat(collections);
        this.splitsBasicLoading = false;
      }).catch(() => {
        this.splitsBasicLoading = false;
      });
    });
  }

  getExistingSymbols() {
    this.stockService.getExistingSymbols().then(collections => {
      this.symbols = collections.map(item => item.symbol).sort();
    })
  }

  drawChart(res) {
    this.canvas1 = document.getElementById("spyIntradayPrice");
    this.ctx1 = this.canvas1.getContext("2d");
    var gradientStroke = this.ctx1.createLinearGradient(0, 230, 0, 50);

    gradientStroke.addColorStop(1, "rgba(233,32,16,0.2)");
    gradientStroke.addColorStop(0.4, "rgba(233,32,16,0.0)");
    gradientStroke.addColorStop(0, "rgba(233,32,16,0)"); //red colors

    var data: any = {
      labels: res.SPY.filter((item, index) => (item.average !== null)).map(item => item.minute),
      datasets: [
        {
          label: "SPY",
          fill: true,
          backgroundColor: gradientStroke,
          borderColor: "#ec250d",
          borderWidth: 1,
          borderDash: [],
          borderDashOffset: 0.0,
          pointBackgroundColor: "#ec250d",
          pointBorderColor: "rgba(255,255,255,0)",
          pointHoverBackgroundColor: "#ec250d",
          pointBorderWidth: 20,
          pointHoverRadius: 0,
          pointHoverBorderWidth: 15,
          pointRadius: 0,
          data: res.SPY.filter((item,index) => (item.average !== null)).map(item => item.average),
        }
      ]
    };

    var myChart = new Chart(this.ctx1, {
      type: "line",
      data: data,
      options: this.dashboardService.gradientChartOptionsConfigurationWithTooltipRed
    });

    this.canvas2 = document.getElementById("qqqIntradayPrice");
    this.ctx2 = this.canvas2.getContext("2d");
    var gradientStroke = this.ctx2.createLinearGradient(0, 230, 0, 50);

    gradientStroke.addColorStop(1, "rgba(66,134,121,0.15)");
    gradientStroke.addColorStop(0.4, "rgba(66,134,121,0.0)"); //green colors
    gradientStroke.addColorStop(0, "rgba(66,134,121,0)"); //green colors

    var data: any = {
      labels: res.QQQ.filter(item => item.average !== null).map(item => item.minute),
      datasets: [
        {
          label: "QQQ",
          fill: true,
          backgroundColor: gradientStroke,
          borderColor: "#00d6b4",
          borderWidth: 1,
          borderDash: [],
          borderDashOffset: 0.0,
          pointBackgroundColor: "#00d6b4",
          pointBorderColor: "rgba(255,255,255,0)",
          pointHoverBackgroundColor: "#00d6b4",
          pointBorderWidth: 20,
          pointHoverRadius: 0,
          pointHoverBorderWidth: 15,
          pointRadius: 0,
          data: res.QQQ.filter(item => item.average !== null).map(item => item.average),
        }
      ]
    };

    var myChart = new Chart(this.ctx2, {
      type: "line",
      data: data,
      options: this.dashboardService.gradientChartOptionsConfigurationWithTooltipGreen
    });

    this.canvas3 = document.getElementById("iwmIntradayPrice");
    this.ctx3 = this.canvas3.getContext("2d");
    var gradientStroke = this.ctx3.createLinearGradient(0, 230, 0, 50);

    gradientStroke.addColorStop(1, "rgba(66,134,121,0.15)");
    gradientStroke.addColorStop(0.4, "rgba(66,134,121,0.0)"); //green colors
    gradientStroke.addColorStop(0, "rgba(66,134,121,0)"); //green colors

    var data: any = {
      labels: res.IWM.filter((item, index) => item.average !== null).map(item => item.minute),
      datasets: [
        {
          label: "IWM",
          fill: true,
          backgroundColor: gradientStroke,
          borderColor: "#ff8a76",
          borderWidth: 1,
          borderDash: [],
          borderDashOffset: 0.0,
          pointBackgroundColor: "#ff8a76",
          pointBorderColor: "rgba(255,255,255,0)",
          pointHoverBackgroundColor: "#ff8a76",
          pointBorderWidth: 20,
          pointHoverRadius: 0,
          pointHoverBorderWidth: 15,
          pointRadius: 0,
          data: res.IWM.filter(item => item.average !== null).map(item => item.average),
        }
      ]
    };

    var myChart = new Chart(this.ctx3, {
      type: "line",
      data: data,
      options: this.dashboardService.gradientChartOptionsConfigurationWithTooltipOrange
    });
  }

  private getIntradayPricesForMostPopularSymbol() {
    this.http.get<IntradayPriceForMostPopularSymbols>('/StockPrices/intradayPricesForMostPopularSymbol')
      .subscribe(result => {
        this.drawChart(result);
      });
  }

  private getChartDataRealTime() {
    this.getRealTimeChart = setInterval(() => {
      this.getIntradayPricesForMostPopularSymbol();
    }, 60000);
  }

  clear(table: Table) {
      table.clear();
  }

  public scroll() {
    window.scrollTo({top: 0, behavior: 'smooth'});
  }

  ngOnDestroy() {
    clearInterval(this.getRealTimeChart);
  }
}
