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

import { AnalystRecommendationsComponent } from "./analyst-recommendations/analyst-recommendations.component";
import { EarningsComponent } from "./earnings/earnings.component";
import { EstimatesComponent } from "./estimates/estimates.component";
import { PriceTargetComponent } from "./price-target/price-target.component";

import { RefinitivRoutes } from "./refinitiv.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(RefinitivRoutes),
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
    AnalystRecommendationsComponent,
    EarningsComponent,
    EstimatesComponent,
    PriceTargetComponent,
  ],
  exports: [
    AnalystRecommendationsComponent,
    EarningsComponent,
    EstimatesComponent,
    PriceTargetComponent,
  ]
})
export class RefinitivPageModule {}
