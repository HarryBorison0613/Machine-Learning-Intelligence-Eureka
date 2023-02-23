import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { InsiderRoster } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-insider-roster",
  templateUrl: "insider-roster.component.html",
  styleUrls: ['../subpage.css'],
})
export class InsiderRosterComponent implements OnInit {
  symbols: any[];
  selectedSymbol: string;
  insiderRosters: InsiderRoster[];
  insiderRostersLoading: boolean = true;
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getInsiderRosters(this.selectedSymbol);
    this.getExistingSymbols();
  }

  getInsiderRosters(query) {
    this.insiderRostersLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getInsiderRosters(symbol).then(collections => {
      this.insiderRosters = collections;
      this.insiderRosters.forEach(item => {
        item.symbol = symbol;
      });
      this.insiderRostersLoading = false;
    }).catch(() => {
      this.insiderRostersLoading = false;
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
