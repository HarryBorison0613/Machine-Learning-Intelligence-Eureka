import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";
import { TimeSeries } from "src/app/pages/domain/economic";

@Component({
  selector: "mortgage-mortgage-rates",
  templateUrl: "mortgage-rates.component.html"
})
export class MortgageRatesComponent implements OnInit {

  mortgageRates: TimeSeries[];
  mortgageRatesLoading: boolean = false;
  type: string;
  types: any[];

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService 
  ) {
    this.type = 'MORTGAGE30US';
   }

  ngOnInit() {
    this.getMortgageRates(this.type);
    this.types = [
      { label: 'Please select mortgage type', value: 'MORTGAGE5US'},
      { label: 'MORTGAGE5US', value: 'MORTGAGE5US'},
      { label: 'MORTGAGE10US', value: 'MORTGAGE10US'},
      { label: 'MORTGAGE30US', value: 'MORTGAGE30US'},
    ]
  }

  getMortgageRates(type) {
    this.mortgageRatesLoading = true;
    this.mortgageRates = [];
    this.http.get<TimeSeries[]>(
      this.baseUrl + `EconomicData/timeseries?symbol=${type}`
    ).subscribe(result => {
      this.mortgageRates.concat(result);
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
    });
    this.http.get<TimeSeries[]>(
      this.baseUrl + `EconomicData/timeseries?symbol=MORTGAGE15US`
    ).subscribe(result => {
      this.mortgageRates.concat(result);
    }, (err) => {
    });
    this.http.get<TimeSeries[]>(
      this.baseUrl + `EconomicData/timeseries?symbol=MORTGAGE5US`
    ).subscribe(result => {
      this.mortgageRates.concat(result);
      this.mortgageRatesLoading = false;
  }, (err) => {
      this.mortgageRatesLoading = false;
  });
  }
}
