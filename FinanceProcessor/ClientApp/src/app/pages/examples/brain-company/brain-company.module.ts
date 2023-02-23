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

import { BrainCompanys2DayMachineLearningEstimatedComponent } from "./bs-2-day-ml/bs-2-day-ml.component";
import { BrainCompanys3DayMachineLearningEstimatedComponent } from "./bs-3-day-ml/bs-3-day-ml.component";
import { BrainCompanys5DayMachineLearningEstimatedComponent } from "./bs-5-day-ml/bs-5-day-ml.component";
import { BrainCompanys10DayMachineLearningEstimatedComponent } from "./bs-10-day-ml/bs-10-day-ml.component";
import { BrainCompanys7DaySentimentIndicatorComponent } from "./bs-7-day-si/bs-7-day-si.component";
import { BrainCompanys30DaySentimentIndicatorComponent } from "./bs-30-day-si/bs-30-day-si.component";
import { BrainCompanys21DayMachineLearningEstimatedComponent } from "./bs-21-day-ml/bs-21-day-ml.component";
import { BrainCompanysDifferencesAnnualComponent } from "./bs-differences-annual/bs-differences-annual.component";
import { BrainCompanysDifferencesQuarterlyAnnualComponent } from "./bs-differences-quarterly-annual/bs-differences-quarterly-annual.component";
import { BrainCompanysLanguageMetricsAnnualOnlyComponent } from "./bs-lm-annual-only/bs-lm-annual-only.component";
import { BrainCompanysLanguageMetricsQuarterlyAnnualyComponent } from "./bs-lm-quarterly-annualy/bs-lm-quarterly-annualy.component";

import { BrainCompanyRoutes } from "./brain-company.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(BrainCompanyRoutes),
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
    BrainCompanys2DayMachineLearningEstimatedComponent,
    BrainCompanys3DayMachineLearningEstimatedComponent,
    BrainCompanys5DayMachineLearningEstimatedComponent,
    BrainCompanys7DaySentimentIndicatorComponent,
    BrainCompanys30DaySentimentIndicatorComponent,
    BrainCompanys21DayMachineLearningEstimatedComponent,
    BrainCompanysDifferencesAnnualComponent,
    BrainCompanysDifferencesQuarterlyAnnualComponent,
    BrainCompanysLanguageMetricsAnnualOnlyComponent,
    BrainCompanysLanguageMetricsQuarterlyAnnualyComponent,
    BrainCompanys10DayMachineLearningEstimatedComponent,
  ],
  exports: [
    BrainCompanys2DayMachineLearningEstimatedComponent,
    BrainCompanys3DayMachineLearningEstimatedComponent,
    BrainCompanys5DayMachineLearningEstimatedComponent,
    BrainCompanys7DaySentimentIndicatorComponent,
    BrainCompanys30DaySentimentIndicatorComponent,
    BrainCompanys21DayMachineLearningEstimatedComponent,
    BrainCompanysDifferencesAnnualComponent,
    BrainCompanysDifferencesQuarterlyAnnualComponent,
    BrainCompanysLanguageMetricsAnnualOnlyComponent,
    BrainCompanysLanguageMetricsQuarterlyAnnualyComponent,
    BrainCompanys10DayMachineLearningEstimatedComponent,
  ]
})
export class BrainCompanyPageModule {}
