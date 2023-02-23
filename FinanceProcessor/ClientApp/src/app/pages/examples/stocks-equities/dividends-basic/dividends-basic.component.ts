import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { DividendsBasic } from "src/app/pages/domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-dividends-basic",
  templateUrl: "dividends-basic.component.html",
  styleUrls: ['../subpage.css'],
})
export class DividendsBasicComponent implements OnInit {

  dividendsBasics: DividendsBasic[];
  selectedSymbol: string;
  selectedDividendsBasicPeriod: string;
  dividendsBasicsLoading: boolean = true;
  rangesBasic: any[];
  symbols: any[];
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
    this.selectedDividendsBasicPeriod = 'OneYear';
   }

  ngOnInit() {
    this.getDividendsBasic( this.selectedSymbol, this.selectedDividendsBasicPeriod);
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

  getDividendsBasic(query, range) {
    this.dividendsBasicsLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getDividendsBasic(symbol, range).then(collections => {
      this.dividendsBasics = collections;
      this.dividendsBasics.forEach(item => {
        item.exDate = new Date(item.exDate);
        item.recordDate = new Date(item.recordDate);
        item.paymentDate = new Date(item.paymentDate);
        item.declaredDate = new Date(item.declaredDate);
        item.date = new Date(item.date);
        item.updated = new Date(item.updated);
      })
      this.dividendsBasicsLoading = false;
    }).catch(() => {
      this.dividendsBasicsLoading = false;
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
