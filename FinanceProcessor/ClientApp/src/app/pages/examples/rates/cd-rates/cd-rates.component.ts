import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "rates-cd-rates",
  templateUrl: "cd-rates.component.html"
})
export class CDRatesComponent implements OnInit {

  cdRates: Price[];
  cdRatesLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService 
  ) { }

  ngOnInit() {
    this.getCdRates();
  }

  getCdRates() {
    this.cdRatesLoading = true;
    this.cdRates = [];
    this.http.get<number>(
      this.baseUrl + `EconomicData/dataPoints?symbol=MMNRNJ`
    ).subscribe(result => {
      this.cdRates.push({price: result, symbol: 'MMNRNJ'});
    }, (err) => {
      if(err.status === 500) {
        console.log(err);
      }
    });
    this.http.get<number>(
      this.baseUrl + `EconomicData/dataPoints?symbol=MMNRJD`
    ).subscribe(result => {
      this.cdRates.push({price: result, symbol: 'MMNRJD'});
      this.cdRatesLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.cdRatesLoading = false;
    });
  }
}

interface Price {
  symbol: string;
  price: number;
}
