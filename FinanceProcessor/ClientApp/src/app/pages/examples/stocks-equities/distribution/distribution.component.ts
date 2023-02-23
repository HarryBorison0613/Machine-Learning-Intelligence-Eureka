import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { DistributionList } from "src/app/pages/domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-distribution",
  templateUrl: "distribution.component.html",
  styleUrls: ['../subpage.css'],
})
export class DistributionComponent implements OnInit {

  distributionList: DistributionList[];

  selectedDistributionRange: string;

  selectedDistributionCalendarOption: boolean;

  selectedDistributionLast: number;

  distributionLoading: boolean = true;

  ranges: any[];

  calendarOptions: any[];

  constructor( private stockService: StockService ) {
    this.selectedDistributionRange = 'OneYear';
    this.selectedDistributionCalendarOption = true;
    this.selectedDistributionLast = 10000;
   }

  ngOnInit() {
    this.getDistributionList(this.selectedDistributionRange, this.selectedDistributionCalendarOption, this.selectedDistributionLast);
    this.ranges = [{ label: 'Range', value: 'Ytd' }, { label: 'Today', value: 'Today' }, { label: 'Yesterday', value: 'Yesterday' }, { label: 'Tomorrow', value: 'Tomorrow' }, { label: 'Ytd', value: 'Ytd' }, { label: 'OneMonth', value: 'OneMonth' }, { label: 'ThreeMonths', value: 'ThreeMonths' }, { label: 'SixMonths', value: 'SixMonths' }, { label: 'OneYear', value: 'OneYear' }, { label: 'TwoYears', value: 'TwoYears' }, { label: 'FiveYears', value: 'FiveYears' }, { label: 'This Week', value: 'This Week' }, { label: 'ThisMonth', value: 'ThisMonth' }, { label: 'ThisQuarter', value: 'ThisQuarter' }, { label: 'LastWeek', value: 'LastWeek' }, { label: 'LastMonth', value: 'LastMonth' }, { label: 'LastQuarter', value: 'LastQuarter' }, { label: 'NextWeek', value: 'NextWeek' }, { label: 'NextMonth', value: 'NextMonth' }, { label: 'NextQuarter', value: 'NextQuarter' }];
    this.calendarOptions = [{label: 'Calendar', value: 'true'}, {label: 'true', value: 'true'}, {label: 'false', value: 'false'}];
  }

  getDistributionList(ran, cal, last) {
    this.distributionLoading = true;
    this.stockService.getDistributionList(ran, cal, last).then(collections => {
      this.distributionList = collections;
      this.distributionLoading = false;
    }).catch(() => {
      this.distributionLoading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
