import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { MarketVolume } from "../../../domain/marketinfo";
import { DashboardService } from "src/app/pages/service/dashboardservice";

@Component({
  selector: "stocks-equities-markets",
  templateUrl: "markets.component.html"
})
export class MarketsComponent implements OnInit {
  symbols: any[];

  markets: MarketVolume[];

  marketsLoading: boolean = true;

  constructor( private stockService: StockService, private dashboardService: DashboardService) { }

  ngOnInit() {
    this.getMarkets();
  }

  getMarkets() {
    this.marketsLoading = true;
    this.dashboardService.getMarkets().then(collections => {
      this.markets = collections;
      this.markets.forEach(item => {
        item.marketPercent = Math.round(item.marketPercent*10000)/100;
      })
      this.marketsLoading = false;
    }).catch(() => {
      this.markets = [];
      this.marketsLoading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
