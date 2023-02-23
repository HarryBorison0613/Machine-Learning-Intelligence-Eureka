import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { DividendsForecast } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-dividends-forecast-alpha",
  templateUrl: "dividends-forecast-alpha.component.html",
  styleUrls: ['../subpage.css'],
})
export class DividendsForecastAlphaComponent implements OnInit {
  symbols: any[];
  selectedSymbol: string;
  dividendsForecast: DividendsForecast[];
  dividendsForecastLoading: boolean = true;
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getDividendsForecast(this.selectedSymbol);
    this.getExistingSymbols();
  }

  getDividendsForecast(query) {
    this.dividendsForecastLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getDividendsForecast(symbol).then(collections => {
      this.dividendsForecast = collections;
      this.dividendsForecastLoading = false;
    }).catch(() => {
      this.dividendsForecastLoading = false;
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
