import { Routes } from "@angular/router";

import { CryptocurrencyBookComponent } from "./cryptocurrency-book/cryptocurrency-book.component";
import { CryptocurrencyEventsComponent } from "./cryptocurrency-events/cryptocurrency-events.component";
import { CryptocurrencyPriceComponent } from "./cryptocurrency-price/cryptocurrency-price.component";
import { CryptocurrencyQuoteComponent } from "./cryptocurrency-quote/cryptocurrency-quote.component";

export const CryptocurrencyRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "cryptocurrency-book",
        component: CryptocurrencyBookComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "cryptocurrency-events",
        component: CryptocurrencyEventsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "cryptocurrency-price",
        component: CryptocurrencyPriceComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "cryptocurrency-quote",
        component: CryptocurrencyQuoteComponent
      }
    ]
  },
];
