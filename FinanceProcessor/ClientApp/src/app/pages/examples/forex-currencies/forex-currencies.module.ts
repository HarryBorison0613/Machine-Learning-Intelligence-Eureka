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
import { InputNumberModule } from "primeng/inputnumber";
import { CalendarModule } from 'primeng/calendar';

import { RealTimeStreamingComponent } from "./real-time-streaming/real-time-streaming.component";
import { LatestCurrencyRatesComponent } from "./latest-currency-rates/latest-currency-rates.component";
import { CurrencyConversionComponent } from "./currency-conversion/currency-conversion.component";
import { HistoricalDailyComponent } from "./historical-daily/historical-daily.component";

import { ForexCurrenciesRoutes } from "./forex-currencies.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(ForexCurrenciesRoutes),
    FormsModule,
    NgxDatatableModule,
    TableModule,
    DropdownModule,
    ButtonModule,
    CardModule,
    AutoCompleteModule,
    InputNumberModule,
    CalendarModule,
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
    RealTimeStreamingComponent,
    LatestCurrencyRatesComponent,
    CurrencyConversionComponent,
    HistoricalDailyComponent,
  ],
  exports: [
    RealTimeStreamingComponent,
    LatestCurrencyRatesComponent,
    CurrencyConversionComponent,
    HistoricalDailyComponent,
  ]
})
export class ForexCurrenciesPageModule {}
