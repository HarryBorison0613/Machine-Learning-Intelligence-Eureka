import { Routes } from "@angular/router";

import { IntradayNewsComponent } from "./intraday-news/intraday-news.component";
import { HistoricalNewsComponent } from "./historical-news/historical-news.component";
import { StreamingNewsComponent } from "./streaming-news/streaming-news.component";

export const NewsRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "intraday-news",
        component: IntradayNewsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "historical-news",
        component: HistoricalNewsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "streaming-news",
        component: StreamingNewsComponent
      }
    ]
  },
];
