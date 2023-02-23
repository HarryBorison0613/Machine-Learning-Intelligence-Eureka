import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgxDatatableModule } from "@swimlane/ngx-datatable";
import { TableModule } from "primeng/table";
import { ButtonModule } from "primeng/button";
import { AutoCompleteModule } from "primeng/autocomplete";

import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { ProgressbarModule } from "ngx-bootstrap/progressbar";
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { PaginationModule } from "ngx-bootstrap/pagination";
import { CollapseModule } from "ngx-bootstrap/collapse";
import { AlertModule } from "ngx-bootstrap/alert";
import { ModalModule } from "ngx-bootstrap/modal";
import { TabsModule } from "ngx-bootstrap/tabs";

import { EndOfDayOptionsComponent } from "./end-of-day-options/end-of-day-options.component";

import { OptionsRoutes } from "./options.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(OptionsRoutes),
    FormsModule,
    NgxDatatableModule,
    TableModule,
    ButtonModule,
    AutoCompleteModule,
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
    EndOfDayOptionsComponent,
  ],
  exports: [
    EndOfDayOptionsComponent,
  ]
})
export class OptionsPageModule {}
