import { Routes } from "@angular/router";

import { LiveOptionsComponent } from "./liveoptions/liveoptions.component";
import { TradyFlowComponent } from "./trady/trady.component";
import { FlowlineComponent } from "./flowline/flowline.component";

export const FlowRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "flow-liveoptions",
        component: LiveOptionsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "flow-trady",
        component: TradyFlowComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "flow-line",
        component: FlowlineComponent
      }
    ]
  }
];
