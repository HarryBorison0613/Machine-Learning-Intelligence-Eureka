import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Table } from "primeng/table";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "cryptocurrency-cryptocurrency-quote",
  templateUrl: "cryptocurrency-quote.component.html"
})
export class CryptocurrencyQuoteComponent implements OnInit {
  selectedCryptoQuote: string;

  symbols: any[];
  
  cryptoQuote: CryptoQuote[];

  cryptoQuoteLoading: boolean = true;

  filteredSymbols: any[];

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService
  ) {
    this.selectedCryptoQuote = 'BTCUSD';
   }

  ngOnInit() {
    this.getCryptoQuote(this.selectedCryptoQuote);
    this.getExistingCryptoSymbols();
  }

  getCryptoQuote(symbol: string) {
    this.cryptoQuoteLoading = true;
    this.cryptoQuote = [];
    this.http.get<CryptoQuote>(this.baseUrl + `Crypto/cryptoCurrencyQuote?symbol=${symbol}`)
    .subscribe(result => {
      this.cryptoQuote.push(result);
      this.cryptoQuoteLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.cryptoQuoteLoading = false;
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

interface CryptoQuote {
  symbol: string;
  primaryExchange: string;
  sector: string;
  calculationPrice: string;
  latestPrice: number;
  ltestSource: string;
  latestUpdate: number;
  latestVolume: number;
  bidPrice: number;
  bidSize: number;
  askPrice: number;
  askSize: number;
  high: number;
  low: number;
  previousClose: number;
}
