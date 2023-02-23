import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "economic-data-us-recession-probabilities",
  templateUrl: "us-recession-probabilities.component.html"
})
export class USRecessionProbabilitiesComponent implements OnInit {

  usRecessionProbabilities: Price[];
  usRecessionProbabilitiesLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService 
  ) { }

  ngOnInit() {
    this.getUsRecessionProbabilities();
  }

  getUsRecessionProbabilities() {
    this.usRecessionProbabilitiesLoading = true;
    this.usRecessionProbabilities = [];
    this.http.get<number>(
      this.baseUrl + `EconomicData/dataPoints?symbol=RECPROUSM156N`
    ).subscribe(result => {
      this.usRecessionProbabilities.push({price: result});
      this.usRecessionProbabilitiesLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.usRecessionProbabilitiesLoading = false;
    });
  }
}

interface Price {
  price: number;
}
