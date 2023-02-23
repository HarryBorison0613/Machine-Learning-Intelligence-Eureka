import { Component, OnInit } from "@angular/core";
import { Table } from 'primeng/table';

import { StockService } from '../../../service/stockservice';
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-peer-groups",
  templateUrl: "peer-groups.component.html",
  styleUrls: ['../subpage.css'],
})
export class PeerGroupsComponent implements OnInit {

  selectedSymbol: string;
  peerGroups: string[];
  peerGroupsLoading: boolean = true;
  symbols: any[];
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getPeerGroups(this.selectedSymbol);
    this.getExistingSymbols();
   }

   getPeerGroups(query) {
    this.peerGroupsLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getPeerGroups(symbol).then(peerGroups => {
      this.peerGroups = peerGroups;
      this.peerGroupsLoading = false;
    }).catch(() => {
      this.peerGroupsLoading = false;
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
