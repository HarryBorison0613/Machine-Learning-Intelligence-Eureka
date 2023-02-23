import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "commodities-propane-prices",
  templateUrl: "propane-prices.component.html"
})
export class PropanePricesComponent implements OnInit {

  propanePrice: TimeSeries[];
  propanePriceLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService
  ) {
   }

  ngOnInit() {
    this.getPropanePrice();
  }

  getPropanePrice() {
    this.propanePriceLoading = true;
    this.http.get<TimeSeries[]>(this.baseUrl + `Commodities/timeSeries?symbol=DPROPANEMBTX`).subscribe(result => {
      this.propanePrice = result;
      this.propanePriceLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      console.log(err);
      this.propanePriceLoading = false;
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
