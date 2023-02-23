import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { KeyStat } from "src/app/pages/domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-stats-basic",
  templateUrl: "stats-basic.component.html",
  styleUrls: ['../subpage.css'],
})
export class StatsBasicComponent implements OnInit {

  keyStats: KeyStat[];
  selectedSymbol: string;
  keyStatsLoading: boolean = true;
  symbols: any[];
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getKeyStats( this.selectedSymbol);
    this.getExistingSymbols();
  }

  getKeyStats(query) {
    this.keyStatsLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getKeyStats(symbol).then(collections => {
      this.keyStats = [];
      this.keyStats.push(collections);
      this.keyStats.forEach(item => {
        item.symbol = symbol;
      })
      this.keyStatsLoading = false;
    }).catch(() => {
      this.keyStats = [];
      this.keyStatsLoading = false;
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
