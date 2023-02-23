import { Routes } from "@angular/router";

import { AuditAnalyticsDirectorAndOfficerChangesComponent } from "./aa-director/aa-director.component";
import { AuditAnalyticsAccountingQualityAndRiskMatrixComponent } from "./aa-accounting/aa-accounting.component";

export const AuditAnalyticsRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "aa-director",
        component: AuditAnalyticsDirectorAndOfficerChangesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "aa-accounting",
        component: AuditAnalyticsAccountingQualityAndRiskMatrixComponent
      }
    ]
  },
];
