import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { VolumeByVenue } from "src/app/pages/domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-volume-by-venue",
  templateUrl: "volume-by-venue.component.html",
  styleUrls: ['../subpage.css'],
})
export class VolumeByVenueComponent implements OnInit {

  selectedSymbol: string;
  volumeByVenue: VolumeByVenue[];
  volumeByVenueLoading: boolean = true;
  symbols: any[];
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getVolumeByVenue(this.selectedSymbol);
    this.getExistingSymbols();
  }

  getVolumeByVenue(query) {
    this.volumeByVenueLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getVolumeByVenue(symbol).then(collections => {
      collections.map(item => {
        item.marketPercent = Math.round((item.marketPercent + Number.EPSILON)*10000)/100;
        item.avgMarketPercent = Math.round((item.avgMarketPercent + Number.EPSILON)*10000)/100;
      });
      this.volumeByVenue = collections;
      this.volumeByVenueLoading = false;
    }).catch(() => {
      this.volumeByVenueLoading = false;
      this.volumeByVenue = [];
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
