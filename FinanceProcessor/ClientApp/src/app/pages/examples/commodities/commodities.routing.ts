import { Routes } from "@angular/router";

import { OilPricesComponent } from "./oil-prices/oil-prices.component";
import { NaturalGasPriceComponent } from "./natural-gas-price/natural-gas-price.component";
import { HeatingOilPricesComponent } from "./heating-oil-prices/heating-oil-prices.component";
import { JetFuelPricesComponent } from "./jet-fuel-prices/jet-fuel-prices.component";
import { DieselPriceComponent } from "./diesel-price/diesel-price.component";
import { GasPricesComponent } from "./gas-prices/gas-prices.component";
import { PropanePricesComponent } from "./propane-prices/propane-prices.component";

export const CommoditiesRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "oil-prices",
        component: OilPricesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "natural-gas-price",
        component: NaturalGasPriceComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "heating-oil-prices",
        component: HeatingOilPricesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "jet-fuel-prices",
        component: JetFuelPricesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "diesel-price",
        component: DieselPriceComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "gas-prices",
        component: GasPricesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "propane-prices",
        component: PropanePricesComponent
      }
    ]
  },
];
