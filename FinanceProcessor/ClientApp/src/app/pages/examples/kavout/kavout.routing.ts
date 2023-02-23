import { Routes } from "@angular/router";

import { KScoreForUSEquitiesComponent } from "./k-score-for-us-equities/k-score-for-us-equities.component";
import { KScoreForChinaASharesComponent } from "./k-score-for-china-a-shares/k-score-for-china-a-shares.component";

export const KavoutRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "k-score-for-us-equities",
        component: KScoreForUSEquitiesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "k-score-for-china-a-shares",
        component: KScoreForChinaASharesComponent
      }
    ]
  },
];
