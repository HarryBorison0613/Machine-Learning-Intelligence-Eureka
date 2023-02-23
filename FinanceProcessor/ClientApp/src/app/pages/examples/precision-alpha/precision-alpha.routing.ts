import { Routes } from "@angular/router";

import { PrecisionAlphaPriceDynamicsComponent } from "./precision-alpha-price-dynamics/precision-alpha-price-dynamics.component";

export const PrecisionAlphaRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "precision-alpha-price-dynamics",
        component: PrecisionAlphaPriceDynamicsComponent
      }
    ]
  },
];
