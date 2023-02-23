import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { Spinoff } from "src/app/pages/domain/stock";

@Component({
  selector: "stocks-equities-spinoff",
  templateUrl: "spinoff.component.html",
  styleUrls: ['../subpage.css'],
})
export class SpinoffComponent implements OnInit {

  spinoff: Spinoff[];

  selectedSpinoffRange: string;

  selectedSpinoffCalendarOption: boolean;

  selectedSpinoffLast: number;

  spinoffLoading: boolean = true;

  ranges: string[];

  calendarOptions: any[];

  constructor( private stockService: StockService) {
    this.selectedSpinoffRange = 'OneYear';
    this.selectedSpinoffCalendarOption = true;
    this.selectedSpinoffLast = 10000;
   }

  ngOnInit() {
    this.getSpinoff(this.selectedSpinoffRange, this.selectedSpinoffCalendarOption, this.selectedSpinoffLast);

    this.ranges = [
      'Today',
      'Yesterday',
      'Tomorrow',
      'Ytd',
      'OneMonth',
      'ThreeMonths',
      'SixMonths',
      'OneYear',
      'TwoYears',
      'FiveYears',
      'ThisWeek',
      'ThisMonth',
      'ThisQuarter',
      'LastWeek',
      'LastMonth',
      'LastQuarter',
      'NextWeek',
      'NextMonth',
      'NextQuarter',
    ];
    this.calendarOptions = [{label: '--Calendar--', value: 'true'}, {label: 'true', value: 'true'}, {label: 'false', value: 'false'}];
  }

  getSpinoff(ran, cal, last) {
    this.spinoffLoading = false;
    this.stockService.getSpinoff(ran, cal, last).then(collections => {
      this.spinoff = collections;
      this.spinoffLoading = false;
    }).catch(() => {
      this.spinoffLoading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
