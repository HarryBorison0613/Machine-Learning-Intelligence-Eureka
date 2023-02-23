import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";
import { GlobalVariable } from "src/app/_services/global.variable";
import { StockService } from "src/app/pages/service/stockservice";

@Component({
  selector: "options-end-of-day-options",
  templateUrl: "end-of-day-options.component.html"
})
export class EndOfDayOptionsComponent implements OnInit {

  selectedSymbol: string;
  symbols: string[];
  filteredSymbols: string[];
  eodOptions: string[];
  eodOptionsLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService,
    private globalVariable: GlobalVariable, 
    private stockService: StockService,
  ) { }

  ngOnInit() {
    this.getEodOptions(this.globalVariable.getGlobalSearchSymbolName());
  }

  getEodOptions(symbol) {
    this.eodOptionsLoading = true;
    this.http.get<string[]>(
      this.baseUrl + `Options/options?symbol=${symbol}`
    ).subscribe(result => {
      this.eodOptions = result;
      this.eodOptionsLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.eodOptionsLoading = false;
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
}
