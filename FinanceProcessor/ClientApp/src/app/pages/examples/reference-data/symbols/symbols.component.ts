import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "src/app/pages/service/stockservice";

@Component({
  selector: "reference-data-symbols",
  templateUrl: "symbols.component.html"
})
export class SymbolsComponent implements OnInit {

  symbols: any[];
  loading: boolean;

  constructor(private stockService: StockService) { }

  ngOnInit() {
    this.getExistingSymbols();
  }

  getExistingSymbols(): void {
    this.loading = true;
    this.stockService.getExistingSymbols().then(collections => {
      this.symbols = collections;
      this.loading = false;
    }).catch(() => {
      this.loading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
