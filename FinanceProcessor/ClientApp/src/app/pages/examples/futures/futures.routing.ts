import { Routes } from "@angular/router";

import { EndOfDayFuturesBetaComponent } from "./end-of-day-futures-beta/end-of-day-futures-beta.component";

export const FuturesRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "end-of-day-futures-beta",
        component: EndOfDayFuturesBetaComponent
      }
    ]
  },
];
