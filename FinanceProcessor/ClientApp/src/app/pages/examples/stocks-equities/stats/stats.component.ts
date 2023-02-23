import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { AdvancedStat } from "src/app/pages/domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-stats",
  templateUrl: "stats.component.html",
  styleUrls: ['../subpage.css'],
})
export class StatsComponent implements OnInit {

  advancedStats: AdvancedStat[];
  selectedSymbol: string;
  advancedStatsLoading: boolean = true;
  symbols: any[];
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getAdvancedStats( this.selectedSymbol);
    this.getExistingSymbols();
  }

  getAdvancedStats(query) {
    this.advancedStatsLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getAdvancedStats(symbol).then(collections => {
      this.advancedStats = [];
      this.advancedStats.push(collections);
      this.advancedStats.forEach(item => {
        item.symbol = symbol;
      })
      this.advancedStatsLoading = false;
    }).catch(() => {
      this.advancedStats = [];
      this.advancedStatsLoading = false;
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
