import { Routes } from "@angular/router";

import { ConsumerPriceComponent } from "./consumer-price-index/consumer-price-index.component";
import { FederalFundRatesComponent } from "./federal-fund-rates/federal-fund-rates.component";
import { IndustrialProductionIndexComponent } from "./industrial-production-index/industrial-production-index.component";
import { InitialClaimsComponent } from "./initial-claims/initial-claims.component";
import { InstitutionalMoneyFundsComponent } from "./institutional-money-funds/institutional-money-funds.component";
import { RealGDPComponent } from "./real-GDP/real-GDP.component";
import { RetailMoneyFundsComponent } from "./retail-money-funds/retail-money-funds.component";
import { TotalHousingStatsComponent } from "./total-housing-starts/total-housing-starts.component";
import { TotalPayrollsComponent } from "./total-payrolls/total-payrolls.component";
import { TotalVehicleSalesComponent } from "./total-vehicle-sales/total-vehicle-sales.component";
import { UnemploymentRateComponent } from "./unemployment-rate/unemployment-rate.component";
import { USRecessionProbabilitiesComponent } from "./us-recession-probabilities/us-recession-probabilities.component";

export const EconomicDataRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "consumer-price-index",
        component: ConsumerPriceComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "federal-fund-rates",
        component: FederalFundRatesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "industrial-production-index",
        component: IndustrialProductionIndexComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "initial-claims",
        component: InitialClaimsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "institutional-money-funds",
        component: InstitutionalMoneyFundsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "real-gdp",
        component: RealGDPComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "retail-money-funds",
        component: RetailMoneyFundsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "total-housing-starts",
        component: TotalHousingStatsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "total-payrolls",
        component: TotalPayrollsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "total-vehicle-sales",
        component: TotalVehicleSalesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "unemployment-rate",
        component: UnemploymentRateComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "us-recession-probabilities",
        component: USRecessionProbabilitiesComponent
      }
    ]
  },
];
