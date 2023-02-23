import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "economic-data-initial-claims",
  templateUrl: "initial-claims.component.html"
})
export class InitialClaimsComponent implements OnInit {

  initialClaims: InitialClaim[];
  initialClaimsLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService 
  ) { }

  ngOnInit() {
    this.getInitialClaims();
  }

  getInitialClaims() {
    this.initialClaimsLoading = true;
    this.initialClaims = [];
    this.http.get<number>(
      this.baseUrl + `EconomicData/dataPoints?symbol=IC4WSA`
    ).subscribe(result => {
      this.initialClaims.push({price: result});
      this.initialClaimsLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.initialClaimsLoading = false;
    });
  }
}

interface InitialClaim {
  price: number;
}
