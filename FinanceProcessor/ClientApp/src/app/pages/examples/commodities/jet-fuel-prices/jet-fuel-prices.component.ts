import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "commodities-jet-fuel-prices",
  templateUrl: "jet-fuel-prices.component.html"
})
export class JetFuelPricesComponent implements OnInit {

  jetFuelPrices: TimeSeries[];
  jetFuelPricesLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService
  ) {
   }

  ngOnInit() {
    this.getJetFuelPrices();
  }

  getJetFuelPrices() {
    this.jetFuelPricesLoading = true;
    this.http.get<TimeSeries[]>(this.baseUrl + `Commodities/timeSeries?symbol=DJFUELUSGULF`).subscribe(result => {
      this.jetFuelPrices = result;
      this.jetFuelPricesLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.jetFuelPricesLoading = false;
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

