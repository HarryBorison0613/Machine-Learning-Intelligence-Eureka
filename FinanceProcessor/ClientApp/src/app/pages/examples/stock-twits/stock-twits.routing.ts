import { Routes } from "@angular/router";

import { SocialSentimentComponent } from "./social-sentiment/social-sentiment.component";

export const StockTwitsRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "social-sentiment",
        component: SocialSentimentComponent
      }
    ]
  },
];
