import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { AdvancedFundamentals } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-fundamentals",
  templateUrl: "fundamentals.component.html",
  styleUrls: ['../subpage.css'],
})

export class FundamentalsComponent implements OnInit {
  symbols: any[];
  selectedSymbol: string;
  timeSeriesPeriods: any[];
  selectedFundamentalsPeriod: string;
  fundamentals: AdvancedFundamentals[];
  fundamentalsLoading: boolean = true;
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
    this.selectedFundamentalsPeriod = 'Annual';
   }

  ngOnInit() {
    this.getFundamentals(this.selectedSymbol, this.selectedFundamentalsPeriod);
    this.getExistingSymbols();

    this.timeSeriesPeriods = [
      'Annual',
      'Quarterly',
      'Ttm',
    ];
  }

  getFundamentals(query, period) {
    this.fundamentalsLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getFundamentals(symbol, period).then(collections => {
      this.fundamentals = collections;
      this.fundamentals.forEach(item => {
        item.date = new Date(item.date);
        item.updated = new Date(item.updated);
      })
      this.fundamentalsLoading = false;
    }).catch(() => {
      this.fundamentalsLoading = false;
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
