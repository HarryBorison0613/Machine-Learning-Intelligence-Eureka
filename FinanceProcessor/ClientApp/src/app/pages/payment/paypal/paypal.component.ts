import {
  AfterViewInit,
  ChangeDetectionStrategy,
  Component,
  ElementRef,
  OnInit,
  ViewChild,
  ChangeDetectorRef
} from "@angular/core";

import {
  ICreateOrderRequest,
  IPayPalConfig,
} from "../ngx-paypal-lib/src/public_api";

import { TokenStorageService } from "src/app/_services/token-storage.service";
import { PaymentService } from "src/app/_services/payment.service";
import { ToastrService } from "ngx-toastr";
import { Router } from '@angular/router';
import { GlobalVariable } from "src/app/_services/global.variable";
import { NgxSpinnerService } from "ngx-spinner";

declare var hljs: any;

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: "./paypal.component.html",
  styleUrls: ["./paypal.component.scss"]
})
export class PaypalComponent implements OnInit {

  public defaultPrice: string = this.globalvariable.getPrice().monthlyPrice;
  public payPalConfig?: IPayPalConfig;

  public createOrderShow: boolean = true;
  public payTheOrderShow: boolean = false;

  public showSuccess: boolean = false;
  public showCancel: boolean = false;
  public showError: boolean = false;

  public customFlag: boolean = true;

  application_context: any = {
    cancel_url: "https://www.exempl.cpm",
    return_url: "https://machinelearningintelligence.com/#/payment/paypal"
  }
  purchase_units: any = [{
    amount: {
      currency_code: "USD",
      value: "30"
    }
  }]
  claimed_role: "userRole";

  userId: string = "";  
  orderId: string = "";

  periodOptions: any[];
  selectedPeriodOption: string;

  @ViewChild("priceElem", { static: false }) priceElem?: ElementRef;

  constructor( private tokenStorage: TokenStorageService, private paymentService: PaymentService, private globalvariable: GlobalVariable, public toastr: ToastrService, private cd: ChangeDetectorRef, private spinner: NgxSpinnerService ) {
    this.selectedPeriodOption = 'monthly';
    this.spinner.show();
  }

  ngOnInit(): void {
    this.claimed_role = this.tokenStorage.getUser().userRole;
    this.userId = this.tokenStorage.getUser().userId;
    this.periodOptions = [{label: 'Monthly', value: 'monthly'}, {label: 'Annually', value: 'annually'}];
    this.getBonusIssues(this.selectedPeriodOption);
    this.spinner.hide();
  }

  getBonusIssues(selectedPeriodOption) {
    if (selectedPeriodOption == "monthly") {
      this.defaultPrice = this.globalvariable.getPrice().monthlyPrice;
    } else {
      this.defaultPrice = this.globalvariable.getPrice().annualPrice;
    }
  }
  CreateOrder(): void {
  
    this.purchase_units[0].amount.value = this.priceElem.nativeElement.value;  

    this.paymentService.createorder(this.application_context, this.purchase_units, this.claimed_role).subscribe({
      next: data => {
        
        this.orderId = data.result.id;
        if (data.result.status == "CREATED") {
          this.createOrderShow = false;
          this.payTheOrderShow = true;
          this.showPaypalMessage("The Purchase Order " + data.result.status + "! Please check Paypal");
          this.cd.markForCheck();
        }
        window.open(`${data.result.links[1].href}`);
        // location.href = data.result.links[1].href;
      },
      error: err => {
        console.log("this is error", err);
        this.showPaypalMessage(err);
      }
    });
  }

  PayTheOrder(): void {
    
    this.paymentService.paytheorder(this.userId, this.orderId).subscribe({
      next: data => {
        console.log("this is paytheorder Response", data);
        if (data.result.status == "COMPLETED") {
          this.createOrderShow = true;
          this.payTheOrderShow = false;
          this.showPaypalMessage("The Payment for the order " + data.result.status + "! Please check Paypal");
          this.cd.markForCheck();
        }
      },
      error: err => {
        console.log("this is error", err);
        this.showPaypalMessage(err);
      }
    })
  }

  customPrice(): void {
    console.log("custom price called!");
    this.customFlag = false;
    this.defaultPrice = "0";
  }

  showPaypalMessage(message) {
    this.toastr.show(
      '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
      message,
      {
        timeOut: 10000,
        closeButton: true,
        enableHtml: true,
        toastClass: "alert alert-sucess alert-with-icon",
        positionClass: "toast-top-right"
      }
    );
  }
}
