import { Routes } from "@angular/router";

import { DailyTreasuryRatesComponent } from "./daily-treasury-rates/daily-treasury-rates.component";

export const TreasuresRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "daily-treasury-rates",
        component: DailyTreasuryRatesComponent
      }
    ]
  },
];
