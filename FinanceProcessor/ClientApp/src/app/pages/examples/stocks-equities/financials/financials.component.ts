import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { Financials } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-financials",
  templateUrl: "financials.component.html",
  styleUrls: ['../subpage.css'],
})
export class FinancialsComponent implements OnInit {

  financials: Financials[];
  selectedSymbol: string;
  selectedFinancialsLast: number;
  financialsLoading: boolean = true;
  symbols: any[];
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
    this.selectedFinancialsLast = 100;
   }

  ngOnInit() {
    this.getFinancials( this.selectedSymbol, this.selectedFinancialsLast);
    this.getExistingSymbols();
  }

  getFinancials(query, last) {
    this.financialsLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getFinancials(symbol, last).then(financials => {
      this.financials = financials;
      this.financials.forEach(item => {
        item.fiscalDate = new Date(item.fiscalDate);
      })
      this.financialsLoading = false;
    }).catch(() => {
      this.financialsLoading = false;
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
