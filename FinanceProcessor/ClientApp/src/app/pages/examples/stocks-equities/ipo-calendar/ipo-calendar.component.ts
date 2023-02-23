import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { IpoCalendar } from "../../../domain/stock";

@Component({
  selector: "stocks-equities-ipo-calendar",
  templateUrl: "ipo-calendar.component.html",
  styleUrls: ['../subpage.css'],
})
export class IPOCalendarComponent implements OnInit {
  selectedIpoType: string;
  
  ipoCalendarData: IpoCalendar[];

  ipoCalendarDataLoading: boolean = true;
  
  constructor( private stockService: StockService ) {
    this.selectedIpoType = 'Today';
   }

  ngOnInit() {
    this.getIpoCalendarData(this.selectedIpoType);
  }

  getIpoCalendarData(symbol) {
    this.ipoCalendarDataLoading = true;
    this.stockService.getIpoCalendarData(symbol).then(collections => {
      collections.map(collection => {
        collection.filedDate = new Date(collection.filedDate);
        collection.offeringDate = new Date(collection.offeringDate);
        collection.updated = new Date(collection.updated);
      })
      this.ipoCalendarData = collections;
      this.ipoCalendarDataLoading = false;
    }).catch(() => {
      this.ipoCalendarData = [];
      this.ipoCalendarDataLoading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
