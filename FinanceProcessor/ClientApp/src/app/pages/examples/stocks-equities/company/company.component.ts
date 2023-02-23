import { Component, OnInit } from "@angular/core";
import { Table } from 'primeng/table';

import { StockService } from '../../../service/stockservice';
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-company",
  templateUrl: "company.component.html",
  styleUrls: ['../subpage.css'],
})
export class CompanyComponent implements OnInit {

  selectedSymbol: string;
  companySummary: any[];
  companyTags: any[];
  companyDescription: string;
  companyLoading: boolean = true;
  symbols: any[];
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getCompany(this.selectedSymbol);
    this.getExistingSymbols();
   }

   getCompany(query) {
    this.companyLoading = true;
    this.companySummary = [];
    let symbol = query.split('|')[1];
    this.stockService.getCompany(symbol).then(company => {
      let temp = {...company};
      delete temp.tags;
      this.companySummary.push({...company});
      this.companyDescription = company.description;
      this.companyTags = [...company.tags].map(item => {
        return {tag: item};
      });
      this.companyLoading = false;
    }).catch(() => {
      this.companyLoading = false;
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
