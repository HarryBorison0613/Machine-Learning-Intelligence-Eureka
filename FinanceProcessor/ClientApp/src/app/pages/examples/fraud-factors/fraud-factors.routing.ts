import { Routes } from "@angular/router";

import { NonTimelyFilingsComponent } from "./non-timely-filings/non-timely-filings.component";

export const FraudFactorsRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "non-timely-filings",
        component: NonTimelyFilingsComponent
      }
    ]
  },
];
