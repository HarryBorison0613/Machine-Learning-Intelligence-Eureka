import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from "@angular/common";
import { ToastrModule } from "ngx-toastr";
import { DatePipe } from '@angular/common';
import { TableModule } from 'primeng/table';
import { NgxSpinnerModule } from "ngx-spinner";

import { AppComponent } from './app.component';
import { AdminLayoutComponent } from "./layouts/admin-layout/admin-layout.component";
import { AuthLayoutComponent } from "./layouts/auth-layout/auth-layout.component";

import { AppRoutingModule } from "./app-routing.module";
import { ComponentsModule } from "./components/components.module";
import { RtlLayoutComponent } from "./layouts/rtl-layout/rtl-layout.component";
import { ProgressbarModule } from "ngx-bootstrap/progressbar";
import { NgxPayPalModule } from "./pages/payment/ngx-paypal-lib/src/public_api";
import { DropdownModule } from 'primeng/dropdown';
import { AutoCompleteModule } from 'primeng/autocomplete';

import { StockService } from "./pages/service/stockservice";
import { DashboardService } from "./pages/service/dashboardservice";
import { ErrorService } from "./pages/service/errorservice";

import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { RegisterComponent } from "./auth/register/register.component";
import { LoginComponent } from "./auth/login/login.component";
import { MembershipComponent } from "./pages/membership/membership.component";
import { PaypalComponent } from "./pages/payment/paypal/paypal.component";
import { ProfileComponent } from "./pages/profile/profile.component";

@NgModule({
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    AuthLayoutComponent,
    RtlLayoutComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    RegisterComponent,
    LoginComponent,
    MembershipComponent,
    PaypalComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ApiAuthorizationModule,
    RouterModule,
    ProgressbarModule,
    NgxPayPalModule,
    DropdownModule,
    NgxSpinnerModule,
    /*.forRoot([innerModule has
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
    ])*/
    AppRoutingModule,
    ToastrModule.forRoot(),
    ComponentsModule,
    TableModule,
    AutoCompleteModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    DatePipe, StockService, DashboardService, ErrorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
