import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-relevant-stocks",
  templateUrl: "relevant-stocks.component.html",
  styleUrls: ['../subpage.css'],
})
export class RelevantStocksComponent implements OnInit {
  symbols: any[];

  selectedSymbol: string;
  
  relevantStocks: string[];

  relevantStocksLoading: boolean = true;
  
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getRelevantStocks(this.selectedSymbol);
    this.getExistingSymbols();
  }

  getRelevantStocks(query) {
    this.relevantStocksLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getRelevantStocks(symbol).then(collections => {
      this.relevantStocks = collections;
      this.relevantStocksLoading = false;
    }).catch(() => {
      this.relevantStocksLoading = false;
      this.relevantStocks = [];
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
