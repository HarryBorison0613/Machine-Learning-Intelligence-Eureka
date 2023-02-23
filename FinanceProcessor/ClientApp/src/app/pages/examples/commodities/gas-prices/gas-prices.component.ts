import { Component, OnInit, Inject } from "@angular/core";
import { ErrorService } from "src/app/pages/service/errorservice";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "commodities-gas-prices",
  templateUrl: "gas-prices.component.html"
})
export class GasPricesComponent implements OnInit {

  regGasPrice: TimeSeries[];
  regGasPriceLoading: boolean = false;
  midGasPrice: TimeSeries[];
  midGasPriceLoading: boolean = false;
  prmGasPrice: TimeSeries[];
  prmGasPriceLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService
    ) {
   }

  ngOnInit() {
    this.getRegGasPrice();
    this.getMidGasPrice();
    this.getPrmGasPrice();
  }

  getRegGasPrice() {
    this.midGasPriceLoading = true;
    this.http.get<TimeSeries[]>(this.baseUrl + `Commodities/timeSeries?symbol=GASREGCOVW`).subscribe(result => {
      this.regGasPrice = result;
      this.regGasPriceLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.regGasPriceLoading = false;
    });
  }

  getMidGasPrice() {
    this.midGasPriceLoading = true;
    this.http.get<TimeSeries[]>(this.baseUrl + `Commodities/timeSeries?symbol=GASMIDCOVW`).subscribe(result => {
      this.midGasPrice = result;
      this.midGasPriceLoading = false;
    }, (err) => {
      console.log(err);
      this.midGasPriceLoading = false;
    });
  }

  getPrmGasPrice() {
    this.midGasPriceLoading = true;
    this.http.get<TimeSeries[]>(this.baseUrl + `Commodities/timeSeries?symbol=GASPRMCOVW`).subscribe(result => {
      this.prmGasPrice = result;
      this.prmGasPriceLoading = false;
    }, (err) => {
      console.log(err);
      this.prmGasPriceLoading = false;
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
