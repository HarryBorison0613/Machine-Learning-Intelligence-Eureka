import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { httpOptions } from "src/app/_services/auth.service";

import { GlobalVariable } from "src/app/_services/global.variable";
import { ErrorService } from "src/app/pages/service/errorservice";
import { StockService } from "src/app/pages/service/stockservice";

@Component({
  selector: "investors-exchange-data-deep-auction",
  templateUrl: "deep-auction.component.html"
})
export class DEEPAuctionComponent implements OnInit {

  data: Auction[];
  loading: boolean = false;
  symbols: any[];
  selectedSymbol: string;
  filteredSymbols: any[];

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService, 
    private globalVariable: GlobalVariable,
    private stockService: StockService 
    ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
  }

  ngOnInit() {
    this.getExistingSymbols();
    this.getDeepAuction(this.selectedSymbol);
  }

  getDeepAuction(query) {
    this.loading = true;
    this.data = [];
    let symbol = query.split('|')[1];
    this.http.post<any>(
      this.baseUrl + `InvestorsExchangeData/deepAuction?symbols=${symbol}`, httpOptions)
    .subscribe(result => {
      if(result[symbol] !== undefined) {
        this.data.push(result[symbol]);
      }
      this.loading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.loading = false;
    });
  }

  getExistingSymbols(): void {
    this.stockService.getExistingSymbols().then(collections => {
      this.symbols = collections;
    });
  }

  filterSymbol(event) {
    let filtered: any[] = [];
    let query = event.query;
    for (let i = 0; i < this.symbols.length; i++) {
      let symbol = this.symbols[i];
      if (symbol.symbol.toLowerCase().indexOf(query.toLowerCase()) == 0 || symbol.name.toLowerCase().indexOf(query.toLowerCase()) > -1) {
        filtered.push(symbol.name + '|' + symbol.symbol);
      }
    }
    this.filteredSymbols = filtered;
  }

  cancel() {
    this.selectedSymbol = '';
  }
}

interface Auction {
  auctionType: string;
  pairedShares: number;
  imbalanceShares: number;
  referencePrice: number;
  indicativePrice: number;
  auctionBookPrice: number;
  collarReferencePrice: number;
  lowerCollarPrice: number;
  upperCollarPrice: number;
  extensionNumber: number;
  startTime: string | Date;
  lastUpdate: string | Date;
}
