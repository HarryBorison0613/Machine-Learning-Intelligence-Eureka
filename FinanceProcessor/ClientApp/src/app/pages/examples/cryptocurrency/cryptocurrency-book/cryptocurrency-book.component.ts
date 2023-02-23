import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Table } from "primeng/table";
import { ErrorService } from "src/app/pages/service/errorservice";


@Component({
  selector: "cryptocurrency-cryptocurrency-book",
  templateUrl: "cryptocurrency-book.component.html",
})
export class CryptocurrencyBookComponent implements OnInit {
  selectedCryptoBookSymbol: string;

  symbols: any[];
  
  cryptoBookBids: CryptoBook[];

  cryptoBookAsks: CryptoBook[];

  cryptoBookLoading: boolean = true;

  filteredSymbols: any[];

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService
  ) {
    this.selectedCryptoBookSymbol = 'BTCUSD';
   }

  ngOnInit() {
    this.getCryptoBook(this.selectedCryptoBookSymbol);
    this.getExistingCryptoSymbols();
  }

  getCryptoBook(symbol) {
    this.cryptoBookLoading = true;
    this.http.get<any>(this.baseUrl + `Crypto/cryptoCurrencyBook?symbol=${symbol}`).subscribe(result => {
      this.cryptoBookBids = result.bids;
      this.cryptoBookAsks = result.asks;
      this.cryptoBookLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.cryptoBookLoading = false;
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

interface CryptoBook {
  price: number;
  size: number;
  timestamp: string | Date;
}
