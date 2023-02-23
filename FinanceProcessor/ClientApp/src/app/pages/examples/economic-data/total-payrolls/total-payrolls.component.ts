import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "economic-data-total-payrolls",
  templateUrl: "total-payrolls.component.html"
})
export class TotalPayrollsComponent implements OnInit {

  totalPayrolls: Price[];
  totalPayrollsLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService 
  ) { }

  ngOnInit() {
    this.getTotalPayrolls();
  }

  getTotalPayrolls() {
    this.totalPayrollsLoading = true;
    this.totalPayrolls = [];
    this.http.get<number>(
      this.baseUrl + `EconomicData/dataPoints?symbol=PAYEMS`
    ).subscribe(result => {
      this.totalPayrolls.push({price: result});
      this.totalPayrollsLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.totalPayrollsLoading = false;
    });
  }
}

interface Price {
  price: number;
}
