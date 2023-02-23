import { Routes } from "@angular/router";

import { StocksComponent } from "./stocks/stocks.component";

export const IntradayAIRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "bullseye",
        component: StocksComponent
      }
    ]
  },
];
