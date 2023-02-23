import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { ReturnOfCapital } from "src/app/pages/domain/stock";

@Component({
  selector: "stocks-equities-return-of-capital",
  templateUrl: "return-of-capital.component.html",
  styleUrls: ['../subpage.css'],
})
export class ReturnOfCapitalComponent implements OnInit {

  returnOfCapital: ReturnOfCapital[];

  selectedReturnOfCapitalRange: string;

  selectedReturnOfCapitalCalendarOption: boolean;

  selectedReturnOfCapitalLast: number;

  returnOfCapitalLoading: boolean = true;

  ranges: string[];

  calendarOptions: any[];

  constructor( private stockService: StockService) {
    this.selectedReturnOfCapitalRange = 'OneYear';
    this.selectedReturnOfCapitalCalendarOption = true;
    this.selectedReturnOfCapitalLast = 10000;
   }

  ngOnInit() {
    this.getReturnOfCapital(this.selectedReturnOfCapitalRange, this.selectedReturnOfCapitalCalendarOption, this.selectedReturnOfCapitalLast);

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

  getReturnOfCapital(ran, cal, last) {
    this.returnOfCapitalLoading = false;
    this.stockService.getReturnOfCapital(ran, cal, last).then(collections => {
      this.returnOfCapital = collections;
      this.returnOfCapitalLoading = false;
    }).catch(() => {
      this.returnOfCapitalLoading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
