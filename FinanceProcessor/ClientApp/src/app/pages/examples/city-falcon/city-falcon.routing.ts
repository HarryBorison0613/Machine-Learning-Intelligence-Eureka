import { Routes } from "@angular/router";

import { CityFalconNewsComponent } from "./city-falcon-news/city-falcon-news.component";
import { CityFalconStreamingNewsComponent } from "./city-falcon-streaming-news/city-falcon-streaming-news.component";

export const CityFalconRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "city-falcon-news",
        component: CityFalconNewsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "city-falcon-streaming-news",
        component: CityFalconStreamingNewsComponent
      }
    ]
  },
];
