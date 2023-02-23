import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { BonusIssue } from "src/app/pages/domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-bonus-issue",
  templateUrl: "bonus-issue.component.html",
  styleUrls: ['../subpage.css'],
})
export class BonusIssueComponent implements OnInit {

  bonusIssues: BonusIssue[];

  selectedRange: string;

  selectedCalendarOption: boolean;

  selectedBonusIssueLast: number;

  selectedBonusIssueSymbol: string;

  loading: boolean = true;

  ranges: any[];

  calendarOptions: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable) {
    this.selectedRange = 'OneYear';
    this.selectedCalendarOption = true;
    this.selectedBonusIssueLast = 10000;
   }

  ngOnInit() {
    this.getBonusIssues(this.selectedRange, this.selectedCalendarOption, this.selectedBonusIssueLast);
    this.selectedBonusIssueSymbol = this.globalVariable.getGlobalSearchSymbolName();

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
    this.calendarOptions = [{label: 'Calendar', value: 'true'}, {label: 'true', value: 'true'}, {label: 'false', value: 'false'}];
  }

  getBonusIssues(ran, cal, last) {
    this.loading = true;
    this.stockService.getBonusIssues(ran, cal, last).then(issues => {
      this.bonusIssues = issues;
      this.loading = false;
    }).catch(() => {
      this.loading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
