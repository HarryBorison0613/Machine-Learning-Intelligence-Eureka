import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { InsiderTransaction } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-insider-transactions",
  templateUrl: "insider-transactions.component.html",
  styleUrls: ['../subpage.css'],
})
export class InsiderTransactionsComponent implements OnInit {
  symbols: any[];
  selectedSymbol: string;
  insiderTransactions: InsiderTransaction[];
  insiderTransactionsLoading: boolean = true;
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getInsiderTransactions(this.selectedSymbol);
    this.getExistingSymbols();
  }

  getInsiderTransactions(query) {
    this.insiderTransactionsLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getInsiderTransactions(symbol).then(collections => {
      this.insiderTransactions = collections;
      this.insiderTransactionsLoading = false;
    }).catch(() => {
      this.insiderTransactionsLoading = false;
      this.insiderTransactions = [];
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
