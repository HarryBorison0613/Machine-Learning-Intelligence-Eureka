import { Routes } from "@angular/router";

import { MortgageRatesComponent } from "./mortgage-rates/mortgage-rates.component";

export const MortgageRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "mortgage-rates",
        component: MortgageRatesComponent
      }
    ]
  },
];
