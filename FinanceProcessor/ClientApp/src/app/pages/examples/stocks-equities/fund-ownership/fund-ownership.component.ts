import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { FundOwnership } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-fund-ownership",
  templateUrl: "fund-ownership.component.html"
})
export class FundOwnershipComponent implements OnInit {
  symbols: any[];
  selectedSymbol: string;
  dividendsForecast: FundOwnership[];
  fundOwnershipLoading: boolean = true;
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getFundOwnership(this.selectedSymbol);
    this.getExistingSymbols();
  }

  getFundOwnership(query) {
    this.fundOwnershipLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getFundOwnership(symbol).then(collections => {
      this.dividendsForecast = collections;
      this.dividendsForecast.forEach(item => {
        item.report_date = new Date(item.report_date);
        item.date = new Date(item.date);
        item.updated = new Date(item.updated);
      })
      this.fundOwnershipLoading = false;
    }).catch(() => {
      this.fundOwnershipLoading = false;
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
