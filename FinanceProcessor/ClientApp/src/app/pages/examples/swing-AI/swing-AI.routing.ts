import { Routes } from "@angular/router";

import { StocksComponent } from "./stocks/stocks.component";
import { NotificationsComponent } from "./notifications/notifications.component";

export const SwingAIRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "prophet",
        component: StocksComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "cryptonite",
        component: NotificationsComponent
      }
    ]
  },
];
