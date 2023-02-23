import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "economic-data-industrial-production-index",
  templateUrl: "industrial-production-index.component.html"
})
export class IndustrialProductionIndexComponent implements OnInit {

  industrialProductionIndex: Price[];
  industrialProductionIndexLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService 
  ) { }

  ngOnInit() {
    this.getIndustrialProductionIndex();
  }

  getIndustrialProductionIndex() {
    this.industrialProductionIndexLoading = true;
    this.industrialProductionIndex = [];
    this.http.get<number>(
      this.baseUrl + `EconomicData/dataPoints?symbol=INDPRO`
    ).subscribe(result => {
      this.industrialProductionIndex.push({price: result});
      this.industrialProductionIndexLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.industrialProductionIndexLoading = false;
    });
  }
}

interface Price {
  price: number;
}
