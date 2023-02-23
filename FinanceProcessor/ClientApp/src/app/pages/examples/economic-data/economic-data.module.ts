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

import { ConsumerPriceComponent } from "./consumer-price-index/consumer-price-index.component";
import { FederalFundRatesComponent } from "./federal-fund-rates/federal-fund-rates.component";
import { IndustrialProductionIndexComponent } from "./industrial-production-index/industrial-production-index.component";
import { InitialClaimsComponent } from "./initial-claims/initial-claims.component";
import { InstitutionalMoneyFundsComponent } from "./institutional-money-funds/institutional-money-funds.component";
import { RealGDPComponent } from "./real-GDP/real-GDP.component";
import { RetailMoneyFundsComponent } from "./retail-money-funds/retail-money-funds.component";
import { TotalHousingStatsComponent } from "./total-housing-starts/total-housing-starts.component";
import { TotalPayrollsComponent } from "./total-payrolls/total-payrolls.component";
import { TotalVehicleSalesComponent } from "./total-vehicle-sales/total-vehicle-sales.component";
import { UnemploymentRateComponent } from "./unemployment-rate/unemployment-rate.component";
import { USRecessionProbabilitiesComponent } from "./us-recession-probabilities/us-recession-probabilities.component";

import { EconomicDataRoutes } from "./economic-data.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(EconomicDataRoutes),
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
    ConsumerPriceComponent,
    FederalFundRatesComponent,
    IndustrialProductionIndexComponent,
    InitialClaimsComponent,
    InstitutionalMoneyFundsComponent,
    RealGDPComponent,
    RetailMoneyFundsComponent,
    TotalHousingStatsComponent,
    TotalPayrollsComponent,
    TotalVehicleSalesComponent,
    UnemploymentRateComponent,
    USRecessionProbabilitiesComponent,
  ],
  exports: [
    ConsumerPriceComponent,
    FederalFundRatesComponent,
    IndustrialProductionIndexComponent,
    InitialClaimsComponent,
    InstitutionalMoneyFundsComponent,
    RealGDPComponent,
    RetailMoneyFundsComponent,
    TotalHousingStatsComponent,
    TotalPayrollsComponent,
    TotalVehicleSalesComponent,
    UnemploymentRateComponent,
    USRecessionProbabilitiesComponent,
  ]
})
export class EconomicDataPageModule {}
