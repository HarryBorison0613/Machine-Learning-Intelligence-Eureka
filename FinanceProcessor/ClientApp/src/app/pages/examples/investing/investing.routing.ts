import { Routes } from "@angular/router";

import { StocksComponent } from "./stocks/stocks.component";

export const InvestingRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "AIportofolios",
        component: StocksComponent
      }
    ]
  },
];
