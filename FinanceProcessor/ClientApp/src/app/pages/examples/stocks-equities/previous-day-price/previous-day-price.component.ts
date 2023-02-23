import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-previous-day-price",
  templateUrl: "previous-day-price.component.html",
  styleUrls: ['../subpage.css'],
})
export class PreviousDayPriceComponent implements OnInit {
  symbols: any[];

  selectedPreviousDayPriceSymbol: string;
  
  previousDayPrice: any[];

  previousDayPriceLoading: boolean = true;
  
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedPreviousDayPriceSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getPreviousDayPrice(this.selectedPreviousDayPriceSymbol);
    this.getExistingSymbols();
  }

  getPreviousDayPrice(symbol) {
    this.previousDayPriceLoading = true;
    this.stockService.getPreviousDayPrice(symbol).then(collections => {
      this.previousDayPrice = [];
      this.previousDayPrice.push(collections);
      this.previousDayPrice.map(price => price.symbol = symbol);
      this.previousDayPriceLoading = false;
    }).catch(() => {
      this.previousDayPriceLoading = false;
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
