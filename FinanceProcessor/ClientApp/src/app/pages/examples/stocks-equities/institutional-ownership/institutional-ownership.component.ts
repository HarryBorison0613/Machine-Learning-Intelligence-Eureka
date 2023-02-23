import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { InstitutionalOwnership } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-institutional-ownership",
  templateUrl: "institutional-ownership.component.html",
  styleUrls: ['../subpage.css'],
})
export class InstitutionalOwnershipComponent implements OnInit {
  symbols: any[];

  selectedSymbol: string;
  
  institutionalOwnership: InstitutionalOwnership[];

  institutionalOwnershipLoading: boolean = true;
  
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getInstitutionalOwnership(this.selectedSymbol);
    this.getExistingSymbols();
  }

  getInstitutionalOwnership(query) {
    this.institutionalOwnershipLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getInstitutionalOwnership(symbol).then(collections => {
      this.institutionalOwnership = collections;
      this.institutionalOwnershipLoading = false;
    }).catch(() => {
      this.institutionalOwnershipLoading = false;
      this.institutionalOwnership = [];
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