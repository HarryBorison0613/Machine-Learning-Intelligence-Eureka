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

import { DarkpoolComponent } from "./darkpool/darkpool.component";
import { CryptoComponent } from "./crypto/crypto.component";
import { OptionsComponent } from "./options/options.component";
import { StocksComponent } from "./stocks/stocks.component";

import { TickerRoutes } from "./ticker.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(TickerRoutes),
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
    DarkpoolComponent,
    CryptoComponent,
    OptionsComponent,
    StocksComponent,
  ],
  exports: [
    DarkpoolComponent,
    CryptoComponent,
    OptionsComponent,
    StocksComponent
  ]
})
export class TickerPageModule {}
