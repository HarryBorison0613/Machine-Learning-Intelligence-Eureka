import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { List } from "../../../domain/marketinfo";

@Component({
  selector: "stocks-equities-list",
  templateUrl: "list.component.html",
  styleUrls: ['../subpage.css'],
})
export class ListComponent implements OnInit {
  symbols: any[];

  selectedListType: string;

  selectedDisplayPercentOption: boolean;

  selectedListLimit: number;

  listTypes: any[];
  
  lists: List[];

  listsLoading: boolean = true;
  
  filteredSymbols: any[];

  constructor( private stockService: StockService) {
    this.selectedListType = 'MostActive';
    this.selectedDisplayPercentOption = true;
    this.selectedListLimit = 10000;
   }

  ngOnInit() {
    this.getLists(this.selectedListType, this.selectedDisplayPercentOption, this.selectedListLimit);
    this.getExistingSymbols();

    this.listTypes = [
      {label: 'Type', value: 'MostActive'},
      {label: 'MostActive', value: 'MostActive'},
      {label: 'Gainers', value: 'Gainers'},
      {label: 'Losers', value: 'Losers'},
      {label: 'IexVolume', value: 'IexVolume'},
      {label: 'IexPercent', value: 'IexPercent'},
    ]
  }

  getLists(type, percent, limit) {
    this.listsLoading = true;
    this.stockService.getLists(type, percent, limit).then(collections => {
      this.lists = collections;
      this.lists.forEach(item => {
        item.openTime = new Date(item.openTime);
        item.closeTime = new Date(item.closeTime);
        item.highTime = new Date(item.highTime);
        item.lowTime = new Date(item.lowTime);
        item.latestTime = new Date(item.latestTime);
        item.latestUpdate = new Date(item.latestUpdate);
        item.delayedPriceTime = new Date(item.delayedPriceTime);
        item.oddLotDelayedPriceTime = new Date(item.oddLotDelayedPriceTime);
        item.extendedPriceTime = new Date(item.extendedPriceTime);
        item.iexOpenTime = new Date(item.iexOpenTime);
        item.iexCloseTime = new Date(item.iexCloseTime);
        item.lastTradeTime = new Date(item.lastTradeTime);
        item.changePercent = Math.round((item.changePercent + Number.EPSILON) * 10000) / 100;
      })
      this.listsLoading = false;
    }).catch(() => {
      this.listsLoading = false;
      this.lists = [];
    });
  }

  getExistingSymbols(): void {
    this.stockService.getExistingSymbols().then(collections => {
      this.symbols = collections.map(item => item.symbol).sort();
    })
  }

  filterSymbol(event) {
    let filtered: any[] = [];
    let query = event.query;
    for (let i = 0; i < this.symbols.length; i++) {
      let symbol = this.symbols[i];
      if (symbol.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(symbol);
      }
    }
    this.filteredSymbols = filtered;
  }

  clear(table: Table) {
      table.clear();
  }
}

