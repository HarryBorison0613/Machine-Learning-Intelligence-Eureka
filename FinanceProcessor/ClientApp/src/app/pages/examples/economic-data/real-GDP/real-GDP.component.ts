import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { TimeSeries } from "src/app/pages/domain/economic";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "economic-data-real-GDP",
  templateUrl: "real-GDP.component.html"
})
export class RealGDPComponent implements OnInit {

  realGdp: TimeSeries[];
  realGdpLoading: boolean = false;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService  
  ) { }

  ngOnInit() {
    this.getRealGdp();
  }

  getRealGdp() {
    this.realGdpLoading = true;
    this.http.get<TimeSeries[]>(
      this.baseUrl + `EconomicData/timeSeries?symbol=A191RL1Q225SBEA`
    ).subscribe(result => {
      this.realGdp = result;
      this.realGdpLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.realGdpLoading = false;
    });
  }
}
