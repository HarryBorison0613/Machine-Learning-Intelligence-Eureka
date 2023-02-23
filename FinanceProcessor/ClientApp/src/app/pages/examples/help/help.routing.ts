import { Routes } from "@angular/router";

import { StocksComponent } from "./stocks/stocks.component";
import { NotificationsComponent } from "./notifications/notifications.component";
import { PanelsComponent } from "./panels/panels.component";
import { SweetalertComponent } from "./sweetalert/sweetalert.component";

export const HelpRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "performance",
        component: StocksComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "watchlist",
        component: NotificationsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "discordbots",
        component: PanelsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "education",
        component: SweetalertComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "faqs",
        component: SweetalertComponent
      }
    ]
  },
];
