import { Routes } from "@angular/router";

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

export const BrainCompanyRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "bs-2-day-ml",
        component: BrainCompanys2DayMachineLearningEstimatedComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "bs-3-day-ml",
        component: BrainCompanys3DayMachineLearningEstimatedComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "bs-5-day-ml",
        component: BrainCompanys5DayMachineLearningEstimatedComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "bs-7-day-si",
        component: BrainCompanys7DaySentimentIndicatorComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "bs-10-day-ml",
        component: BrainCompanys10DayMachineLearningEstimatedComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "bs-30-day-si",
        component: BrainCompanys30DaySentimentIndicatorComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "bs-21-day-ml",
        component: BrainCompanys21DayMachineLearningEstimatedComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "bs-differences-annual",
        component: BrainCompanysDifferencesAnnualComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "bs-differences-quarterly-annual",
        component: BrainCompanysDifferencesQuarterlyAnnualComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "bs-lm-annual-only",
        component: BrainCompanysLanguageMetricsAnnualOnlyComponent
      }
    ]
  },
  {
    path: "",
    children: [
      {
        path: "bs-lm-quarterly-annualy",
        component: BrainCompanysLanguageMetricsQuarterlyAnnualyComponent
      }
    ]
  },
];
