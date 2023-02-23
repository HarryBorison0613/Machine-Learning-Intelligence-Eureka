import { Component, OnInit } from "@angular/core";
import { Table } from 'primeng/table';

import { StockService } from '../../../service/stockservice';
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-book",
  templateUrl: "book.component.html",
  styleUrls: ['../subpage.css'],
})
export class BookComponent implements OnInit {

  selectedSymbol: string;
  summary: any[] = [];
  trades: any[];
  tradesloading: boolean = true;
  asks: any[];
  asksloading: boolean = true;
  bids: any[];
  bidsloading: boolean = true;
  symbols: any[];
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
  }

  ngOnInit() {
    this.getStockBooks(this.selectedSymbol);
    this.getExistingSymbols();
  }

  getStockBooks(query) {
    let symbol = query.split('|')[1];
    this.tradesloading = true;
    this.asksloading = true;
    this.bidsloading = true;
    this.summary = [];
    this.stockService.getStockBooks(symbol).then(book => {
      this.summary.push({ ...book.quote, ...book.systemEvent });
      this.summary.map(summary => {
        summary.iexCloseTime = new Date(summary.iexCloseTime);
      });
      this.trades = book.trades;
      this.asks = book.asks;
      this.tradesloading = false;
      this.asksloading = false;
      this.bidsloading = false;
    }).catch(() => {
      this.tradesloading = false;
      this.asksloading = false;
      this.bidsloading = false;
    });
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
