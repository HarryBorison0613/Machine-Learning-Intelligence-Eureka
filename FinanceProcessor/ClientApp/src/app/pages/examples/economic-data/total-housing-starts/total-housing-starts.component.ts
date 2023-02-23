import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { TimeSeries } from "src/app/pages/domain/economic";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "economic-data-total-housing-starts",
  templateUrl: "total-housing-starts.component.html"
})
export class TotalHousingStatsComponent implements OnInit {

  totalHousingStarts: TimeSeries[];
  totalHousingStartsLoading: boolean = false;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService  
  ) { }

  ngOnInit() {
    this.getTotalHousingStarts();
  }

  getTotalHousingStarts() {
    this.totalHousingStartsLoading = true;
    this.http.get<TimeSeries[]>(
      this.baseUrl + `EconomicData/timeSeries?symbol=HOUST`
    ).subscribe(result => {
      this.totalHousingStarts = result;
      this.totalHousingStartsLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.totalHousingStartsLoading = false;
    });
  }
}
