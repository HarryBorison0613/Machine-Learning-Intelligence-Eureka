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

import { CrossAssetModel1Component } from "./cross-asset-model-1/cross-asset-model-1.component";
import { ESGCFPBComplaintsComponent } from "./esg-cfpb-complaints/esg-cfpb-complaints.component";
import { ESGDOLVisaApplicationsComponent } from "./esg-dol-visa-applications/esg-dol-visa-applications.component";
import { ESGEPAEnforcementsComponent } from "./esg-epa-enforcements/esg-epa-enforcements.component";
import { ESGEPAMilestonesComponent } from "./esg-epa-milestones/esg-epa-milestones.component";
import { ESGFECIndividualCampaignContributionsComponent } from "./esg-fec-individual-campaign-contributions/esg-fec-individual-campaign-contributions.component";
import { ESGOSHAInspectionsComponent } from "./esg-osha-inspections/esg-osha-inspections.component";
import { ESGSenateLobbyingComponent } from "./esg-senate-lobbying/esg-senate-lobbying.component";
import { ESGUSASpendingComponent } from "./esg-usa-spending/esg-usa-spending.component";
import { ESGUSPTOPatentApplicationsComponent } from "./esg-uspto-patent-applications/esg-uspto-patent-applications.component";
import { ESGUSPTOPatentGrantsComponent } from "./esg-uspto-patent-grants/esg-uspto-patent-grants.component";
import { TacticalModel1Component } from "./tactical-model-1/tactical-model-1.component";

import { ExtractAlphaRoutes } from "./extract-alpha.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(ExtractAlphaRoutes),
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
    CrossAssetModel1Component,
    ESGCFPBComplaintsComponent,
    ESGDOLVisaApplicationsComponent,
    ESGEPAEnforcementsComponent,
    ESGEPAMilestonesComponent,
    ESGFECIndividualCampaignContributionsComponent,
    ESGOSHAInspectionsComponent,
    ESGSenateLobbyingComponent,
    ESGUSASpendingComponent,
    ESGUSPTOPatentApplicationsComponent,
    ESGUSPTOPatentGrantsComponent,
    TacticalModel1Component,
  ],
  exports: [
    CrossAssetModel1Component,
    ESGCFPBComplaintsComponent,
    ESGDOLVisaApplicationsComponent,
    ESGEPAEnforcementsComponent,
    ESGEPAMilestonesComponent,
    ESGFECIndividualCampaignContributionsComponent,
    ESGOSHAInspectionsComponent,
    ESGSenateLobbyingComponent,
    ESGUSASpendingComponent,
    ESGUSPTOPatentApplicationsComponent,
    ESGUSPTOPatentGrantsComponent,
    TacticalModel1Component,
  ]
})
export class ExtractAlphaPageModule {}
