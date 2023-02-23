import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-quote",
  templateUrl: "quote.component.html",
  styleUrls: ['../subpage.css'],
})
export class QuoteComponent implements OnInit {

  symbols: any[];

  selectedSymbol: string;

  quotes: any[];

  statuses: any[];

  quotesLoading: boolean = true;
  
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getQuote(this.selectedSymbol);
    this.getExistingSymbols();

    this.statuses = [
        {label: 'close', value: 'close'},
        {label: 'previousclose', value: 'previousclose'},
    ];
  }

  getQuote(query) {
    this.quotesLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getQuote(symbol).then(collection => {
      this.quotes = [];
      this.quotes.push(collection);
      this.quotesLoading = false;
    }).catch(() => {
      this.quotesLoading = false;
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
