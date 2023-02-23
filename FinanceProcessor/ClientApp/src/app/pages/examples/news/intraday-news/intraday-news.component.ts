import { Component, OnInit, Inject } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { GlobalVariable } from "src/app/_services/global.variable";
import { HttpClient } from "@angular/common/http";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "news-intraday-news",
  templateUrl: "intraday-news.component.html",
  styleUrls: ['./intraday-news.css'],
})
export class IntradayNewsComponent implements OnInit {
  selectedSymbol: string;

  symbols: any[];
  
  selectedIntradayNewsLast: number;

  intradayNews: IntradayNews[];

  intradayNewsLoading: boolean = true;

  filteredSymbols: any[];

  constructor( 
    private http: HttpClient, 
    private stockService: StockService, 
    private globalVariable: GlobalVariable, 
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService
    ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
    this.selectedIntradayNewsLast = 100;
   }

  ngOnInit() {
    this.getIntradayNews(this.selectedSymbol, this.selectedIntradayNewsLast);
    this.getExistingSymbols();
  }

  getIntradayNews(query, last) {
    this.intradayNewsLoading = true;
    let symbol = query.split('|')[1];
    this.http.get<IntradayNews[]>(this.baseUrl + `News/intradayNewsAsync?symbol=${symbol}&last=${last}`)
    .subscribe(result => {
      this.intradayNews = result;
      this.intradayNewsLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.intradayNewsLoading = false;
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

  clear(table: Table) {
      table.clear();
  }

  cancel() {
    this.selectedSymbol = '';
  }
}

interface IntradayNews {
  symbol: string;
  datetime: string | Date;
  headline: string;
  source: string;
  url: string;
  summary: string;
  related: string;
  image: string;
  lang: string;
  hasPaywall: boolean;
}
