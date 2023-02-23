import { Component, OnInit, Inject } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { HttpClient } from "@angular/common/http";

import { GlobalVariable } from "src/app/_services/global.variable";
import { ErrorService } from "src/app/pages/service/errorservice";
import { StockService } from "src/app/pages/service/stockservice";

@Component({
  selector: "reference-data-search",
  templateUrl: "search.component.html"
})
export class SearchComponent implements OnInit {

  symbols: any[];
  selectedSymbol: string;
  searchResult: Search[];
  searchLoading: boolean = false;
  filteredSymbols: any[];

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService , public toastr: ToastrService, 
    private globalVariable: GlobalVariable,
    private stockService: StockService 
    ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
  }

  ngOnInit() {
    this.getExistingSymbols();
    this.getSearch(this.selectedSymbol);
  }

  getSearch(query) {
    this.searchLoading = true;
    let symbol = query.split('|')[1];
    this.http.get<Search[]>(this.baseUrl + `References/getSearch?fragment=${symbol}`).subscribe(result => {
      this.searchResult = result;
      this.searchLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.searchLoading = false;
    });
  }

  getExistingSymbols(): void {
    this.stockService.getExistingSymbols().then(collections => {
      this.symbols = collections;
    });
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

  cancel() {
    this.selectedSymbol = '';
  }
}

interface Search {
  symbol: string;
  securityName: string;
  securityType: string;
  region: string;
  exchange: string;
}
