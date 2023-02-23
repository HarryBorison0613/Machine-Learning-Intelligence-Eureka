import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "economic-data-retail-money-funds",
  templateUrl: "retail-money-funds.component.html"
})
export class RetailMoneyFundsComponent implements OnInit {

  retailMoneyFunds: Price[];
  retailMoneyFundsLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService 
  ) { }

  ngOnInit() {
    this.getRetailMoneyFunds();
  }

  getRetailMoneyFunds() {
    this.retailMoneyFundsLoading = true;
    this.retailMoneyFunds = [];
    this.http.get<number>(
      this.baseUrl + `EconomicData/dataPoints?symbol=WRMFSL`
    ).subscribe(result => {
      this.retailMoneyFunds.push({price: result});
      this.retailMoneyFundsLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.retailMoneyFundsLoading = false;
    });
  }
}

interface Price {
  price: number;
}
