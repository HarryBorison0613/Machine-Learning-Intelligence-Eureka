import { Routes } from "@angular/router";

import { StocksComponent } from "./stocks/stocks.component";
import { NotificationsComponent } from "./notifications/notifications.component";
import { PanelsComponent } from "./panels/panels.component";
import { SweetalertComponent } from "./sweetalert/sweetalert.component";

export const ResearchRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "polytics",
        component: StocksComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "hedgies",
        component: NotificationsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "peekaboo",
        component: PanelsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "chatters",
        component: SweetalertComponent
      }
    ]
  }
];
