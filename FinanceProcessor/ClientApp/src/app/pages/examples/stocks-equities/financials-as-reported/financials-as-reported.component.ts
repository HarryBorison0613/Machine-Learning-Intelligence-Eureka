import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { ReportedFinancials } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-financials-as-reported",
  templateUrl: "financials-as-reported.component.html",
  styleUrls: ['../subpage.css'],
})

export class FinancialsAsReportedComponent implements OnInit {
  symbols: any[];
  selectedSymbol: string;
  periods: any[];
  selectedReportedFinancialsPeriod: string;
  reportedFinancials: ReportedFinancials[];
  reportedFinancialsLoading: boolean = true;
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
    this.selectedReportedFinancialsPeriod = 'Annual';
   }

  ngOnInit() {
    this.getReportedFinancials(this.selectedSymbol, this.selectedReportedFinancialsPeriod);
    this.getExistingSymbols();

    this.periods = [
      { label: 'Period', value: 'Annual' }, 
      { label: 'Annual', value: 'Annual' }, 
      { label: 'Quarter', value: 'Quarter' }
    ];
  }

  getReportedFinancials(query, period) {
    this.reportedFinancialsLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getReportedFinancials(symbol, period).then(collections => {
      this.reportedFinancials = collections;
      this.reportedFinancialsLoading = false;
    }).catch(() => {
      this.reportedFinancialsLoading = false;
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
