import { Routes } from "@angular/router";

import { BalanceSheetComponent } from "./balance-sheet/balance-sheet.component";
import { BonusIssueComponent } from "./bonus-issue/bonus-issue.component";
import { BookComponent } from "./book/book.component";
import { CashFlowComponent } from "./cash-flow/cash-flow.component";
import { CeoCompensationComponent } from "./ceo-compensation/ceo-compensation.component";
import { ChartsComponent } from "./charts/charts.component";
import { CollectionsComponent } from "./collections/collections.component";
import { CompanyComponent } from "./company/company.component";
import { DistributionComponent } from "./distribution/distribution.component";
import { DelayedQuoteComponent } from "./delayed-quote/delayed-quote.component";
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

export const StocksEquitiesRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "balance-sheet",
        component: BalanceSheetComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "bonus-issue",
        component: BonusIssueComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "book",
        component: BookComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "cash-flow",
        component: CashFlowComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "ceo-compensation",
        component: CeoCompensationComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "charts",
        component: ChartsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "collections",
        component: CollectionsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "company",
        component: CompanyComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "delayed-quote",
        component: DelayedQuoteComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "distribution",
        component: DistributionComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "dividends",
        component: DividendsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "dividends-basic",
        component: DividendsBasicComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "dividends-forecast-alpha",
        component: DividendsForecastAlphaComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "financials-as-reported",
        component: FinancialsAsReportedComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "financials",
        component: FinancialsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "fund-ownership",
        component: FundOwnershipComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "fundamentals",
        component: FundamentalsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "fundamental-valuations-alpha",
        component: FundamentalValuationsAlphaComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "historical-prices",
        component: HistoricalPricesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "income-statement",
        component: IncomeStatementComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "insider-roster",
        component: InsiderRosterComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "insider-summary",
        component: InsiderSummaryComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "insider-transactions",
        component: InsiderTransactionsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "institutional-ownership",
        component: InstitutionalOwnershipComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "intraday-prices",
        component: IntradayPricesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "ipo-calendar-beta",
        component: IPOCalendarBetaComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "largest-trades",
        component: LargestTradesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "list",
        component: ListComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "logo",
        component: LogoComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "market-volume-us",
        component: MarketVolumeUSComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "markets",
        component: MarketsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "ohlc",
        component: OHLCComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "peer-groups",
        component: PeerGroupsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "previous-day-price",
        component: PreviousDayPriceComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "price-only",
        component: PriceOnlyComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "quote",
        component: QuoteComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "relevant-stocks",
        component: RelevantStocksComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "return-of-capital",
        component: ReturnOfCapitalComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "right-to-purchase",
        component: RightToPurchaseComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "rights-issue",
        component: RightsIssueComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "sector-performance",
        component: SectorPerformanceComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "security-reclassification",
        component: SecurityReclassificationComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "security-swap",
        component: SecuritySwapComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "spinoff",
        component: SpinoffComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "splits",
        component: SplitsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "splits-basic",
        component: SplitsBasicComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "stats",
        component: StatsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "stats-basic",
        component: StatsBasicComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "technical-indicators",
        component: TechnicalIndicatorsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "upcoming-events",
        component: UpcomingEventsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "volume-by-venue",
        component: VolumeByVenueComponent
      }
    ]
  },
];
