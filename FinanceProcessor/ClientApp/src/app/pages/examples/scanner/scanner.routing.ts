import { Routes } from "@angular/router";

import { StocksComponent } from "./stocks/stocks.component";
import { NotificationsComponent } from "./notifications/notifications.component";
import { PanelsComponent } from "./panels/panels.component";
import { SweetalertComponent } from "./sweetalert/sweetalert.component";

export const ScannerRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "scany",
        component: StocksComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "flash",
        component: NotificationsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "opintra",
        component: PanelsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "cryptoscan",
        component: SweetalertComponent
      }
    ]
  }
];
