import { Routes } from "@angular/router";

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

export const ExtractAlphaRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "cross-asset-model-1",
        component: CrossAssetModel1Component
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "esg-cfpb-complaints",
        component: ESGCFPBComplaintsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "esg-dol-visa-applications",
        component: ESGDOLVisaApplicationsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "esg-epa-enforcements",
        component: ESGEPAEnforcementsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "esg-epa-milestones",
        component: ESGEPAMilestonesComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "esg-fec-individual-campaign-contributions",
        component: ESGFECIndividualCampaignContributionsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "esg-osha-inspections",
        component: ESGOSHAInspectionsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "esg-senate-lobbying",
        component: ESGSenateLobbyingComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "esg-usa-spending",
        component: ESGUSASpendingComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "esg-uspto-patent-applications",
        component: ESGUSPTOPatentApplicationsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "esg-uspto-patent-grants",
        component: ESGUSPTOPatentGrantsComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "tactical-model-1",
        component: TacticalModel1Component
      }
    ]
  },
];
