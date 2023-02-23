import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Table } from "primeng/table";
import { ToastrService } from "ngx-toastr";

import { StockService } from "../../../service/stockservice";
import { GlobalVariable } from "src/app/_services/global.variable";
import { ParameterService } from "../../../service/parameterservice";

@Component({
  selector: "news-historical-news",
  templateUrl: "historical-news.component.html",
  styleUrls: ['./historical-news.css'],
})
export class HistoricalNewsComponent implements OnInit {
  selectedSymbol: string;

  symbols: any[];
  
  selectedHistoricalNewsLimit: number;

  selectedHistoricalNewsRange: string;

  ranges: any[];

  historicalNews: HistoricalNews[];

  historicalNewsLoading: boolean = true;

  filteredSymbols: any[];

  constructor( private http: HttpClient, private stockService: StockService, private parameterService: ParameterService , private globalVariable: GlobalVariable, @Inject('BASE_URL') private baseUrl: string, public toastr: ToastrService ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
    this.selectedHistoricalNewsRange = 'Ytd';
    this.selectedHistoricalNewsLimit = 5000;
   }

  ngOnInit() {
    this.getHistoricalNews(this.selectedSymbol, this.selectedHistoricalNewsRange, this.selectedHistoricalNewsLimit);
    this.getExistingSymbols();
    this.ranges = this.parameterService.ranges;
  }

  getHistoricalNews(query, range, limit) {
    this.historicalNewsLoading = true;
    let symbol = query.split('|')[1];
    this.http.get<HistoricalNews[]>(this.baseUrl + `News/historicalNews?symbol=${symbol}&timeSeriesRange=${range}&limit=${limit}`)
    .subscribe(result => {
      this.historicalNews = result;
      this.historicalNewsLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.toastr.show(
          '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
          'Network connection failed. Please check network connection',
          {
            timeOut: 4000,
            closeButton: true,
            enableHtml: true,
            toastClass: "alert alert-danger alert-with-icon",
            positionClass: "toast-top-right"
          }
        );
      }
      this.historicalNewsLoading = false;
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

interface HistoricalNews {
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
