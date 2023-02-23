import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { Split } from "src/app/pages/domain/stock";

@Component({
  selector: "stocks-equities-splits",
  templateUrl: "splits.component.html",
  styleUrls: ['../subpage.css'],
})
export class SplitsComponent implements OnInit {

  splits: Split[];

  selectedSplitsRange: string;

  selectedSplitsCalendarOption: boolean;

  selectedSplitsLast: number;

  splitsLoading: boolean = true;

  ranges: any[];

  calendarOptions: any[];

  constructor( private stockService: StockService) {
    this.selectedSplitsRange = 'OneYear';
    this.selectedSplitsCalendarOption = true;
    this.selectedSplitsLast = 10000;
   }

  ngOnInit() {
    this.getSplits(this.selectedSplitsRange, this.selectedSplitsCalendarOption, this.selectedSplitsLast);

    this.ranges = [
      { label: 'Range', value: 'Ytd' }, 
      { label: 'Today', value: 'Today' }, 
      { label: 'Yesterday', value: 'Yesterday' }, 
      { label: 'Tomorrow', value: 'Tomorrow' }, 
      { label: 'Ytd', value: 'Ytd' }, 
      { label: 'OneMonth', value: 'OneMonth' }, 
      { label: 'ThreeMonths', value: 'ThreeMonths' }, 
      { label: 'SixMonths', value: 'SixMonths' },
      { label: 'OneYear', value: 'OneYear' }, 
      { label: 'TwoYears', value: 'TwoYears' }, 
      { label: 'FiveYears', value: 'FiveYears' }, 
      { label: 'This Week', value: 'This Week' }, 
      { label: 'ThisMonth', value: 'ThisMonth' }, 
      { label: 'ThisQuarter', value: 'ThisQuarter' },
      { label: 'LastWeek', value: 'LastWeek' }, 
      { label: 'LastMonth', value: 'LastMonth' }, 
      { label: 'LastQuarter', value: 'LastQuarter' }, 
      { label: 'NextWeek', value: 'NextWeek' }, 
      { label: 'NextMonth', value: 'NextMonth' }, 
      { label: 'NextQuarter', value: 'NextQuarter' }
    ];
    this.calendarOptions = [
      {label: 'Calendar', value: 'true'}, 
      {label: 'true', value: 'true'}, 
      {label: 'false', value: 'false'}
    ];
  }

  getSplits(ran, cal, last) {
    this.splitsLoading = true;
    this.stockService.getSplits(ran, cal, last).then(collections => {
      this.splits = collections;
      this.splitsLoading = false;
    }).catch(() => {
      this.splitsLoading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
