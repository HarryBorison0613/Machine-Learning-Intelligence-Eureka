import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { Logo } from "src/app/pages/domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-logo",
  templateUrl: "logo.component.html",
  styleUrls: ['../subpage.css'],
})
export class LogoComponent implements OnInit {
  symbols: any[];

  selectedLogoSymbol: string;
  
  logos: Logo[];

  logosLoading: boolean = true;
  
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedLogoSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getLogo(this.selectedLogoSymbol);
    this.getExistingSymbols();
  }

  getLogo(symbol) {
    this.logosLoading = true;
    this.stockService.getLogo(symbol).then(collections => {
      this.logos = [];
      this.logos.push(collections);
      this.logosLoading = false;
    }).catch(() => {
      this.logos = [];
      this.logosLoading = false;
    });
  }

  getExistingSymbols(): void {
    this.stockService.getExistingSymbols().then(collections => {
      this.symbols = collections.map(item => item.symbol);
    })
  }

  filterSymbol(event) {
    let filtered: any[] = [];
    let query = event.query;
    for (let i = 0; i < this.symbols.length; i++) {
      let symbol = this.symbols[i];
      if (symbol.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(symbol );
      }
    }
    this.filteredSymbols = filtered;
  }

  clear(table: Table) {
      table.clear();
  }
}
