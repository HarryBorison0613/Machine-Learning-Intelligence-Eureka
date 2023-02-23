import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Table } from "primeng/table";

import { Symbol } from "src/app/pages/domain/reference";
import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "reference-data-otc-symbols",
  templateUrl: "otc-symbols.component.html"
})
export class OTCSymbolsComponent implements OnInit {

  symbols: any[];
  loading: boolean;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService,
  ) { }

  ngOnInit() {
    this.getExistingSymbols();
  }

  getExistingSymbols(): void {
    this.loading = true;
    this.http.get<Symbol[]>(this.baseUrl + 'References/exchangesUS').subscribe(result => {
      this.symbols = result;
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
