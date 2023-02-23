import { Routes } from "@angular/router";

import { CryptocurrencySymbolsComponent } from "./cryptocurrency-symbols/cryptocurrency-symbols.component";
import { FIGIMappingComponent } from "./figi-mapping/figi-mapping.component";
import { FuturesSymbolsBetaComponent } from "./futures-symbols-beta/futures-symbols-beta.component";
import { FXSymbolsComponent } from "./fx-symbols/fx-symbols.component";
import { IEXSymbolsComponent } from "./iex-symbols/iex-symbols.component";
import { InternationalExchangesComponent } from "./international-exchanges/international-exchanges.component";
import { InternationalSymbolsComponent } from "./international-symbols/international-symbols.component";
import { ISINMappingComponent } from "./isin-mapping/isin-mapping.component";
import { MutualFundSymbolsComponent } from "./mutual-fund-symbols/mutual-fund-symbols.component";
import { OptionsSymbolsComponent } from "./options-symbols/options-symbols.component";
import { OTCSymbolsComponent } from "./otc-symbols/otc-symbols.component";
import { RICMappingComponent } from "./ric-mapping/ric-mapping.component";
import { SearchComponent } from "./search/search.component";
import { SectorsComponent } from "./sectors/sectors.component";
import { SymbolsComponent } from "./symbols/symbols.component";
import { TagsComponent } from "./tags/tags.component";
import { USExchangesComponent } from "./us-exchanges/us-exchanges.component";
import { USHolidaysandTradingDatesComponent } from "./us-holidays-and-trading-dates/us-holidays-and-trading-dates.component";

export const ReferenceDataRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "cryptocurrency-symbols",
        component: CryptocurrencySymbolsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "figi-mapping",
        component: FIGIMappingComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "futures-symbols",
        component: FuturesSymbolsBetaComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "fx-symbols",
        component: FXSymbolsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "iex-symbols",
        component: IEXSymbolsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "international-exchanges",
        component: InternationalExchangesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "international-symbols",
        component: InternationalSymbolsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "isin-mapping",
        component: ISINMappingComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "mutual-fund-symbols",
        component: MutualFundSymbolsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "options-symbols",
        component: OptionsSymbolsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "otc-symbols",
        component: OTCSymbolsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "ric-mapping",
        component: RICMappingComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "search",
        component: SearchComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "sectors",
        component: SectorsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "symbols",
        component: SymbolsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "tags",
        component: TagsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "us-exchanges",
        component: USExchangesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "us-holidays-and-trading-dates",
        component: USHolidaysandTradingDatesComponent
      }
    ]
  },
];
