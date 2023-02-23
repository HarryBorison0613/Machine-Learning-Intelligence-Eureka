import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Table } from "primeng/table";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "reference-data-iex-symbols",
  templateUrl: "iex-symbols.component.html"
})
export class IEXSymbolsComponent implements OnInit {

  iexSymbols: any[];
  loading: boolean;

  constructor(
    private http: HttpClient,
    private errors: ErrorService,
    @Inject('BASE_URL') private baseUrl: string,
  ) { }

  ngOnInit() {
    this.getIexSymbols();
  }

  getIexSymbols() {
    this.loading = true;
    this.http.get<string[]>(
      this.baseUrl + `References/existingIEXSymbols`
    ).subscribe(result => {
      this.iexSymbols = result;
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
