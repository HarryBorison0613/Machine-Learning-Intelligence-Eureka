import { Component, OnInit } from "@angular/core";
import { Table } from 'primeng/table';

import { StockService } from '../../../service/stockservice';
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-delayed-quote",
  templateUrl: "delayed-quote.component.html",
  styleUrls: ['../subpage.css'],
})
export class DelayedQuoteComponent implements OnInit {

  selectedSymbol: string;
  symbols: any[];
  dQuote: any[] = [];
  dQuoteloading: boolean = true;
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getDelayedQuote(this.selectedSymbol);
    this.getExistingSymbols();
   }

  getDelayedQuote(query) {
    this.dQuoteloading = true;
    let symbol = query.split('|')[1];
    this.dQuote = [];
    this.stockService.getDelayedQuote(symbol).then(result => {
      result.symbol = symbol;
      this.dQuote.push(result);
      this.dQuoteloading = false;
    }).catch(() => {
      this.dQuoteloading = false;
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
