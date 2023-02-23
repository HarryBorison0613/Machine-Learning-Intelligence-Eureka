import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { BalanceSheet } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-balance-sheet",
  templateUrl: "balance-sheet.component.html",
  styleUrls: ['../subpage.css'],
})
export class BalanceSheetComponent implements OnInit {
  selectedSymbol: string;
  symbols: any[];
  selectedPeriod: string;
  periods: any[];
  balancesheets: BalanceSheet[];
  loading: boolean = true;
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
    this.selectedPeriod = 'Annual';
   }

  ngOnInit() {
    this.getBalanceSheets(this.selectedSymbol, this.selectedPeriod);
    this.getExistingSymbols();

    this.periods = [{ label: 'Period', value: 'Annual' }, { label: 'Annual', value: 'Annual' }, { label: 'Quarter', value: 'Quarter' }];
  }

  getBalanceSheets(query, period) {
    let symbol = query.split('|')[1];
    console.log(symbol);
    this.loading = true;
    this.stockService.getBalanceSheets(symbol, period).then(sheets => {
      this.balancesheets = sheets;
      this.balancesheets.forEach(sheet => {
        sheet.symbol = symbol;
        sheet.reportDate = new Date(sheet.reportDate);
        sheet.fiscalDate = new Date(sheet.fiscalDate);
        sheet.updated = new Date(sheet.updated);
      });
      this.loading = false;
    }).catch(() => {
      this.loading = false;
    });
  }

  onGlobalSearch(symbol) {
    this.getBalanceSheets(symbol, this.selectedPeriod);
  }

  getExistingSymbols(): void {
    this.stockService.getExistingSymbols().then(collections => {
      this.symbols = collections;
    });
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

  cancel($event) {
    this.selectedSymbol = '';
  }
}

