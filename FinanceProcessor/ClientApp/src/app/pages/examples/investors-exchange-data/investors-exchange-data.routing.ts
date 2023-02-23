import { Routes } from "@angular/router";

import { DEEPComponent } from "./deep/deep.component";
import { DEEPAuctionComponent } from "./deep-auction/deep-auction.component";
import { DEEPBookComponent } from "./deep-book/deep-book.component";
import { DEEPOperationalHaltStatusComponent } from "./deep-operational-halt-status/deep-operational-halt-status.component";
import { DEEPOfficialPriceComponent } from "./deep-official-price/deep-official-price.component";
import { DEEPSecurityEventComponent } from "./deep-security-event/deep-security-event.component";
import { DEEPShortSalePriceTestStatusComponent } from "./deep-short-sale-price-test-status/deep-short-sale-price-test-status.component";
import { DEEPSystemEventComponent } from "./deep-system-event/deep-system-event.component";
import { DEEPTradesComponent } from "./deep-trades/deep-trades.component";
import { DEEPTradeBreakComponent } from "./deep-trade-break/deep-trade-break.component";
import { DEEPTradingStatusComponent } from "./deep-trading-status/deep-trading-status.component";
import { LastComponent } from "./last/last.component";
import { TopsComponent } from "./tops/tops.component";

export const InvestorsExchangeDataRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "deep",
        component: DEEPComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "deep-auction",
        component: DEEPAuctionComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "deep-book",
        component: DEEPBookComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "deep-operational-halt-status",
        component: DEEPOperationalHaltStatusComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "deep-official-price",
        component: DEEPOfficialPriceComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "deep-security-event",
        component: DEEPSecurityEventComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "deep-short-sale-price-test-status",
        component: DEEPShortSalePriceTestStatusComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "deep-system-event",
        component: DEEPSystemEventComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "deep-trades",
        component: DEEPTradesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "deep-trade-break",
        component: DEEPTradeBreakComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "deep-trading-status",
        component: DEEPTradingStatusComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "last",
        component: LastComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "tops",
        component: TopsComponent
      }
    ]
  },
];
