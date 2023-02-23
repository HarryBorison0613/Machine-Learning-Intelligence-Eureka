import { Component, OnInit, Inject } from "@angular/core";
import { Table } from "primeng/table";

import { HttpClient } from "@angular/common/http";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "forex-currencies-latest-currency-rates",
  templateUrl: "latest-currency-rates.component.html"
})
export class LatestCurrencyRatesComponent implements OnInit {
  selectedLatestCurrencyRatesSymbol: string;

  symbols: any[];
  
  latestCurrencyRates: LatestCurrencyRate[];

  latestCurrencyRatesLoading: boolean = true;

  filteredSymbols: any[];

  constructor( 
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService
  ) {
    this.selectedLatestCurrencyRatesSymbol = 'USDCAD'
   }

  ngOnInit() {
    this.getLatestCurrencyRates(this.selectedLatestCurrencyRatesSymbol);
    this.getExistingSymbols();
  }

  getLatestCurrencyRates(symbol) {
    this.latestCurrencyRatesLoading = true;
    this.http.get<LatestCurrencyRate[]>(this.baseUrl + `ForexCurrencies/latestRates?forexSymbols=${symbol}`)
    .subscribe(result => {
      this.latestCurrencyRates = result;
      this.latestCurrencyRatesLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.latestCurrencyRatesLoading = false;
    });
  }

  getExistingSymbols(): void {
    this.http.get<any>(this.baseUrl + `References/existingForexPairsSymbol`).subscribe(result => {
      this.symbols = result.map(item => item.symbol);
    }, (err) => {
      console.log(err);
    });
  }

  filterSymbol(event) {
    let filtered: any[] = [];
    let query = event.query;
    for (let i = 0; i < this.symbols.length; i++) {
      let symbol = this.symbols[i];
      if (symbol.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(symbol);
      }
    }
    this.filteredSymbols = filtered;
  }

  clear(table: Table) {
      table.clear();
  }
}

interface LatestCurrencyRate {
  symbol: string;
  rate: number;
  timestamp: string | Date;
  isDerived: boolean
}
