import { Routes } from "@angular/router";

import { EndOfDayOptionsComponent } from "./end-of-day-options/end-of-day-options.component";

export const OptionsRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "end-of-day-options",
        component: EndOfDayOptionsComponent
      }
    ]
  },
];
