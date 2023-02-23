import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { GlobalVariable } from "src/app/_services/global.variable";
import { ErrorService } from "src/app/pages/service/errorservice";

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json-patch+json' })
};

@Component({
  selector: "cryptocurrency-cryptocurrency-events",
  templateUrl: "cryptocurrency-events.component.html"
})
export class CryptocurrencyEventsComponent implements OnInit {
  selectedCryptoEventsSymbol: string;

  symbols: any[];
  
  cryptoEvents: CryptoEvent[];

  cryptoEventsLoading: boolean = true;

  filteredSymbols: any[];

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService
  ) {
    this.selectedCryptoEventsSymbol = 'BTCUSD';
   }

  ngOnInit() {
    this.getCryptoEvents(this.selectedCryptoEventsSymbol);
    this.getExistingCryptoSymbols();
  }

  getCryptoEvents(symbol) {
    this.cryptoEventsLoading = true;
    const symbols: string[] = [];
    symbols.push(symbol);
    this.http.post<CryptoEvent[]>(this.baseUrl + `Crypto/cryptoCurrencyEventStream`, symbols, httpOptions)
    .subscribe(result => {
      result.map(item => item.symbol = symbol);
      this.cryptoEvents = result;
      this.cryptoEventsLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.cryptoEventsLoading = false;
    });
  }

  getExistingCryptoSymbols(): void {
    this.http.get<any>(this.baseUrl + `References/existingCryptoSymbols`).subscribe(result => {
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

interface CryptoEvent {
  symbol: string;
  eventType: string;
  timestamp: string | Date;
  reason: string;
  price: number;
  size: number;
  side: string;
}
