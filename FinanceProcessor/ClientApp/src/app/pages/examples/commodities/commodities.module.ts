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
import { ButtonModule } from "primeng/button";
import { DropdownModule } from "primeng/dropdown";

import { OilPricesComponent } from "./oil-prices/oil-prices.component";
import { NaturalGasPriceComponent } from "./natural-gas-price/natural-gas-price.component";
import { HeatingOilPricesComponent } from "./heating-oil-prices/heating-oil-prices.component";
import { JetFuelPricesComponent } from "./jet-fuel-prices/jet-fuel-prices.component";
import { DieselPriceComponent } from "./diesel-price/diesel-price.component";
import { GasPricesComponent } from "./gas-prices/gas-prices.component";
import { PropanePricesComponent } from "./propane-prices/propane-prices.component";

import { CommoditiesRoutes } from "./commodities.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(CommoditiesRoutes),
    FormsModule,
    NgxDatatableModule,
    TableModule,
    ButtonModule,
    DropdownModule,
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
    HeatingOilPricesComponent,
    OilPricesComponent,
    JetFuelPricesComponent,
    NaturalGasPriceComponent,
    DieselPriceComponent,
    GasPricesComponent,
    PropanePricesComponent,
  ],
  exports: [
    HeatingOilPricesComponent,
    OilPricesComponent,
    JetFuelPricesComponent,
    NaturalGasPriceComponent,
    DieselPriceComponent,
    GasPricesComponent,
    PropanePricesComponent,
  ]
})
export class CommoditiesPageModule {}
