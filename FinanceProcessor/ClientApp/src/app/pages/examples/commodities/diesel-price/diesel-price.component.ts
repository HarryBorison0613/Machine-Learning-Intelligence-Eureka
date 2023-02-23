import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "commodities-diesel-price",
  templateUrl: "diesel-price.component.html"
})
export class DieselPriceComponent implements OnInit {

  dieselPrice: TimeSeries[];
  dieselPriceLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService
    ) {
   }

  ngOnInit() {
    this.getDieselPrice();
  }

  getDieselPrice() {
    this.dieselPriceLoading = true;
    this.http.get<TimeSeries[]>(this.baseUrl + `Commodities/timeSeries?symbol=GASDESW`).subscribe(result => {
      this.dieselPrice = result;
      this.dieselPriceLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.dieselPriceLoading = false;
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
