import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { RightToPurchase } from "src/app/pages/domain/stock";

@Component({
  selector: "stocks-equities-right-to-purchase",
  templateUrl: "right-to-purchase.component.html",
  styleUrls: ['../subpage.css'],
})
export class RightToPurchaseComponent implements OnInit {

  rightToPurchase: RightToPurchase[];

  selectedRightToPurchaseRange: string;

  selectedRightToPurchaseCalendarOption: boolean;

  selectedRightToPurchaseLast: number;

  rightToPurchaseLoading: boolean = true;

  ranges: string[];

  calendarOptions: any[];

  constructor( private stockService: StockService) {
    this.selectedRightToPurchaseRange = 'OneYear';
    this.selectedRightToPurchaseCalendarOption = true;
    this.selectedRightToPurchaseLast = 10000;
   }

  ngOnInit() {
    this.getRightToPurchase(this.selectedRightToPurchaseRange, this.selectedRightToPurchaseCalendarOption, this.selectedRightToPurchaseLast);

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

  getRightToPurchase(ran, cal, last) {
    this.rightToPurchaseLoading = false;
    this.stockService.getRightToPurchase(ran, cal, last).then(collections => {
      this.rightToPurchase = collections;
      this.rightToPurchaseLoading = false;
    }).catch(() => {
      this.rightToPurchaseLoading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
