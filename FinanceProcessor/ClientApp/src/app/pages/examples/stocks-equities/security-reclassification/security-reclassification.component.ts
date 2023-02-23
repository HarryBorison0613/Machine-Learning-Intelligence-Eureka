import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { SecurityReclassification } from "src/app/pages/domain/stock";

@Component({
  selector: "stocks-equities-security-reclassification",
  templateUrl: "security-reclassification.component.html",
  styleUrls: ['../subpage.css'],
})
export class SecurityReclassificationComponent implements OnInit {

  securityReclassification: SecurityReclassification[];

  selectedSecurityReclassificationRange: string;

  selectedSecurityReclassificationCalendarOption: boolean;

  selectedSecurityReclassificatioinLast: number;

  securityReclassificationLoading: boolean = true;

  ranges: string[];

  calendarOptions: any[];

  constructor( private stockService: StockService) {
    this.selectedSecurityReclassificationRange = 'OneYear';
    this.selectedSecurityReclassificationCalendarOption = true;
    this.selectedSecurityReclassificatioinLast = 10000;
   }

  ngOnInit() {
    this.getSecurityReclassification(this.selectedSecurityReclassificationRange, this.selectedSecurityReclassificationCalendarOption, this.selectedSecurityReclassificatioinLast);

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

  getSecurityReclassification(ran, cal, last) {
    this.securityReclassificationLoading = false;
    this.stockService.getSecurityReclassification(ran, cal, last).then(collections => {
      console.log(collections);
      this.securityReclassification = collections;
      this.securityReclassificationLoading = false;
    }).catch(() => {
      this.securityReclassificationLoading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
