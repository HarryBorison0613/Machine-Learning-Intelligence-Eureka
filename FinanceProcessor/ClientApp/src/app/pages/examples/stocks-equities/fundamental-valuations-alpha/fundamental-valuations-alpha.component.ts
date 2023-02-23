import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { FundamentalValuation } from "../../../domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-fundamental-valuations-alpha",
  templateUrl: "fundamental-valuations-alpha.component.html",
  styleUrls: ['../subpage.css'],
})
export class FundamentalValuationsAlphaComponent implements OnInit {
  symbols: any[];
  selectedSymbol: string;
  timeSeriesPeriods: any[];
  selectedFundamentalValuationsPeriod: string;
  fundamentalValuations: FundamentalValuation[];
  fundamentalValuationsLoading: boolean = true;
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
    this.selectedFundamentalValuationsPeriod = 'Annual';
   }

  ngOnInit() {
    this.getFundamentalValuations(this.selectedSymbol, this.selectedFundamentalValuationsPeriod);
    this.getExistingSymbols();

    this.timeSeriesPeriods = [
      {label: 'Period', value: 'Annual'},
      {label: 'Annual', value: 'Annual'},
      {label: 'Quarterly', value: 'Quarterly'},
      {label: 'Ttm', value: 'Ttm'},
    ];
  }

  getFundamentalValuations(query, period) {
    this.fundamentalValuationsLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getFundamentalValuations(symbol, period).then(collections => {
      this.fundamentalValuations = collections;
      this.fundamentalValuationsLoading = false;
    }).catch(() => {
      this.fundamentalValuationsLoading = false;
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
