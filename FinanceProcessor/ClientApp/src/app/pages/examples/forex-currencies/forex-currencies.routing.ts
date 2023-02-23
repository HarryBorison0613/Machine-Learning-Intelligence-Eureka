import { Routes } from "@angular/router";

import { RealTimeStreamingComponent } from "./real-time-streaming/real-time-streaming.component";
import { LatestCurrencyRatesComponent } from "./latest-currency-rates/latest-currency-rates.component";
import { CurrencyConversionComponent } from "./currency-conversion/currency-conversion.component";
import { HistoricalDailyComponent } from "./historical-daily/historical-daily.component";

export const ForexCurrenciesRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "real-time-streaming",
        component: RealTimeStreamingComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "latest-currency-rates",
        component: LatestCurrencyRatesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "currency-conversion",
        component: CurrencyConversionComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "historical-daily",
        component: HistoricalDailyComponent
      }
    ]
  },
];
