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

import { CryptocurrencyBookComponent } from "./cryptocurrency-book/cryptocurrency-book.component";
import { CryptocurrencyEventsComponent } from "./cryptocurrency-events/cryptocurrency-events.component";
import { CryptocurrencyPriceComponent } from "./cryptocurrency-price/cryptocurrency-price.component";
import { CryptocurrencyQuoteComponent } from "./cryptocurrency-quote/cryptocurrency-quote.component";

import { CryptocurrencyRoutes } from "./cryptocurrency.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(CryptocurrencyRoutes),
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
    CryptocurrencyBookComponent,
    CryptocurrencyEventsComponent,
    CryptocurrencyPriceComponent,
    CryptocurrencyQuoteComponent,
  ],
  exports: [
    CryptocurrencyBookComponent,
    CryptocurrencyEventsComponent,
    CryptocurrencyPriceComponent,
    CryptocurrencyQuoteComponent,
  ]
})
export class CryptocurrencyPageModule {}
