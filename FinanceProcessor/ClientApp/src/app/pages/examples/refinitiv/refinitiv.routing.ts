import { Routes } from "@angular/router";

import { AnalystRecommendationsComponent } from "./analyst-recommendations/analyst-recommendations.component";
import { EarningsComponent } from "./earnings/earnings.component";
import { EstimatesComponent } from "./estimates/estimates.component";
import { PriceTargetComponent } from "./price-target/price-target.component";

export const RefinitivRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "analyst-recommendations",
        component: AnalystRecommendationsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "earnings",
        component: EarningsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "estimates",
        component: EstimatesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "price-target",
        component: PriceTargetComponent
      }
    ]
  },
];
