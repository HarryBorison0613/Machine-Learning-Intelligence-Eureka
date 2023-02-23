import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Table } from 'primeng/table';

import { StockService } from 'src/app/pages/service/stockservice';
import { GlobalVariable } from "src/app/_services/global.variable";
import { ErrorService } from "src/app/pages/service/errorservice";

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Component({
  selector: "investors-exchange-data-deep-book",
  templateUrl: "deep-book.component.html"
})
export class DEEPBookComponent implements OnInit {
  selectedSymbol: string;
  asks: any[];
  asksloading: boolean = true;
  bids: any[];
  bidsloading: boolean = true;
  symbols: any[];
  filteredSymbols: any[];

  constructor( 
    private stockService: StockService, 
    private globalVariable: GlobalVariable,
    private http: HttpClient, 
    private errors: ErrorService,
    @Inject('BASE_URL') private baseUrl: string,
  ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
  }

  ngOnInit() {
    this.getStockBooks(this.selectedSymbol);
    this.getExistingSymbols();
  }
  getStockBooks(query) {
    this.asksloading = true;
    this.bidsloading = true;
    let symbol = query.split('|')[1];
    this.http.post<any>(
      this.baseUrl + `InvestorsExchangeData/deepBook?symbols=${symbol}`, httpOptions)
      .subscribe(result => {
      this.asks = result[symbol].asks;
      this.bids = result[symbol].bids;
      this.asksloading = false;
      this.bidsloading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.asksloading = false;
      this.bidsloading = false;
    })
  }

  getExistingSymbols(): void {
    this.stockService.getExistingSymbols().then(collections => {
      this.symbols = collections;
    })
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

  clear(table: Table) {
    table.clear();
  }

  cancel() {
    this.selectedSymbol = '';
  }
}
