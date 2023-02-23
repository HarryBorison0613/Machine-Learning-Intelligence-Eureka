import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Table } from "primeng/table";

import { ErrorService } from "src/app/pages/service/errorservice";

@Component({
  selector: "reference-data-tags",
  templateUrl: "tags.component.html"
})
export class TagsComponent implements OnInit {

  data: Tag[];
  loading: boolean;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string, 
    private errors: ErrorService,
  ) { }

  ngOnInit() {
    this.getExistingSectors();
  }

  getExistingSectors(): void {
    this.loading = true;
    this.http.get<Tag[]>(this.baseUrl + 'References/existingTags').subscribe(result => {
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

interface Tag {
  name: string;
}
