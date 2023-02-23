import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { SplitsBasic } from "src/app/pages/domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-splits-basic",
  templateUrl: "splits-basic.component.html",
  styleUrls: ['../subpage.css'],
})
export class SplitsBasicComponent implements OnInit {

  splitsBasics: SplitsBasic[];
  selectedSymbol: string;
  selectedSplitsBasicRange: string;
  splitsBasicLoading: boolean = true;
  rangesBasic: any[];
  symbols: any[];
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
    this.selectedSplitsBasicRange = 'OneYear';
   }

  ngOnInit() {
    this.getSplitsBasic( this.selectedSymbol, this.selectedSplitsBasicRange);
    this.getExistingSymbols();
    
    this.rangesBasic = [
      { label: 'Range', value: 'Ytd' }, 
      { label: 'Next', value: 'Next' }, 
      { label: 'Ytd', value: 'Ytd' }, 
      { label: 'OneMonth', value: 'OneMonth' }, 
      { label: 'ThreeMonths', value: 'ThreeMonths' }, 
      { label: 'SixMonths', value: 'SixMonths' }, 
      { label: 'OneYear', value: 'OneYear' }, 
      { label: 'TwoYears', value: 'TwoYears' }, 
      { label: 'FiveYears', value: 'FiveYears' }
    ];
  }

  getSplitsBasic(query, range) {
    this.splitsBasicLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getSplitsBasic(symbol, range).then(collections => {
      this.splitsBasics = collections;
      this.splitsBasics.forEach(item => {
        item.exDate = new Date(item.exDate);
        item.declaredDate = new Date(item.declaredDate);
        item.date = new Date(item.date);
        item.updated = new Date(item.updated);
      })
      this.splitsBasicLoading = false;
    }).catch(() => {
      this.splitsBasicLoading = false;
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

