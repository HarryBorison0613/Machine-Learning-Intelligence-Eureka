import { Routes } from "@angular/router";

import { StocksComponent } from "./stocks/stocks.component";
import { NotificationsComponent } from "./notifications/notifications.component";
import { PanelsComponent } from "./panels/panels.component";
import { SweetalertComponent } from "./sweetalert/sweetalert.component";

export const ComplexToolsRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "gambit",
        component: StocksComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "yinyang",
        component: NotificationsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "backtester",
        component: PanelsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "tradytics-AI",
        component: SweetalertComponent
      }
    ]
  }
];
