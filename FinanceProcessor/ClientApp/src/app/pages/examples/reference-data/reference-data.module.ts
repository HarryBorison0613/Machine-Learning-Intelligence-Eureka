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
import { DropdownModule } from "primeng/dropdown";
import { ButtonModule } from "primeng/button";
import { InputTextModule } from "primeng/inputtext";
import { CalendarModule } from 'primeng/calendar';
import { InputNumberModule } from "primeng/inputnumber";

import { CryptocurrencySymbolsComponent } from "./cryptocurrency-symbols/cryptocurrency-symbols.component";
import { FIGIMappingComponent } from "./figi-mapping/figi-mapping.component";
import { FuturesSymbolsBetaComponent } from "./futures-symbols-beta/futures-symbols-beta.component";
import { FXSymbolsComponent } from "./fx-symbols/fx-symbols.component";
import { IEXSymbolsComponent } from "./iex-symbols/iex-symbols.component";
import { InternationalExchangesComponent } from "./international-exchanges/international-exchanges.component";
import { InternationalSymbolsComponent } from "./international-symbols/international-symbols.component";
import { ISINMappingComponent } from "./isin-mapping/isin-mapping.component";
import { MutualFundSymbolsComponent } from "./mutual-fund-symbols/mutual-fund-symbols.component";
import { OptionsSymbolsComponent } from "./options-symbols/options-symbols.component";
import { OTCSymbolsComponent } from "./otc-symbols/otc-symbols.component";
import { RICMappingComponent } from "./ric-mapping/ric-mapping.component";
import { SearchComponent } from "./search/search.component";
import { SectorsComponent } from "./sectors/sectors.component";
import { SymbolsComponent } from "./symbols/symbols.component";
import { TagsComponent } from "./tags/tags.component";
import { USExchangesComponent } from "./us-exchanges/us-exchanges.component";
import { USHolidaysandTradingDatesComponent } from "./us-holidays-and-trading-dates/us-holidays-and-trading-dates.component";

import { ReferenceDataRoutes } from "./reference-data.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(ReferenceDataRoutes),
    FormsModule,
    NgxDatatableModule,
    TableModule,
    AutoCompleteModule,
    ButtonModule,
    DropdownModule,
    InputTextModule,
    CalendarModule,
    InputNumberModule,
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
    CryptocurrencySymbolsComponent,
    FIGIMappingComponent,
    FuturesSymbolsBetaComponent,
    FXSymbolsComponent,
    IEXSymbolsComponent,
    InternationalExchangesComponent,
    InternationalSymbolsComponent,
    ISINMappingComponent,
    MutualFundSymbolsComponent,
    OptionsSymbolsComponent,
    OTCSymbolsComponent,
    RICMappingComponent,
    SearchComponent,
    SectorsComponent,
    SymbolsComponent,
    TagsComponent,
    USExchangesComponent,
    USHolidaysandTradingDatesComponent,
  ],
  exports: [
    CryptocurrencySymbolsComponent,
    FIGIMappingComponent,
    FuturesSymbolsBetaComponent,
    FXSymbolsComponent,
    IEXSymbolsComponent,
    InternationalExchangesComponent,
    InternationalSymbolsComponent,
    ISINMappingComponent,
    MutualFundSymbolsComponent,
    OptionsSymbolsComponent,
    OTCSymbolsComponent,
    RICMappingComponent,
    SearchComponent,
    SectorsComponent,
    SymbolsComponent,
    TagsComponent,
    USExchangesComponent,
    USHolidaysandTradingDatesComponent,
  ]
})
export class ReferenceDataPageModule {}
