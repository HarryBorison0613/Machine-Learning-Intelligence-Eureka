import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { ProgressbarModule } from "ngx-bootstrap/progressbar";
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { PaginationModule } from "ngx-bootstrap/pagination";
import { CollapseModule } from "ngx-bootstrap/collapse";
import { AlertModule } from "ngx-bootstrap/alert";
import { ModalModule } from "ngx-bootstrap/modal";
import { TabsModule } from "ngx-bootstrap/tabs";

import { TradyFlowComponent } from "./trady/trady.component";
import { FlowlineComponent } from "./flowline/flowline.component";
import { LiveOptionsComponent } from "./liveoptions/liveoptions.component";

import { FlowRoutes } from "./flow.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(FlowRoutes),
    FormsModule,
    BsDropdownModule.forRoot(),
    ProgressbarModule.forRoot(),
    TooltipModule.forRoot(),
    PaginationModule.forRoot(),
    CollapseModule.forRoot(),
    TabsModule.forRoot(),
    AlertModule.forRoot(),
    ModalModule.forRoot()
  ],
  declarations: [
    TradyFlowComponent,
    FlowlineComponent,
    LiveOptionsComponent,
  ],
  exports: [
    TradyFlowComponent,
    FlowlineComponent,
    LiveOptionsComponent,
  ]
})
export class FlowPageModule {}
