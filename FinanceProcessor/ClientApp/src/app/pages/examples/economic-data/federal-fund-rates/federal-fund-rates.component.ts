import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "economic-data-federal-fund-rates",
  templateUrl: "federal-fund-rates.component.html"
})
export class FederalFundRatesComponent implements OnInit {

  fedFunds: FederalFunds[];
  fedFundsLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService 
  ) { }

  ngOnInit() {
    this.getFedFunds();
  }

  getFedFunds() {
    this.fedFundsLoading = true;
    this.fedFunds = [];
    this.http.get<number>(
      this.baseUrl + `EconomicData/dataPoints?symbol=FEDFUNDS`
    ).subscribe(result => {
      this.fedFunds.push({price: result});
      this.fedFundsLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.fedFundsLoading = false;
    });
  }
}

interface FederalFunds {
  price: number;
}
