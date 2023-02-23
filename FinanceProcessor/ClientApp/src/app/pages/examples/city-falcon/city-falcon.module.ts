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

import { CityFalconNewsComponent } from "./city-falcon-news/city-falcon-news.component";
import { CityFalconStreamingNewsComponent } from "./city-falcon-streaming-news/city-falcon-streaming-news.component";

import { CityFalconRoutes } from "./city-falcon.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(CityFalconRoutes),
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
    CityFalconNewsComponent,
    CityFalconStreamingNewsComponent,
  ],
  exports: [
    CityFalconNewsComponent,
    CityFalconStreamingNewsComponent,
  ]
})
export class CityFalconPageModule {}
