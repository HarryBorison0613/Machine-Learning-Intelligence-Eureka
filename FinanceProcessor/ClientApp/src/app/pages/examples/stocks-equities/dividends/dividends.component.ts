import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { Dividends } from "src/app/pages/domain/stock";


@Component({
  selector: "stocks-equities-dividends",
  templateUrl: "dividends.component.html",
  styleUrls: ['../subpage.css'],
})
export class DividendsComponent implements OnInit {

  dividends: Dividends[];

  selectedDividendsRange: string;

  selectedDividendsCalendarOption: boolean;

  selectedDividendsLast: number;

  dividendsLoading: boolean = true;

  ranges: any[];

  calendarOptions: any[];

  constructor( private stockService: StockService) {
    this.selectedDividendsRange = 'OneYear';
    this.selectedDividendsCalendarOption = true;
    this.selectedDividendsLast = 10000;
   }

  ngOnInit() {
    this.getDividends(this.selectedDividendsRange, this.selectedDividendsCalendarOption, this.selectedDividendsLast);

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

  getDividends(ran, cal, last) {
    this.dividendsLoading = true;
    this.stockService
    .getDividends(ran, cal, last)
    .then(collections => {
      this.dividends = collections;
      this.dividends.forEach(item => {
        item.exDate = new Date(item.exDate);
        item.recordDate = new Date(item.recordDate);
        item.paymentDate = new Date(item.paymentDate);
        item.date = new Date(item.date);
        item.updated = new Date(item.updated);
        item.more = false;
      });
      this.dividendsLoading = false;
    }).catch(() => {
      this.dividendsLoading = false;
    });
  }

  switchNote(id) {
    this.dividends.map(item => {
      if(item.id === id) {
        item.more = !item.more;
      }
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
