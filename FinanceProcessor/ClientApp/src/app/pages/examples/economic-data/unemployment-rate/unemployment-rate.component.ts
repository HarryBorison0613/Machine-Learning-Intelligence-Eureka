import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { TimeSeries } from "src/app/pages/domain/economic";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "economic-data-unemployment-rate",
  templateUrl: "unemployment-rate.component.html"
})
export class UnemploymentRateComponent implements OnInit {

  unemploymentRate: TimeSeries[];
  unemploymentRateLoading: boolean = false;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService  
  ) { }

  ngOnInit() {
    this.getUnemploymentRate();
  }

  getUnemploymentRate() {
    this.unemploymentRateLoading = true;
    this.http.get<TimeSeries[]>(
      this.baseUrl + `EconomicData/timeSeries?symbol=UNRATE`
    ).subscribe(result => {
      this.unemploymentRate = result;
      this.unemploymentRateLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.unemploymentRateLoading = false;
    });
  }
}
