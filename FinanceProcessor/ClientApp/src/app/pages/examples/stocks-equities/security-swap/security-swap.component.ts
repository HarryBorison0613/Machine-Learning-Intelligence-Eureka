import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { SecurityReclassification } from "src/app/pages/domain/stock";

@Component({
  selector: "stocks-equities-security-swap",
  templateUrl: "security-swap.component.html",
  styleUrls: ['../subpage.css'],
})
export class SecuritySwapComponent implements OnInit {

  securitySwap: SecurityReclassification[];

  selectedSecuritySwapRange: string;

  selectedSecuritySwapCalendarOption: boolean;

  selectedSecuritySwapLast: number;

  securitySwapLoading: boolean = true;

  ranges: string[];

  calendarOptions: any[];

  constructor( private stockService: StockService) {
    this.selectedSecuritySwapRange = 'OneYear';
    this.selectedSecuritySwapCalendarOption = true;
    this.selectedSecuritySwapLast = 10000;
   }

  ngOnInit() {
    this.getSecuritySwap(this.selectedSecuritySwapRange, this.selectedSecuritySwapCalendarOption, this.selectedSecuritySwapLast);

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

  getSecuritySwap(ran, cal, last) {
    this.securitySwapLoading = false;
    this.stockService.getSecuritySwap(ran, cal, last).then(collections => {
      this.securitySwap = collections;
      this.securitySwapLoading = false;
    }).catch(() => {
      this.securitySwapLoading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
