import { Routes } from "@angular/router";

import { StocksComponent } from "./stocks/stocks.component";
import { OptionsComponent } from "./options/options.component";
import { DarkpoolComponent } from "./darkpool/darkpool.component";
import { CryptoComponent } from "./crypto/crypto.component";

export const TickerRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "ticker-stocks",
        component: StocksComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "ticker-options",
        component: OptionsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "ticker-darkpool",
        component: DarkpoolComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "ticker-crypto",
        component: CryptoComponent
      }
    ]
  }
];
