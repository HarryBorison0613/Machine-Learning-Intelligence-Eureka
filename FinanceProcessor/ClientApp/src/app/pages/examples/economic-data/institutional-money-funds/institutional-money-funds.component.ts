import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "economic-data-institutional-money-funds",
  templateUrl: "institutional-money-funds.component.html"
})
export class InstitutionalMoneyFundsComponent implements OnInit {

  institutionalMoneyFunds: FederalFunds[];
  institutionalMoneyFundsLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService 
  ) { }

  ngOnInit() {
    this.getInstitutionalMoneyFunds();
  }

  getInstitutionalMoneyFunds() {
    this.institutionalMoneyFundsLoading = true;
    this.institutionalMoneyFunds = [];
    this.http.get<number>(
      this.baseUrl + `EconomicData/dataPoints?symbol=WIMFSL`
    ).subscribe(result => {
      this.institutionalMoneyFunds.push({price: result});
      this.institutionalMoneyFundsLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.institutionalMoneyFundsLoading = false;
    });
  }
}

interface FederalFunds {
  price: number;
}
