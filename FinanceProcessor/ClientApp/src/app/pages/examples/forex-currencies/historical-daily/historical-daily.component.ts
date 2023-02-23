import { Component, OnInit, Inject } from "@angular/core";
import { Table } from "primeng/table";
import { ToastrService } from "ngx-toastr";

import { HttpClient } from "@angular/common/http";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "forex-currencies-historical-daily",
  templateUrl: "historical-daily.component.html",
  styleUrls: ['./historical-daily.css'],
})
export class HistoricalDailyComponent implements OnInit {
  selectedHistoricalDailySymbol: string;

  symbols: any[];
  
  historicalDaily: HistoricalDaily[];

  selectedHistoricalDailyLast: number;

  historicalDailyLoading: boolean = false;

  filteredSymbols: any[];

  constructor( 
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string, 
    public toastr: ToastrService, 
    private errors: ErrorService
  ) {
    //Toast shows
    this.toastr.show(
      '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
      'Please input parameters to get search result.',
      {
        timeOut: 3500,
        closeButton: true,
        enableHtml: true,
        toastClass: "alert alert-info alert-with-icon",
        positionClass: "toast-top-right"
      }
    );
    setTimeout(() => {
      this.toastr.show(
        '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
        'Ex: Symbol: AAPL, From: 11/01/2022, To: 11/11/2022, Last: 10',
        {
          timeOut: 10000,
          closeButton: true,
          enableHtml: true,
          toastClass: "alert alert-info alert-with-icon",
          positionClass: "toast-top-right"
        }
      );
    }, 4000);
   }

  ngOnInit() {
    this.getExistingSymbols();
  }

  getHistoricalDaily(symbol, from, to, last) {
    const fromDate = (new Date(from)).toISOString().slice(0, 10);
    const toDate = (new Date(to)).toISOString().slice(0, 10);
    this.historicalDailyLoading = true;
    this.http.get<HistoricalDaily[][]>(this.baseUrl + `ForexCurrencies/historicalDaily?forexSymbols=${symbol}&fromDate=${fromDate}&toDate=${toDate}&last=${last}`)
    .subscribe(result => {
      this.historicalDaily = result[0];
      this.historicalDailyLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.historicalDailyLoading = false;
    });
  }

  getExistingSymbols(): void {
    this.http.get<any>(this.baseUrl + `References/existingForexPairsSymbol`).subscribe(result => {
      this.symbols = result.map(item => item.symbol);
    }, (err) => {
      console.log(err);
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

interface HistoricalDaily {
  amount: number;
  symbol: string;
  rate: number;
  timestamp: string | Date;
  isDerived: boolean;
}