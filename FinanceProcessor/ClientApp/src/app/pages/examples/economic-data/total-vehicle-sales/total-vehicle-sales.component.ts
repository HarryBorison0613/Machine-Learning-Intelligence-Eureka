import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "economic-data-total-vehicle-sales",
  templateUrl: "total-vehicle-sales.component.html"
})
export class TotalVehicleSalesComponent implements OnInit {

  totalVehicleSales: Price[];
  totalVehicleSalesLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService 
  ) { }

  ngOnInit() {
    this.getTotalVehicleSales();
  }

  getTotalVehicleSales() {
    this.totalVehicleSalesLoading = true;
    this.totalVehicleSales = [];
    this.http.get<number>(
      this.baseUrl + `EconomicData/dataPoints?symbol=TOTALSA`
    ).subscribe(result => {
      this.totalVehicleSales.push({price: result});
      this.totalVehicleSalesLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.totalVehicleSalesLoading = false;
    });
  }
}

interface Price {
  price: number;
}
