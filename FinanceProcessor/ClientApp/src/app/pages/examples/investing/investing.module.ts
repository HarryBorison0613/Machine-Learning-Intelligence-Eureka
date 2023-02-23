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

import { PanelsComponent } from "./panels/panels.component";
import { SweetalertComponent } from "./sweetalert/sweetalert.component";
import { NotificationsComponent } from "./notifications/notifications.component";
import { StocksComponent } from "./stocks/stocks.component";

import { InvestingRoutes } from "./investing.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(InvestingRoutes),
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
    PanelsComponent,
    SweetalertComponent,
    NotificationsComponent,
    StocksComponent,
  ],
  exports: [
    PanelsComponent,
    SweetalertComponent,
    NotificationsComponent,
    StocksComponent
  ]
})
export class InvestingPageModule {}
