import { Component, OnInit } from "@angular/core";
import { Table } from 'primeng/table';

import { StockService } from '../../../service/stockservice';
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-ceo-compensation",
  templateUrl: "ceo-compensation.component.html",
  styleUrls: ['../subpage.css'],
})
export class CeoCompensationComponent implements OnInit {

  selectedSymbol: string;
  symbols: any[];
  ceo: any[] = [];
  ceoloading: boolean = true;
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getCeoCompensation(this.selectedSymbol);
    this.getExistingSymbols();
   }

  getCeoCompensation(query) {
    this.ceoloading = true;
    this.ceo = [];
    let symbol = query.split('|')[1];
    this.stockService.getCeoCompensation(symbol).then(ceo => {
      this.ceo.push(ceo);
      this.ceoloading = false;
    }).catch(() => {
      this.ceoloading = false;
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
