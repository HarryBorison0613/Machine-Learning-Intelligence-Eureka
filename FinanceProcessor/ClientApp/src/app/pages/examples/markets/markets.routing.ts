import { Routes } from "@angular/router";

import { StocksComponent } from "./stocks/stocks.component";
import { OptionsComponent } from "./options/options.component";
import { DarkpoolComponent } from "./darkpool/darkpool.component";
import { CryptoComponent } from "./crypto/crypto.component";

export const MarketsRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "market-stocks",
        component: StocksComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "market-options",
        component: OptionsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "market-darkpool",
        component: DarkpoolComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "market-crypto",
        component: CryptoComponent
      }
    ]
  }
];
