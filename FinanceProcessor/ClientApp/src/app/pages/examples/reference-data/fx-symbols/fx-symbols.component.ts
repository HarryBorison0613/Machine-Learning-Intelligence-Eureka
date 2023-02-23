import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "reference-data-fx-symbols",
  templateUrl: "fx-symbols.component.html"
})
export class FXSymbolsComponent implements OnInit {

  forexPairsSymbols: ForexSymbol[];
  forexPairsSymbolsLoading: boolean = false;

  forexCurrencies: ForexCurrency[];
  selectedExchange: string;
  forexCurrenciesLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    private errors: ErrorService, 
    @Inject('BASE_URL') private baseUrl: string, 
    ) { }

  ngOnInit() {
    this.getForexPairsSymbols();
    this.getforexCurrencies();
  }

  getForexPairsSymbols() {
    this.forexPairsSymbolsLoading = true;
    this.http.get<ForexSymbol[]>(this.baseUrl + `References/existingForexPairsSymbol`).subscribe(res => {
      this.forexPairsSymbols = res;
      this.forexPairsSymbolsLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.forexPairsSymbolsLoading = false;
    });
  }

  getforexCurrencies() {
    this.forexCurrenciesLoading = true;
    this.http.get<ForexCurrency[]>(this.baseUrl + `References/existingForexCurrencies`).subscribe(res => {
      this.forexCurrencies = res;
      this.forexCurrenciesLoading = false;
    }, (err) => {
      this.forexCurrenciesLoading = false;
    });
  }
}

interface ForexSymbol {
  symbol: string;
  fromCurrency: string;
  toCurrency: string;
  name: string;
  isCrypto: boolean;
}

interface ForexCurrency {
  code: string;
  name: string;
  isCrypto: number;
}
