import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { IncomeStatement } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-income-statement",
  templateUrl: "income-statement.component.html",
  styleUrls: ['../subpage.css'],
})
export class IncomeStatementComponent implements OnInit {
  symbols: any[];
  periods: any[];
  selectedSymbol: string;
  selectedIncomeStatementPeriod: string;
  selectedIncomeStatementLast: number;
  incomeStatements: IncomeStatement[];
  incomeStatementsLoading: boolean = true;
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
    this.selectedIncomeStatementPeriod = 'Annual';
    this.selectedIncomeStatementLast = 10000;
   }

  ngOnInit() {
    this.getIncomeStatements(this.selectedSymbol, this.selectedIncomeStatementPeriod, this.selectedIncomeStatementLast);
    this.getExistingSymbols();

    this.periods = [
      { label: 'Period', value: 'Annual' }, 
      { label: 'Annual', value: 'Annual' }, 
      { label: 'Quarter', value: 'Quarter' }
    ];
  }

  getIncomeStatements(query, period, last) {
    this.incomeStatementsLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getIncomeStatements(symbol, period, last).then(collections => {
      this.incomeStatements = collections;
      this.incomeStatements.forEach(item => {
        item.symbol = symbol;
      })
      this.incomeStatementsLoading = false;
    }).catch(() => {
      this.incomeStatementsLoading = false;
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
