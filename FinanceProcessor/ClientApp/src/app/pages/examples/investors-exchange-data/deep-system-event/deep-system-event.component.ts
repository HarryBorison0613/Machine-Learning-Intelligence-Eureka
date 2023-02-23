import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { httpOptions } from "src/app/_services/auth.service";
import { GlobalVariable } from "src/app/_services/global.variable";
import { ErrorService } from "src/app/pages/service/errorservice";
import { StockService } from "src/app/pages/service/stockservice";
import { Table } from "primeng/table";

@Component({
  selector: "investors-exchange-data-deep-system-event",
  templateUrl: "deep-system-event.component.html"
})
export class DEEPSystemEventComponent implements OnInit {

  data: DeepSystemEvent[];
  loading: boolean = false;
  symbols: string[];
  selectedSymbol: string;
  filteredSymbols: any[];

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService, 
    private globalVariable: GlobalVariable,
    private stockService: StockService 
    ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
  }

  ngOnInit() {
    this.getExistingSymbols();
    this.getDeepSystemEvent();
  }

  getDeepSystemEvent() {
    this.loading = true;
    this.data = [];
    this.http.post<any>(
      this.baseUrl + `InvestorsExchangeData/deepSystemEvent`, httpOptions)
    .subscribe(result => {
      this.data.push(result);
      this.loading = false;
      }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.loading = false;
    });
  }

  getExistingSymbols(): void {
    this.stockService.getExistingSymbols().then(collections => {
      this.symbols = collections.map(item => item.symbol).sort();
    });
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

interface DeepSystemEvent {
  systemEvent: string;
  timestamp: string | Date;
}
