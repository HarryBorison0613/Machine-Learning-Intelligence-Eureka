import { Component, OnInit, Inject } from "@angular/core";
import { Table } from "primeng/table";
import { ToastrService } from "ngx-toastr";

import { StockService } from "../../../service/stockservice";
import { GlobalVariable } from "src/app/_services/global.variable";
import { HttpClient, HttpHeaders } from "@angular/common/http";

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json-patch+json' })
};

@Component({
  selector: "news-streaming-news",
  templateUrl: "streaming-news.component.html",
  styleUrls: ['./streaming-news.css'],
})
export class StreamingNewsComponent implements OnInit {
  selectedStreamingNewsSymbol: string;

  symbols: any[];
  
  streamingNews: StreamingNews[];

  streamingNewsLoading: boolean = true;

  filteredSymbols: any[];

  constructor( private http: HttpClient, private stockService: StockService, private globalVariable: GlobalVariable, @Inject('BASE_URL') private baseUrl: string, public toastr: ToastrService ) {
    this.selectedStreamingNewsSymbol = this.globalVariable.getGlobalSearchSymbolName();
   }

  ngOnInit() {
    this.getStreamingNews(this.selectedStreamingNewsSymbol);
    this.getExistingSymbols();
  }

  getStreamingNews(symbol) {
    this.streamingNewsLoading = true;
    const symbols: string[] = [];
    symbols.push(symbol);
    this.http.post<StreamingNews[]>(this.baseUrl + `News/newsStream`, symbols, httpOptions)
    .subscribe(result => {
      result.map(item => item.symbol = symbol);
      this.streamingNews = result;
      this.streamingNewsLoading = false;
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
      this.streamingNewsLoading = false;
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

interface StreamingNews {
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
