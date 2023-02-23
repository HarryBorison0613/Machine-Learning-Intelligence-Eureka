import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "commodities-heating-oil-prices",
  templateUrl: "heating-oil-prices.component.html"
})
export class HeatingOilPricesComponent implements OnInit {

  heatingOilPrices: TimeSeries[];
  heatingOilPricesLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService
    ) {
   }

  ngOnInit() {
    this.getHeatingOilPrices();
  }

  getHeatingOilPrices() {
    this.heatingOilPricesLoading = true;
    this.http.get<TimeSeries[]>(this.baseUrl + `Commodities/timeSeries?symbol=DHOILNYH`).subscribe(result => {
      this.heatingOilPrices = result;
      this.heatingOilPricesLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      console.log(err);
      this.heatingOilPricesLoading = false;
    });
  }
}

interface TimeSeries {
  dataId: string;
  date: string;
  frequency: string;
  value: number;
  id: string;
  key: string;
  subkey: string;
  updated: string | Date;
}
