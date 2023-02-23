import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Table } from "primeng/table";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "cryptocurrency-cryptocurrency-price",
  templateUrl: "cryptocurrency-price.component.html"
})
export class CryptocurrencyPriceComponent implements OnInit {
  selectedCryptoPrice: string;

  symbols: any[];
  
  cryptoPrice: CryptoPrice[];

  cryptoPriceLoading: boolean = true;

  filteredSymbols: any[];

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService
    ) {
    this.selectedCryptoPrice = 'BTCUSD';
   }

  ngOnInit() {
    this.getCryptoPrice(this.selectedCryptoPrice);
    this.getExistingCryptoSymbols();
  }

  getCryptoPrice(symbol: string) {
    this.cryptoPriceLoading = true;
    this.cryptoPrice = [];
    this.http.get<CryptoPrice>(this.baseUrl + `Crypto/cryptoCurrencyPrice?symbol=${symbol}`)
    .subscribe(result => {
      this.cryptoPrice.push(result);
      this.cryptoPriceLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.cryptoPriceLoading = false;
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

interface CryptoPrice {
  price: number;
  symbol: string;
}
