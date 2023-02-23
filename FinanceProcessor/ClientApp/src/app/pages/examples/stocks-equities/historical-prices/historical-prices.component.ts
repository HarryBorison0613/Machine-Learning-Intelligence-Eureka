import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { HistoricalPrice } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-historical-prices",
  templateUrl: "historical-prices.component.html",
  styleUrls: ['../subpage.css'],
})
export class HistoricalPricesComponent implements OnInit {
  symbols: any[];
  chartRanges: any[];
  selectedSymbol: string;
  selectedHistoricalPriceRange: string;
  historicalPrices: HistoricalPrice[];
  historicalPricesLoading: boolean = true;
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
    this.selectedHistoricalPriceRange = 'Ytd';
   }

  ngOnInit() {
    this.getHistoricalPrices(this.selectedSymbol, this.selectedHistoricalPriceRange);
    this.getExistingSymbols();

    this.chartRanges = [
      {label: 'Range', value: 'Ytd'},
      {label: 'Dynamic', value: 'Dynamic'},
      {label: 'Date', value: 'Date'},
      {label: 'FiveDayMinute', value: 'FiveDayMinute'},
      {label: 'FiveDay', value: 'FiveDay'},
      {label: 'OneMonthMinute', value: 'OneMonthMinute'},
      {label: 'OneMonth', value: 'OneMonth'},
      {label: 'ThreeMonths', value: 'ThreeMonths'},
      {label: 'SixMonths', value: 'SixMonths'},
    ];
  }

  getHistoricalPrices(query, range) {
    this.historicalPricesLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getHistoricalPrices(symbol, range).then(collections => {
      this.historicalPrices = collections;
      this.historicalPrices.forEach(item => {
        item.symbol = symbol;
        item.date = new Date(item.date);
        item.updated = new Date(item.updated);
        item.changePercent = Math.round((item.changePercent + Number.EPSILON) * 10000) / 100;
      })
      this.historicalPricesLoading = false;
    }).catch(() => {
      this.historicalPricesLoading = false;
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

