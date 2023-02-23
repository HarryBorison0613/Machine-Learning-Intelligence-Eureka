import { Routes } from "@angular/router";

import { NewConstructsReportComponent } from "./new-constructs-report/new-constructs-report.component";

export const NewConstructsRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "new-constructs-report",
        component: NewConstructsReportComponent
      }
    ]
  },
];
