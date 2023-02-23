import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "economic-data-consumer-price-index",
  templateUrl: "consumer-price-index.component.html"
})
export class ConsumerPriceComponent implements OnInit {

  consumerPrice: ConsumerIndex[];
  consumerPriceLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService 
  ) { }

  ngOnInit() {
    this.getConsumerPrice();
  }

  getConsumerPrice() {
    this.consumerPriceLoading = true;
    this.consumerPrice = [];
    this.http.get<number>(this.baseUrl + `EconomicData/dataPoints?symbol=CPIAUCSL`).subscribe(result => {
      this.consumerPrice.push({price: result});
      this.consumerPriceLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.consumerPriceLoading = false;
    });
  }
}

interface ConsumerIndex {
  price: number;
}
