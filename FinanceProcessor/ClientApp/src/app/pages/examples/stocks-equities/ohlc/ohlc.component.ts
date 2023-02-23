import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-ohlc",
  templateUrl: "ohlc.component.html",
  styleUrls: ['../subpage.css'],
})
export class OHLCComponent implements OnInit {
  symbols: any[];

  selectedSymbol: string;
  
  openClosePrice: any[];

  openClosePriceLoading: boolean = true;
  
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getOpenClosePrice(this.selectedSymbol);
    this.getExistingSymbols();
  }

  getOpenClosePrice(query) {
    this.openClosePriceLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getOpenClosePrice(symbol).then(collections => {
      this.openClosePrice = [];
      this.openClosePrice.push(collections);
      this.openClosePrice.map(price => price.symbol = symbol);
      this.openClosePriceLoading = false;
    }).catch(() => {
      this.openClosePriceLoading = false;
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
