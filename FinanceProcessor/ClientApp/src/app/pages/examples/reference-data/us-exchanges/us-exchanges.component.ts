import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Table } from "primeng/table";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "reference-data-us-exchanges",
  templateUrl: "us-exchanges.component.html"
})
export class USExchangesComponent implements OnInit {

  exchanges: any[];
  loading: boolean;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService,
  ) { }

  ngOnInit() {
    this.getUsExchanges();
  }

  getUsExchanges(): void {
    this.loading = true;
    this.http.get<Exchange[]>(this.baseUrl + 'References/exchangesUS').subscribe(result => {
      this.exchanges = result;
      this.loading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.loading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}

interface Exchange {
  mic: string;
  name: string;
  longName: string;
  tapeId: string;
  oatsId: string;
  refId: string;
  type: string;
}
