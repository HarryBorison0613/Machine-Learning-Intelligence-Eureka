import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { RightsIssue } from "src/app/pages/domain/stock";

@Component({
  selector: "stocks-equities-rights-issue",
  templateUrl: "rights-issue.component.html",
  styleUrls: ['../subpage.css'],
})
export class RightsIssueComponent implements OnInit {

  rightsIssue: RightsIssue[];

  selectedRightsIssueRange: string;

  selectedRightsIssueCalendarOption: boolean;

  selectedRightsIssueLast: number;

  rightsIssueLoading: boolean = true;

  ranges: string[];

  calendarOptions: any[];

  constructor( private stockService: StockService) {
    this.selectedRightsIssueRange = 'OneYear';
    this.selectedRightsIssueCalendarOption = true;
    this.selectedRightsIssueLast = 10000;
   }

  ngOnInit() {
    this.getRightsIssue(this.selectedRightsIssueRange, this.selectedRightsIssueCalendarOption, this.selectedRightsIssueLast);

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

  getRightsIssue(ran, cal, last) {
    this.rightsIssueLoading = false;
    this.stockService.getRightsIssue(ran, cal, last).then(collections => {
      this.rightsIssue = collections;
      this.rightsIssueLoading = false;
    }).catch(() => {
      this.rightsIssueLoading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
