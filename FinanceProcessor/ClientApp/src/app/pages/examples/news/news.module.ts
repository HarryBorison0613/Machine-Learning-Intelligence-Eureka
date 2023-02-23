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
import { TableModule } from "primeng/table";
import { DropdownModule } from 'primeng/dropdown';
import { ButtonModule } from "primeng/button";
import { CardModule } from 'primeng/card';
import { AutoCompleteModule } from 'primeng/autocomplete';

import { IntradayNewsComponent } from "./intraday-news/intraday-news.component";
import { HistoricalNewsComponent } from "./historical-news/historical-news.component";
import { StreamingNewsComponent } from "./streaming-news/streaming-news.component";

import { NewsRoutes } from "./news.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(NewsRoutes),
    FormsModule,
    NgxDatatableModule,
    TableModule,
    DropdownModule,
    ButtonModule,
    CardModule,
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
    IntradayNewsComponent,
    HistoricalNewsComponent,
    StreamingNewsComponent,
  ],
  exports: [
    IntradayNewsComponent,
    HistoricalNewsComponent,
    StreamingNewsComponent,
  ]
})
export class NewsPageModule {}
