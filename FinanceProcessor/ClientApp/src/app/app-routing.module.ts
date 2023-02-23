import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { Routes, RouterModule } from "@angular/router";

import { AdminLayoutComponent } from "./layouts/admin-layout/admin-layout.component";
import { AuthLayoutComponent } from "./layouts/auth-layout/auth-layout.component";
//import { AuthorizeGuard } from "src/api-authorization/authorize.guard";
import { RegisterComponent } from "./auth/register/register.component";
import { PreRegisterComponent } from "./auth/pre-register/pre-register.component";
import { LoginComponent } from "./auth/login/login.component";
import { AboutUsComponent } from "./contact/about-us/about-us.component";
import { FAQComponent } from "./contact/faq/faq.component";
import { TermsAndConditionsComponent } from "./contact/terms-conditions/terms-conditions.component";
import { PrivacyPolicyComponent } from "./contact/privacy-policy/privacy-policy.component";
import { ContactUsComponent } from "./contact/contact-us/contact-us.component";

import { MembershipComponent } from "./pages/membership/membership.component";
import { PaypalComponent } from "./pages/payment/paypal/paypal.component";
import { ProfileComponent } from "./pages/profile/profile.component";

const routes: Routes = [ 
  {
    path: "",
    redirectTo: "dashboard",
    pathMatch: "full"
  },
  {
    path: "login",
    component: LoginComponent,
    children: [
      {
        path: "login",
        loadChildren: () => import('./auth/login/login.component').then(x=>x.LoginComponent)
      }
    ]
  },
  {
    path: "pre-register",
    component: PreRegisterComponent,
    children: [
      {
        path: "pre-register",
        loadChildren: () => import('./auth/pre-register/pre-register.component').then(x=>x.PreRegisterComponent)
      }
    ]
  },
  {
    path: "register",
    component: RegisterComponent,
    children: [
      {
        path: "register",
        loadChildren: () => import('./auth/register/register.component').then(x=>x.RegisterComponent)
      }
    ]
  },
  {
    path: "about-us",
    component: AboutUsComponent,
    children: [
      {
        path: "about-us",
        loadChildren: () => import('./contact/about-us/about-us.component').then(x=>x.AboutUsComponent)
      }
    ]
  },
  {
    path: "faq",
    component: FAQComponent,
    children: [
      {
        path: "faq",
        loadChildren: () => import('./contact/faq/faq.component').then(x=>x.FAQComponent)
      }
    ]
  },
  {
    path: "terms-conditions",
    component: TermsAndConditionsComponent,
    children: [
      {
        path: "terms-conditions",
        loadChildren: () => import('./contact/terms-conditions/terms-conditions.component').then(x=>x.TermsAndConditionsComponent)
      }
    ]
  },
  {
    path: "privacy-policy",
    component: PrivacyPolicyComponent,
    children: [
      {
        path: "privacy-policy",
        loadChildren: () => import('./contact/privacy-policy/privacy-policy.component').then(x=>x.PrivacyPolicyComponent)
      }
    ]
  },
  {
    path: "contact-us",
    component: ContactUsComponent,
    children: [
      {
        path: "contact-us",
        loadChildren: () => import('./contact/contact-us/contact-us.component').then(x=>x.ContactUsComponent)
      }
    ]
  },
  {
    path: "",
    component: AdminLayoutComponent,
    children: [
      {
        path: "",
        loadChildren: () => import('./pages/examples/dashboard/dashboard.module').then(x => x.DashboardModule),
      },
      {
        path: "membership",
        component: MembershipComponent,
        children: [
          {
            path: "membership",
            loadChildren: () => import('./pages/membership/membership.component').then(x=>x.MembershipComponent)
          }
        ]
      },
      {
        path: "profile",
        component: ProfileComponent,
        children: [
          {
            path: "profile",
            loadChildren: () => import('./pages/profile/profile.component').then(x=>x.ProfileComponent)
          }
        ]
      },
      {
        path: "payment/paypal",
        component: PaypalComponent,
        children: [
          {
            path: "payment/paypal",
            loadChildren: () => import('./pages/payment/paypal/paypal.component').then(x=>x.PaypalComponent)
          }
        ]
      },
      {
        path: "stocks-equities",
        loadChildren: () => import('./pages/examples/stocks-equities/stocks-equities.module').then(x => x.StocksEquitiesPageModule)
      },
      {
        path: "news",
        loadChildren: () => import('./pages/examples/news/news.module').then(x => x.NewsPageModule)
      },
      {
        path: "cryptocurrency",
        loadChildren: () => import('./pages/examples/cryptocurrency/cryptocurrency.module').then(x => x.CryptocurrencyPageModule)
      },
      {
        path: "forex-currencies",
        loadChildren: () => import('./pages/examples/forex-currencies/forex-currencies.module').then(x => x.ForexCurrenciesPageModule)
      },
      {
        path: "options",
        loadChildren: () => import('./pages/examples/options/options.module').then(x => x.OptionsPageModule)
      },
      {
        path: "futures",
        loadChildren: () => import('./pages/examples/futures/futures.module').then(x => x.FuturesPageModule)
      },
      {
        path: "treasuries",
        loadChildren: () => import('./pages/examples/treasures/treasures.module').then(x => x.TreasuresPageModule)
      },
      {
        path: "commodities",
        loadChildren: () => import('./pages/examples/commodities/commodities.module').then(x => x.CommoditiesPageModule)
      },
      {
        path: "economic-data",
        loadChildren: () => import('./pages/examples/economic-data/economic-data.module').then(x => x.EconomicDataPageModule)
      },
      {
        path: "rates",
        loadChildren: () => import('./pages/examples/rates/rates.module').then(x => x.RatesPageModule)
      },
      {
        path: "mortgage",
        loadChildren: () => import('./pages/examples/mortgage/mortgage.module').then(x => x.MortgagePageModule)
      },
      {
        path: "reference-data",
        loadChildren: () => import('./pages/examples/reference-data/reference-data.module').then(x => x.ReferenceDataPageModule)
      },
      {
        path: "investors-exchange-data",
        loadChildren: () => import('./pages/examples/investors-exchange-data/investors-exchange-data.module').then(x => x.InvestorsExchangeDataPageModule)
      },
      {
        path: "markets",
        loadChildren: () => import('./pages/examples/markets/markets.module').then(x => x.MarketsPageModule)
      },
      {
        path: "ticker",
        loadChildren: () => import('./pages/examples/ticker/ticker.module').then(x => x.TickerPageModule)
      },
      {
        path: "flow",
        loadChildren: () => import('./pages/examples/flow/flow.module').then(x => x.FlowPageModule)
      },
      {
        path: "swing-AI",
        loadChildren: () => import('./pages/examples/swing-AI/swing-AI.module').then(x => x.SwingAIModule)
      },
      {
        path: "intraday-AI",
        loadChildren: () => import('./pages/examples/intraday-AI/intraday-AI.module').then(x => x.IntradayAIModule)
      },
      {
        path: "scanner",
        loadChildren: () => import('./pages/examples/scanner/scanner.module').then(x => x.ScannerPageModule)
      },
      {
        path: "investing",
        loadChildren: () => import('./pages/examples/investing/investing.module').then(x => x.InvestingPageModule)
      },
      {
        path: "research",
        loadChildren: () => import('./pages/examples/research/research.module').then(x => x.ResearchPageModule)
      },
      {
        path: "complex-tools",
        loadChildren: () => import('./pages/examples/complex-tools/complex-tools.module').then(x => x.ComplexToolsPageModule)
      },
      {
        path: "help",
        loadChildren: () => import('./pages/examples/help/help.module').then(x => x.HelpPageModule)
      },
      {
        path: "audit-analytics",
        loadChildren: () => import('./pages/examples/audit-analytics/audit-analytics.module').then(x => x.AuditAnalyticsPageModule),
      },
      {
        path: "brain-company",
        loadChildren: () => import('./pages/examples/brain-company/brain-company.module').then(x => x.BrainCompanyPageModule),
      },
      {
        path: "city-falcon",
        loadChildren: () => import('./pages/examples/city-falcon/city-falcon.module').then(x => x.CityFalconPageModule),
      },
      {
        path: "extract-alpha",
        loadChildren: () => import('./pages/examples/extract-alpha/extract-alpha.module').then(x => x.ExtractAlphaPageModule),
      },
      {
        path: "fraud-factors",
        loadChildren: () => import('./pages/examples/fraud-factors/fraud-factors.module').then(x => x.FraudFactorsPageModule),
      },
      {
        path: "kavout",
        loadChildren: () => import('./pages/examples/kavout/kavout.module').then(x => x.KavoutPageModule),
      },
      {
        path: "new-constructs",
        loadChildren: () => import('./pages/examples/new-constructs/new-constructs.module').then(x => x.NewConstructsPageModule),
      },
      {
        path: "precision-alpha",
        loadChildren: () => import('./pages/examples/precision-alpha/precision-alpha.module').then(x => x.PrecisionAlphaPageModule),
      },
      {
        path: "refinitiv",
        loadChildren: () => import('./pages/examples/refinitiv/refinitiv.module').then(x => x.RefinitivPageModule),
      },
      {
        path: "stock-twits",
        loadChildren: () => import('./pages/examples/stock-twits/stock-twits.module').then(x => x.StockTwitsModule),
      },
    ]
  },
  {
    path: "**",
    redirectTo: "dashboard" 
  }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes, {
      useHash: true,
      scrollPositionRestoration: "enabled",
      anchorScrolling: "enabled",
      scrollOffset: [0, 64]
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
