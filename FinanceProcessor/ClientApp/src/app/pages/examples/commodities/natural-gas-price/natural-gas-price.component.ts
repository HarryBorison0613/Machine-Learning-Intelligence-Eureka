import { Component, OnInit, Inject } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "commodities-natural-gas-price",
  templateUrl: "natural-gas-price.component.html"
})
export class NaturalGasPriceComponent implements OnInit {

  naturalGasPrices: TimeSeries[];
  naturalGasPricesLoading: boolean = false;

  constructor( private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, public toastr: ToastrService ) {
   }

  ngOnInit() {
    this.getNaturalGasPrices();
  }

  getNaturalGasPrices() {
    this.naturalGasPricesLoading = true;
    this.http.get<TimeSeries[]>(this.baseUrl + `Commodities/timeSeries?symbol=DHHNGSP`).subscribe(result => {
      this.naturalGasPrices = result;
      this.naturalGasPricesLoading = false;
    }, (err) => {
      // if(err.status === 500) {
      //   this.toastr.show(
      //     '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
      //     'Network connection failed. Please check network connection',
      //     {
      //       timeOut: 4000,
      //       closeButton: true,
      //       enableHtml: true,
      //       toastClass: "alert alert-danger alert-with-icon",
      //       positionClass: "toast-top-right"
      //     }
      //   );
      // }
      console.log(err);
      this.naturalGasPricesLoading = false;
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
