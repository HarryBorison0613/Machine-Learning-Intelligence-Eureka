import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-cash-flow",
  templateUrl: "cash-flow.component.html",
  styleUrls: ['../subpage.css'],
})
export class CashFlowComponent implements OnInit {
  selectedSymbol: string;
  symbols: any[];
  selectedPeriod: string;
  periods: any[];
  cashflows: any[] = [];
  loading: boolean = true;
  summary: any[];
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
    this.selectedPeriod = 'Annual';
   }

  ngOnInit() {
    this.getCashflow(this.selectedSymbol, this.selectedPeriod);
    this.getExistingSymbols();

    this.periods = [
      'Annual',
      'Quarter',
    ];
  }

  getCashflow(query, period) {
    this.loading = true;
    this.summary = [];
    let symbol = query.split('|')[1];
    this.stockService.getCashflow(symbol, period).then(res => {
      let temp = {...res};
      delete temp.cashflow;
      this.summary.push(temp);
      this.cashflows = res.cashflow;

      this.cashflows.forEach(cashflow => {
        cashflow.reportDate = new Date(cashflow.reportDate);
        cashflow.fiscalDate = new Date(cashflow.fiscalDate);
        cashflow.updated = new Date(cashflow.updated);
      });
      this.loading = false;
    }).catch(() => {
      this.loading = false;
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

