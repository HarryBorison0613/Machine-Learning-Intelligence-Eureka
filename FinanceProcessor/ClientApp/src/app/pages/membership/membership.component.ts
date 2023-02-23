import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/_services/user.service';
import { GlobalVariable } from 'src/app/_services/global.variable';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { TokenStorageService } from 'src/app/_services/token-storage.service';
import { PaymentService } from 'src/app/_services/payment.service';

@Component({
  selector: 'app-membership',
  styleUrls: ['membership.component.scss'],
  templateUrl: 'membership.component.html',
})
export class MembershipComponent implements OnInit, OnDestroy {
  userId: string;
  requested_role: string;
  image_url: string;
  home_url: string;

  plan_id: string;
  subscriber: any;
  locale: string;
  return_url: string;
  cancel_url: string;

  name: any;
  email_address: string;
  shipping_address: any;

  firstName: string;
  lastName: string;
  fullName: string;
  address_line_1: string;
  address_line_2: string;
  admin_area_2: string;
  admin_area_1: string;
  postal_code: string;
  country_code: string;

  constructor(
    private router: Router,
    private globalvariabl: GlobalVariable,
    private userService: UserService,
    public toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private tokenStorage: TokenStorageService,
    private paymentService: PaymentService
  ) {
    this.spinner.show();
  }

  ngOnInit() {
    var body = document.getElementsByTagName('body')[0];
    body.classList.add('pricing-page');
    this.userId = this.tokenStorage.getUser().userId;

    this.userService.getUserInfo(this.userId).subscribe({
      next: (data) => {
        this.spinner.hide();
        this.firstName = data.firstName;
        this.lastName = data.lastName;
        this.fullName = this.firstName.concat(' ', this.lastName);
        this.email_address = data.email;
        this.address_line_1 = data.address;
        this.address_line_2 = data.aptSuite;
        this.admin_area_1 = data.regionCode;
        this.admin_area_2 = data.city;
        this.postal_code = data.postal_code;
        this.country_code = data.country;
      },
      error: (err) => {
        this.spinner.hide();
        console.log(err.error);
      },
    });
  }
  ngOnDestroy() {
    var body = document.getElementsByTagName('body')[0];
    body.classList.remove('pricing-page');
  }

  beginTrial(): void {
    const trialDay = 7;
    this.router.navigate(['./dashboard']);
  }

  startBasic(): void {
    const monthlyPay = '30';
    const annuallyPay = '360';
    this.globalvariabl.setPrice(monthlyPay, annuallyPay);
    this.requested_role = 'BasicUser';
    this.image_url =
      'https://seeklogo.com/images/D/dollar-logo-0683682259-seeklogo.com.jpg';
    this.home_url = 'https://machinelearningintelligence.com/#/membership';

    this.paymentService
      .createPlan(this.requested_role, this.image_url, this.home_url)
      .subscribe({
        next: (data) => {
          window.alert('Do you agree with Subscription as a Basic User?');
          this.startSubscription(data.result);
        },
        error: (err) => {
          console.log(err.error);
        },
      });
    // this.router.navigate(['./payment/paypal']);
  }

  startSubscription(firstResult): void {
    this.plan_id = firstResult.id;
    this.subscriber = {
      name: {
        given_name: this.firstName,
        surname: this.lastName,
      },
      email_address: this.email_address,
      shipping_address: {
        name: {
          full_name: this.fullName,
        },
        Address: {
          address_line_1: this.address_line_1,
          address_line_2: this.address_line_2,
          admin_area_1: this.admin_area_1,
          admin_area_2: this.admin_area_2,
          postal_code: this.postal_code,
          country_code: this.country_code,
        },
      },
    };
    this.locale = 'en-US';
    this.return_url = 'https://machinelearningintelligence.com/#/membership';
    this.cancel_url = 'https://machinelearningintelligence.com/cancel';
    this.spinner.show();

    this.paymentService
      .startSubscription(
        this.plan_id,
        this.subscriber,
        this.locale,
        this.return_url,
        this.cancel_url
      )
      .subscribe({
        next: (data) => {
          console.log('this is new subscription started', data);
          this.spinner.hide();
          this.toastr.show(
            '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
            this.requested_role +
              ' Subscription started! 7 days of Trial Started! Status ' +
              data.result.status,
            {
              timeOut: 4000,
              closeButton: true,
              enableHtml: true,
              toastClass: 'alert alert-success alert-with-icon',
              positionClass: 'toast-top-right',
            }
          );
          this.router.navigate(['./dashboard']);
        },
        error: (err) => {
          console.log(err.error);
          this.spinner.hide();
          this.toastr.show(
            '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
            err.error,
            {
              timeOut: 4000,
              closeButton: true,
              enableHtml: true,
              toastClass: 'alert alert-danger alert-with-icon',
              positionClass: 'toast-top-right',
            }
          );
        },
      });
  }

  startPro(): void {
    this.toastr.show(
      '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
      'This package will be enable later',
      {
        timeOut: 4000,
        closeButton: true,
        enableHtml: true,
        toastClass: 'alert alert-info alert-with-icon',
        positionClass: 'toast-top-right',
      }
    );
    // const monthlyPay = "60";
    // const annuallyPay = "720";
    // this.globalvariabl.setPrice(monthlyPay, annuallyPay);
    // this.router.navigate(['./payment/paypal'])
  }

  startExpert(): void {
    this.toastr.show(
      '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
      'This package will be enable later',
      {
        timeOut: 4000,
        closeButton: true,
        enableHtml: true,
        toastClass: 'alert alert-info alert-with-icon',
        positionClass: 'toast-top-right',
      }
    );
    // const monthlyPay = "90";
    // const annuallyPay = "1080";
    // this.globalvariabl.setPrice(monthlyPay, annuallyPay);
    // this.router.navigate(['./payment/paypal'])
  }
}
