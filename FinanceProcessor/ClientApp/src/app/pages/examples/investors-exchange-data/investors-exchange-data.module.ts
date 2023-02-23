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
import { AutoCompleteModule } from "primeng/autocomplete";
import { ButtonModule } from "primeng/button";

import { DEEPComponent } from "./deep/deep.component";
import { DEEPAuctionComponent } from "./deep-auction/deep-auction.component";
import { DEEPBookComponent } from "./deep-book/deep-book.component";
import { DEEPOperationalHaltStatusComponent } from "./deep-operational-halt-status/deep-operational-halt-status.component";
import { DEEPOfficialPriceComponent } from "./deep-official-price/deep-official-price.component";
import { DEEPSecurityEventComponent } from "./deep-security-event/deep-security-event.component";
import { DEEPShortSalePriceTestStatusComponent } from "./deep-short-sale-price-test-status/deep-short-sale-price-test-status.component";
import { DEEPSystemEventComponent } from "./deep-system-event/deep-system-event.component";
import { DEEPTradesComponent } from "./deep-trades/deep-trades.component";
import { DEEPTradeBreakComponent } from "./deep-trade-break/deep-trade-break.component";
import { DEEPTradingStatusComponent } from "./deep-trading-status/deep-trading-status.component";
import { LastComponent } from "./last/last.component";
import { TopsComponent } from "./tops/tops.component";

import { InvestorsExchangeDataRoutes } from "./investors-exchange-data.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(InvestorsExchangeDataRoutes),
    FormsModule,
    NgxDatatableModule,
    TableModule,
    AutoCompleteModule,
    ButtonModule,
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
    DEEPComponent,
    DEEPAuctionComponent,
    DEEPBookComponent,
    DEEPOperationalHaltStatusComponent,
    DEEPOfficialPriceComponent,
    DEEPSecurityEventComponent,
    DEEPShortSalePriceTestStatusComponent,
    DEEPSystemEventComponent,
    DEEPTradesComponent,
    DEEPTradeBreakComponent,
    DEEPTradingStatusComponent,
    LastComponent,
    TopsComponent,
  ],
  exports: [
    DEEPComponent,
    DEEPAuctionComponent,
    DEEPBookComponent,
    DEEPOperationalHaltStatusComponent,
    DEEPOfficialPriceComponent,
    DEEPSecurityEventComponent,
    DEEPShortSalePriceTestStatusComponent,
    DEEPSystemEventComponent,
    DEEPTradesComponent,
    DEEPTradeBreakComponent,
    DEEPTradingStatusComponent,
    LastComponent,
    TopsComponent,
  ]
})
export class InvestorsExchangeDataPageModule {}
