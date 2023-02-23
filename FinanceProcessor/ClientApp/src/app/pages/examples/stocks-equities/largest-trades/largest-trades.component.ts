import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { LargestTrade } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-largest-trades",
  templateUrl: "largest-trades.component.html",
  styleUrls: ['../subpage.css'],
})
export class LargestTradesComponent implements OnInit {
  symbols: any[];

  selectedSymbol: string;
  
  largestTrades: LargestTrade[];

  largestTradesLoading: boolean = true;
  
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getLargestTrades(this.selectedSymbol);
    this.getExistingSymbols();
  }

  getLargestTrades(query) {
    this.largestTradesLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getLargestTrades(symbol).then(collections => {
      this.largestTrades = collections;
      this.largestTradesLoading = false;
    }).catch(() => {
      this.largestTradesLoading = false;
      this.largestTrades = [];
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
