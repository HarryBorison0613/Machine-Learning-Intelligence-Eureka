import { Component, OnInit, Inject } from "@angular/core";
import { Table } from "primeng/table";

import { HttpClient } from "@angular/common/http";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "forex-currencies-currency-conversion",
  templateUrl: "currency-conversion.component.html",
  styleUrls: ['./currency-conversion.css'],
})
export class CurrencyConversionComponent implements OnInit {
  selectedCurrencyConversionSymbol: string;

  symbols: any[];
  
  currencyConversion: CurrencyConversion[];

  selectedCurrencyConversionAmount: number;

  currencyConversionLoading: boolean = true;

  filteredSymbols: any[];

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService
  ) {
    this.selectedCurrencyConversionSymbol = 'USDCAD';
    this.selectedCurrencyConversionAmount = 100;
   }

  ngOnInit() {
    this.getCurrencyConversion(this.selectedCurrencyConversionSymbol, this.selectedCurrencyConversionAmount);
    this.getExistingSymbols();
  }

  getCurrencyConversion(symbol, amount) {
    this.currencyConversionLoading = true;
    this.http.get<CurrencyConversion[]>(this.baseUrl + `ForexCurrencies/convert?forexSymbols=${symbol}&amount=${amount}`)
    .subscribe(result => {
      this.currencyConversion = result;
      this.currencyConversionLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.currencyConversionLoading = false;
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

interface CurrencyConversion {
  amount: number;
  symbol: string;
  rate: number;
  timestamp: string | Date;
  isDerived: boolean;
}
