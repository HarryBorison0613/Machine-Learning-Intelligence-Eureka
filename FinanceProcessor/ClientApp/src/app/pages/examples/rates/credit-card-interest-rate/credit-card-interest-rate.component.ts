import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "rates-credit-card-interest-rate",
  templateUrl: "credit-card-interest-rate.component.html"
})
export class CreditCardInterestRateComponent implements OnInit {

  creditCardInterestRate: Price[];
  creditCardInterestRateLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService 
  ) { }

  ngOnInit() {
    this.getCreditCardInterestRate();
  }

  getCreditCardInterestRate() {
    this.creditCardInterestRateLoading = true;
    this.creditCardInterestRate = [];
    this.http.get<number>(
      this.baseUrl + `EconomicData/dataPoints?symbol=TERMCBCCALLNS`
    ).subscribe(result => {
      this.creditCardInterestRate.push({price: result});
      this.creditCardInterestRateLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.creditCardInterestRateLoading = false;
    });
  }
}

interface Price {
  price: number;
}
