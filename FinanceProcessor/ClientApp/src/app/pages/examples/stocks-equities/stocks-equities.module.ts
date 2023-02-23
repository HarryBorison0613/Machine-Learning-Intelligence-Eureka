import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgxDatatableModule } from "@swimlane/ngx-datatable";

import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { ProgressbarModule } from "ngx-bootstrap/progressbar";
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { PaginationModule } from "ngx-bootstrap/pagination";
import { CollapseModule } from "ngx-bootstrap/collapse";
import { AlertModule } from "ngx-bootstrap/alert";
import { ModalModule } from "ngx-bootstrap/modal";
import { TabsModule } from "ngx-bootstrap/tabs";
import { TableModule } from "primeng/table";
import { SliderModule } from 'primeng/slider';
import { MultiSelectModule } from 'primeng/multiselect';
import { ProgressBarModule } from 'primeng/progressbar';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { SkeletonModule } from 'primeng/skeleton';
import { ButtonModule } from "primeng/button";
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { RatingModule } from 'primeng/rating';
import { ContextMenuModule } from 'primeng/contextmenu';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { RadioButtonModule } from 'primeng/radiobutton';
import { ToolbarModule } from 'primeng/toolbar';
import { FileUploadModule } from 'primeng/fileupload';
import { TabViewModule } from 'primeng/tabview';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { CardModule } from 'primeng/card';
import { AutoCompleteModule } from 'primeng/autocomplete';

import { BonusIssueComponent } from "./bonus-issue/bonus-issue.component";
import { BalanceSheetComponent } from "./balance-sheet/balance-sheet.component";
import { BookComponent } from "./book/book.component";
import { CashFlowComponent } from "./cash-flow/cash-flow.component";
import { CeoCompensationComponent } from "./ceo-compensation/ceo-compensation.component";
import { ChartsComponent } from "./charts/charts.component";
import { CollectionsComponent } from "./collections/collections.component";
import { CompanyComponent } from "./company/company.component";
import { DelayedQuoteComponent } from "./delayed-quote/delayed-quote.component";
import { DistributionComponent } from "./distribution/distribution.component";
import { DividendsComponent } from "./dividends/dividends.component";
import { DividendsBasicComponent } from "./dividends-basic/dividends-basic.component";
import { DividendsForecastAlphaComponent } from "./dividends-forecast-alpha/dividends-forecast-alpha.component";
import { FinancialsAsReportedComponent } from "./financials-as-reported/financials-as-reported.component";
import { FinancialsComponent } from "./financials/financials.component";
import { FundOwnershipComponent } from "./fund-ownership/fund-ownership.component";
import { FundamentalsComponent } from "./fundamentals/fundamentals.component";
import { FundamentalValuationsAlphaComponent } from "./fundamental-valuations-alpha/fundamental-valuations-alpha.component";
import { HistoricalPricesComponent } from "./historical-prices/historical-prices.component";
import { IncomeStatementComponent } from "./income-statement/income-statement.component";
import { InsiderRosterComponent } from "./insider-roster/insider-roster.component";
import { InsiderSummaryComponent } from "./insider-summary/insider-summary.component";
import { InsiderTransactionsComponent } from "./insider-transactions/insider-transactions.component";
import { InstitutionalOwnershipComponent } from "./institutional-ownership/institutional-ownership.component";
import { IntradayPricesComponent } from "./intraday-prices/intraday-prices.component";
import { IPOCalendarBetaComponent } from "./ipo-calendar-beta/ipo-calendar-beta.component";
import { LargestTradesComponent } from "./largest-trades/largest-trades.component";
import { ListComponent } from "./list/list.component";
import { LogoComponent } from "./logo/logo.component";
import { MarketVolumeUSComponent } from "./market-volume-us/market-volume-us.component";
import { MarketsComponent } from "./markets/markets.component";
import { OHLCComponent } from "./ohlc/ohlc.component";
import { PeerGroupsComponent } from "./peer-groups/peer-groups.component";
import { PreviousDayPriceComponent } from "./previous-day-price/previous-day-price.component";
import { PriceOnlyComponent } from "./price-only/price-only.component";
import { QuoteComponent } from "./quote/quote.component";
import { RelevantStocksComponent } from "./relevant-stocks/relevant-stocks.component";
import { ReturnOfCapitalComponent } from "./return-of-capital/return-of-capital.component";
import { RightToPurchaseComponent } from "./right-to-purchase/right-to-purchase.component";
import { RightsIssueComponent } from "./rights-issue/rights-issue.component";
import { SectorPerformanceComponent } from "./sector-performance/sector-performance.component";
import { SecurityReclassificationComponent } from "./security-reclassification/security-reclassification.component";
import { SecuritySwapComponent } from "./security-swap/security-swap.component";
import { SpinoffComponent } from "./spinoff/spinoff.component";
import { SplitsComponent } from "./splits/splits.component";
import { SplitsBasicComponent } from "./splits-basic/splits-basic.component";
import { StatsComponent } from "./stats/stats.component";
import { StatsBasicComponent } from "./stats-basic/stats-basic.component";
import { TechnicalIndicatorsComponent } from "./technical-indicators/technical-indicators.component";
import { UpcomingEventsComponent } from "./upcoming-events/upcoming-events.component";
import { VolumeByVenueComponent } from "./volume-by-venue/volume-by-venue.component";

import { StocksEquitiesRoutes } from "./stocks-equities.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(StocksEquitiesRoutes),
    FormsModule,
    NgxDatatableModule,
    TableModule,
    RadioButtonModule,
    ToolbarModule,
    FileUploadModule,
    TabViewModule,
    ToggleButtonModule,
    SliderModule,
    MultiSelectModule,
    ProgressBarModule,
    CalendarModule,
    DropdownModule,
    SkeletonModule,
    ButtonModule,
    DialogModule,
    ConfirmDialogModule,
    RatingModule,
    ContextMenuModule,
    InputTextModule,
    InputNumberModule,
    InputTextareaModule,
    CardModule,
    AutoCompleteModule,
    BsDropdownModule.forRoot(),
    ProgressbarModule.forRoot(),
    TooltipModule.forRoot(),
    PaginationModule.forRoot(),
    CollapseModule.forRoot(),
    TabsModule.forRoot(),
    AlertModule.forRoot(),
    ModalModule.forRoot(),
  ],
  declarations: [
    BookComponent,
    BonusIssueComponent,
    CashFlowComponent,
    BalanceSheetComponent,
    CeoCompensationComponent,
    ChartsComponent,
    CollectionsComponent,
    CompanyComponent,
    DelayedQuoteComponent,
    DistributionComponent,
    DividendsComponent,
    DividendsBasicComponent,
    DividendsForecastAlphaComponent,
    FinancialsAsReportedComponent,
    FinancialsComponent,
    FundOwnershipComponent,
    FundamentalsComponent,
    FundamentalValuationsAlphaComponent,
    HistoricalPricesComponent,
    IncomeStatementComponent,
    InsiderRosterComponent,
    InsiderSummaryComponent,
    InsiderTransactionsComponent,
    InstitutionalOwnershipComponent,
    IntradayPricesComponent,
    IPOCalendarBetaComponent,
    LargestTradesComponent,
    ListComponent,
    LogoComponent,
    MarketVolumeUSComponent,
    MarketsComponent,
    OHLCComponent,
    PeerGroupsComponent,
    PreviousDayPriceComponent,
    PriceOnlyComponent,
    QuoteComponent,
    RelevantStocksComponent,
    ReturnOfCapitalComponent,
    RightToPurchaseComponent,
    RightsIssueComponent,
    SectorPerformanceComponent,
    SecurityReclassificationComponent,
    SecuritySwapComponent,
    SpinoffComponent,
    SplitsComponent,
    SplitsBasicComponent,
    StatsComponent,
    StatsBasicComponent,
    TechnicalIndicatorsComponent,
    UpcomingEventsComponent,
    VolumeByVenueComponent
  ],
  exports: [
    BookComponent,
    BonusIssueComponent,
    CashFlowComponent,
    BalanceSheetComponent,
    CeoCompensationComponent,
    ChartsComponent,
    CollectionsComponent,
    CompanyComponent,
    DelayedQuoteComponent,
    DistributionComponent,
    DividendsComponent,
    DividendsBasicComponent,
    DividendsForecastAlphaComponent,
    FinancialsAsReportedComponent,
    FinancialsComponent,
    FundOwnershipComponent,
    FundamentalsComponent,
    FundamentalValuationsAlphaComponent,
    HistoricalPricesComponent,
    IncomeStatementComponent,
    InsiderRosterComponent,
    InsiderSummaryComponent,
    InsiderTransactionsComponent,
    InstitutionalOwnershipComponent,
    IntradayPricesComponent,
    IPOCalendarBetaComponent,
    LargestTradesComponent,
    ListComponent,
    LogoComponent,
    MarketVolumeUSComponent,
    MarketsComponent,
    OHLCComponent,
    PeerGroupsComponent,
    PreviousDayPriceComponent,
    PriceOnlyComponent,
    QuoteComponent,
    RelevantStocksComponent,
    ReturnOfCapitalComponent,
    RightToPurchaseComponent,
    RightsIssueComponent,
    SectorPerformanceComponent,
    SecurityReclassificationComponent,
    SecuritySwapComponent,
    SpinoffComponent,
    SplitsComponent,
    SplitsBasicComponent,
    StatsComponent,
    StatsBasicComponent,
    TechnicalIndicatorsComponent,
    UpcomingEventsComponent,
    VolumeByVenueComponent
  ],
})
export class StocksEquitiesPageModule {}
