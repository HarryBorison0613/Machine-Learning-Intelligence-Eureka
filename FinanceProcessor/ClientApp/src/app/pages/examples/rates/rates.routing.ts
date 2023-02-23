import { Routes } from "@angular/router";

import { CDRatesComponent } from "./cd-rates/cd-rates.component";
import { CreditCardInterestRateComponent } from "./credit-card-interest-rate/credit-card-interest-rate.component";

export const RatesRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "cd-rates",
        component: CDRatesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "credit-card-interest-rate",
        component: CreditCardInterestRateComponent
      }
    ]
  },
];
