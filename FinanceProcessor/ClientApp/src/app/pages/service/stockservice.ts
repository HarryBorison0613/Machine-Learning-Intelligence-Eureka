import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Collection, BalanceSheet, BonusIssue, StockBook, CashFlow, Company, CeoCompensation, DelayedQuote, DistributionList, Dividends, DividendsBasic, Financials, ReportedFinancials, AdvancedFundamentals, InsiderRoster, InsiderSummary, InsiderTransaction, IntradayPrice, LargestTrade, DividendsForecast, OpenClosePrice, PreviousDayPrice, ReturnOfCapital, RightToPurchase, SecurityReclassification, RightsIssue, Spinoff, HistoricalPrice, IncomeStatement, SplitsBasic, UpcomingEvent, Earning, IPO, FundamentalValuation, InstitutionalOwnership, Split, VolumeByVenue, AdvancedStat, KeyStat, TechnicalIndicator, IpoCalendar, Logo, FundOwnership } from '../domain/stock';
import { List } from '../domain/marketinfo';
import { Symbol } from '../domain/reference';

@Injectable()
export class StockService {

    constructor(private http: HttpClient) { }

    getCollections(cType, cName) {
        return this.http.get<Collection[]>(`/MarketInfo/collections?collectionType=${cType}&collectionName=${cName}`)
            .toPromise()
            .then(result => <Collection[]>result);
    }

    getBalanceSheets(symbol, period) {
        return this.http.get<any>(`/StockFundamentals/balanceSheet?symbol=${symbol}&period=${period}&last=${50}`)
            .toPromise()
            .then(res => <BalanceSheet[]>res.balancesheet);
    }

    getExistingSymbols() {
        return this.http.get<Symbol[]>('/References/existingSymbols')
            .toPromise()
            .then(data => <Symbol[]>data);
    }

    getBonusIssues(ran, cal, last) {
        return this.http.get<any>(`/CorporateActions/bonusIssueList?range=${ran}&calendar=${cal}&last=${last}`)
            .toPromise()
            .then(data => <BonusIssue[]>data);
    }

    getStockBooks(symbol) {
        return this.http.get<any>(`/StockPrices/book?symbol=${symbol}`)
            .toPromise()
            .then(data => <StockBook>data);
    }

    getCashflow(symbol, period) {
        return this.http.get<any>(`/StockFundamentals/cashFlow?symbol=${symbol}&period=${period}&last=${10000}`)
            .toPromise()
            .then(data => <CashFlow>data);
    }

    getCompany(symbol) {
        return this.http.get<any>(`/StockProfiles/company?symbol=${symbol}`)
            .toPromise()
            .then(data => <Company>data);
    }
    
    getCeoCompensation(symbol) {
        return this.http.get<any>(`/CeoCompensation/ceoCompensation?symbol=${symbol}`)
            .toPromise()
            .then(data => <CeoCompensation>data);
    }
    
    getDelayedQuote(symbol) {
        return this.http.get<any>(`/StockPrices/delayedQuoteAsync?symbol=${symbol}`)
            .toPromise()
            .then(data => <DelayedQuote>data);
    }

    getDistributionList(ran, cal, last) {
        return this.http.get<any>(`/CorporateActions/distributionList?range=${ran}&calendar=${cal}&last=${last}`)
            .toPromise()
            .then(data => <DistributionList[]>data);
    }

    getDividends(ran, cal, last) {
        return this.http.get<any>(`/CorporateActions/dividendsAdvancedList?range=${ran}&calendar=${cal}&last=${last}`)
            .toPromise()
            .then(data => <Dividends[]>data);
    }

    getDividendsBasic(symbol, range) {
        return this.http.get<any>(`/StockFundamentals/dividendsBasic?symbol=${symbol}&range=${range}`)
            .toPromise()
            .then(data => <DividendsBasic[]>data);
    }

    getFinancials(symbol, last) {
        return this.http.get<any>(`/StockFundamentals/financial?symbol=${symbol}&last=${last}`)
            .toPromise()
            .then(res => <Financials[]>res.financials);
    }

    getReportedFinancials(symbol, period) {
        return this.http.get<any>(`/StockFundamentals/reportedFinancials?symbol=${symbol}&filing=${period}`)
            .toPromise()
            .then(data => <ReportedFinancials[]>data);
    }

    getFundamentals(symbol, period) {
        return this.http.get<any>(`/StockFundamentals/advancedFundamentals?symbol=${symbol}&timeSeriesPeriod=${period}`)
            .toPromise()
            .then(data => <AdvancedFundamentals[]>data);
    }

    getInsiderRosters(symbol) {
        return this.http.get<any>(`/StockProfiles/insiderRoster?symbol=${symbol}`)
            .toPromise()
            .then(data => <InsiderRoster[]>data);
    }

    getInsiderSummary(symbol) {
        return this.http.get<any>(`/StockProfiles/insiderSummary?symbol=${symbol}`)
            .toPromise()
            .then(data => <InsiderSummary[]>data);
    }

    getInsiderTransactions(symbol) {
        return this.http.get<any>(`/StockProfiles/insiderTransactionsAsync?symbol=${symbol}`)
            .toPromise()
            .then(data => <InsiderTransaction[]>data);
    }

    getIntradayPrices(symbol) {
        return this.http.get<any>(`/StockPrices/intradayPrices?symbol=${symbol}`)
            .toPromise()
            .then(data => <IntradayPrice[]>data);
    }

    getLargestTrades(symbol) {
        return this.http.get<any>(`/StockPrices/largestTrades?symbol=${symbol}`)
            .toPromise()
            .then(data => <LargestTrade[]>data);
    }

    getDividendsForecast(symbol) {
        return this.http.get<any>(`/CorporateActions/dividendsForecast?symbol=${symbol}`)
            .toPromise()
            .then(data => <DividendsForecast[]>data);
    }

    getOpenClosePrice(symbol) {
        return this.http.get<any>(`/StockPrices/OHLC?symbol=${symbol}`)
            .toPromise()
            .then(data => <OpenClosePrice>data);
    }

    getPeerGroups(symbol) {
        return this.http.get<any>(`/StockProfiles/peerGroups?symbol=${symbol}`)
            .toPromise()
            .then(data => <string[]>data);
    }

    getPriceOnly(symbol) {
        return this.http.get<any>(`/StockPrices/price?symbol=${symbol}`)
            .toPromise()
            .then(data => <number>data);
    }

    getPreviousDayPrice(symbol) {
        return this.http.get<any>(`/StockPrices/previousDayPrice?symbol=${symbol}`)
            .toPromise()
            .then(data => <PreviousDayPrice>data);
    }

    getQuote(symbol) {
        return this.http.get<any>(`/StockPrices/quote?symbol=${symbol}`)
            .toPromise()
            .then(data => <Collection>data);
    }

    getReturnOfCapital(range, calendar, last) {
        return this.http.get<any>(`/CorporateActions/returnOfCapitalList?range=${range}&calendar=${calendar}&last=${last}`)
            .toPromise()
            .then(data => <ReturnOfCapital[]>data);
    }

    getRightToPurchase(range, calendar, last) {
        return this.http.get<any>(`/CorporateActions/rightToPurchaseList?range=${range}&calendar=${calendar}&last=${last}`)
            .toPromise()
            .then(data => <RightToPurchase[]>data);
    }

    getSecurityReclassification(range, calendar, last) {
        return this.http.get<any>(`/CorporateActions/securityReclassificationList?range=${range}&calendar=${calendar}&last=${last}`)
            .toPromise()
            .then(data => <SecurityReclassification[]>data);
    }

    getSecuritySwap(range, calendar, last) {
        return this.http.get<any>(`/CorporateActions/securitySwapList?range=${range}&calendar=${calendar}&last=${last}`)
            .toPromise()
            .then(data => <SecurityReclassification[]>data);
    }

    getRightsIssue(range, calendar, last) {
        return this.http.get<any>(`/CorporateActions/rightsIssueList?range=${range}&calendar=${calendar}&last=${last}`)
            .toPromise()
            .then(data => <RightsIssue[]>data);
    }

    getSpinoff(range, calendar, last) {
        return this.http.get<any>(`/CorporateActions/spinOffList?range=${range}&calendar=${calendar}&last=${last}`)
            .toPromise()
            .then(data => <Spinoff[]>data);
    }

    getHistoricalPrices(symbol, range) {
        return this.http.get<any>(`/StockPrices/historicalPrice?symbol=${symbol}&chartRange=${range}`)
            .toPromise()
            .then(data => <HistoricalPrice[]>data);
    }

    getIncomeStatements(symbol, period, last) {
        return this.http.get<any>(`/StockFundamentals/incomeStatement?symbol=${symbol}&period=${period}&last=${last}`)
            .toPromise()
            .then(res => <[IncomeStatement]>res.income);
    }

    getLists(type, percent, limit) {
        return this.http.get<List[]>(`/MarketInfo/list?listType=${type}&displayPercent=${percent}&listLimit=${limit}`)
            .toPromise()
            .then(result => <List[]>result);
    }

    getSplitsBasic(symbol, range) {
        return this.http.get<SplitsBasic[]>(`/StockFundamentals/splitsBasic?symbol=${symbol}&range=${range}`)
            .toPromise()
            .then(result => <SplitsBasic[]>result);
    }

    getUpcomingEvents(symbol) {
        return this.http.get<UpcomingEvent>(`/MarketInfo/upcomingEvents?symbol=${symbol}`)
            .toPromise()
            .then(result => <UpcomingEvent>result);
    }

    getUpcomingDividends(symbol) {
        return this.http.get<DividendsBasic[]>(`/MarketInfo/upcomingDividends?symbol=${symbol}`)
            .toPromise()
            .then(result => <DividendsBasic[]>result);
    }

    getUpcomingSplits(symbol) {
        return this.http.get<SplitsBasic[]>(`/MarketInfo/upcomingSplits?symbol=${symbol}`)
            .toPromise()
            .then(result => <SplitsBasic[]>result);
    }

    getUpcomingEarnings(symbol) {
        return this.http.get<Earning[]>(`/MarketInfo/upcomingEarnings?symbol=${symbol}`)
            .toPromise()
            .then(result => <Earning[]>result);
    }

    getUpcomingIpos(symbol) {
        return this.http.get<IPO[]>(`/MarketInfo/upcomingIpos?symbol=${symbol}`)
            .toPromise()
            .then(result => <IPO[]>result);
    }

    getUpcomingDividendsMarket() {
        return this.http.get<DividendsBasic[]>(`/MarketInfo/upcomingDividendsMarket`)
            .toPromise()
            .then(result => <DividendsBasic[]>result);
    }

    getUpcomingEarningsMarket() {
        return this.http.get<Earning[]>(`/MarketInfo/upcomingEarningsMarket`)
            .toPromise()
            .then(result => <Earning[]>result);
    }

    getUpcomingSplitsMarket() {
        return this.http.get<SplitsBasic[]>(`/MarketInfo/upcomingSplitsMarket`)
            .toPromise()
            .then(result => <SplitsBasic[]>result);
    }

    getFundamentalValuations(symbol, period) {
        return this.http.get<any>(`/StockFundamentals/fundamentalValuations?symbol=${symbol}&timeSeriesPeriod=${period}`)
            .toPromise()
            .then(data => <FundamentalValuation[]>data);
    }

    getFundOwnership(symbol) {
        return this.http.get<FundOwnership[]>(`/StockResearch/fundOwnership?symbol=${symbol}`)
            .toPromise()
            .then(result => <FundOwnership[]>result);
    }

    getInstitutionalOwnership(symbol) {
        return this.http.get<InstitutionalOwnership[]>(`/StockResearch/institutionalOwnerShip?symbol=${symbol}`)
            .toPromise()
            .then(result => <InstitutionalOwnership[]>result);
    }

    getRelevantStocks(symbol) {
        return this.http.get<any>(`/StockResearch/relevantStocks?symbol=${symbol}`)
            .toPromise()
            .then(res => <string[]>res.symbols);
    }

    getSplits(range, calendar, last) {
        return this.http.get<Split[]>(`/CorporateActions/splitsAdvancedList?range=${range}&calendar=${calendar}&last=${last}`)
            .toPromise()
            .then(data => <Split[]>data);
    }

    getVolumeByVenue(symbol) {
        return this.http.get<VolumeByVenue[]>(`/StockPrices/volumeByVenue?symbol=${symbol}`)
            .toPromise()
            .then(data => <VolumeByVenue[]>data);
    }

    getAdvancedStats(symbol) {
        return this.http.get<AdvancedStat>(`/StockResearch/advancedStats?symbol=${symbol}`)
            .toPromise()
            .then(data => <AdvancedStat>data);
    }

    getKeyStats(symbol) {
        return this.http.get<KeyStat>(`/StockResearch/keyStats?symbol=${symbol}`)
            .toPromise()
            .then(data => <KeyStat>data);
    }

    getTechnicalIndicators(symbol, indicatorName, range, lastIndicator, indicatorOnly) {
        return this.http.get<TechnicalIndicator>(`/StockResearch/technicalIndicators?symbol=${symbol}&indicatorName=${indicatorName}&range=${range}&lastIndicator=${lastIndicator}&indicatorOnly=${indicatorOnly}`)
            .toPromise()
            .then(data => <TechnicalIndicator>data);
    }

    getIpoCalendarData(ipoType) {
        return this.http.get<IpoCalendar[]>(`/MarketInfo/ipoCalendar?ipoType=${ipoType}`)
            .toPromise()
            .then(data => <IpoCalendar[]>data);
    }

    getLogo(symbol) {
        return this.http.get<Logo>(`/StockProfiles/logo?symbol=${symbol}`)
            .toPromise()
            .then(data => <Logo>data);
    }
}
