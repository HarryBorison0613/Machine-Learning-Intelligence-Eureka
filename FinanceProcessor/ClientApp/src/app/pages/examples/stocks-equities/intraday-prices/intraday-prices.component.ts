import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { IntradayPrice } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-intraday-prices",
  templateUrl: "intraday-prices.component.html",
  styleUrls: ['../subpage.css'],
})
export class IntradayPricesComponent implements OnInit {
  symbols: any[];

  selectedSymbol: string;
  
  intradayPrices: IntradayPrice[];

  intradayPricesLoading: boolean = true;
  
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getIntradayPrices(this.selectedSymbol);
    this.getExistingSymbols();
  }

  getIntradayPrices(query) {
    this.intradayPricesLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getIntradayPrices(symbol).then(collections => {
      collections.map(collection => collection.symbol = symbol);
      this.intradayPrices = collections;
      this.intradayPricesLoading = false;
    }).catch(() => {
      this.intradayPricesLoading = false;
      this.intradayPrices = [];
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
