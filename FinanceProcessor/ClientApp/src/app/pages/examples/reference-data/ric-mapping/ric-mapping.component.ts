import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Table } from "primeng/table";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "reference-data-ric-mapping",
  templateUrl: "ric-mapping.component.html",
})
export class RICMappingComponent implements OnInit {

  data: any[];
  loading: boolean;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService,
  ) { }

  ngOnInit() { }

  getRicMapping(number): void {
    this.loading = true;
    this.http.get<Mapping[]>(this.baseUrl + `References/RICMapping?ric=${number}`).subscribe(result => {
      this.data = result;
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

interface Mapping {
  symbol: string;
  exchange: string;
  region: string;
}
