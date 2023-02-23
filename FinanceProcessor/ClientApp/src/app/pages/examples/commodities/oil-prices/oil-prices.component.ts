import { Component, OnInit, Inject } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "commodities-oil-prices",
  templateUrl: "oil-prices.component.html"
})
export class OilPricesComponent implements OnInit {

  oilPrices: TimeSeries[];
  oilPricesLoading: boolean = false;

  constructor( private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, public toastr: ToastrService ) { }

  ngOnInit() {
    this.getOilPrices();
  }

  getOilPrices() {
    this.oilPricesLoading = true;
    this.http.get<TimeSeries[]>(this.baseUrl + `Commodities/timeSeries?symbol=DCOILWTICO`).subscribe(result => {
      this.oilPrices = result;
      this.oilPricesLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.toastr.show(
          '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
          'Network connection failed. Please check network connection',
          {
            timeOut: 4000,
            closeButton: true,
            enableHtml: true,
            toastClass: "alert alert-danger alert-with-icon",
            positionClass: "toast-top-right"
          }
        );
      }
      this.oilPricesLoading = false;
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
