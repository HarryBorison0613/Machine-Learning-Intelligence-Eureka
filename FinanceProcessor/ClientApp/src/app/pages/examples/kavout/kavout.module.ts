import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgxDatatableModule } from "@swimlane/ngx-datatable";

import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { ProgressbarModule } from "ngx-bootstrap/progressbar";
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { PaginationModule } from "ngx-bootstrap/pagination";
import { CollapseModule } from "ngx-bootstrap/collapse";
import { AlertModule } from "ngx-bootstrap/alert";
import { ModalModule } from "ngx-bootstrap/modal";
import { TabsModule } from "ngx-bootstrap/tabs";

import { KScoreForUSEquitiesComponent } from "./k-score-for-us-equities/k-score-for-us-equities.component";
import { KScoreForChinaASharesComponent } from "./k-score-for-china-a-shares/k-score-for-china-a-shares.component";

import { KavoutRoutes } from "./kavout.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(KavoutRoutes),
    FormsModule,
    NgxDatatableModule,
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
    KScoreForUSEquitiesComponent,
    KScoreForChinaASharesComponent,
  ],
  exports: [
    KScoreForUSEquitiesComponent,
    KScoreForChinaASharesComponent,
  ]
})
export class KavoutPageModule {}
