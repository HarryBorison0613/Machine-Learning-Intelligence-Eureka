import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { MarketVolume } from "../../../domain/marketinfo";
import { DashboardService } from "src/app/pages/service/dashboardservice";

@Component({
  selector: "stocks-equities-market-volume-us",
  templateUrl: "market-volume-us.component.html",
  styleUrls: ['../subpage.css'],
})
export class MarketVolumeUSComponent implements OnInit {
  symbols: any[];

  listTypes: any[];
  
  marketVolume: MarketVolume[];

  marketVolumeLoading: boolean = true;

  constructor( private stockService: StockService, private dashboardService: DashboardService) { }

  ngOnInit() {
    this.getMarketVolume();
  }

  getMarketVolume() {
    this.marketVolumeLoading = true;
    this.dashboardService.getVolumes().then(collections => {
      this.marketVolume = collections;
      this.marketVolume.forEach(item => {
        item.marketPercent = Math.round(item.marketPercent*10000)/100;
      })
      this.marketVolumeLoading = false;
    }).catch(() => {
      this.marketVolume = [];
      this.marketVolumeLoading = false;
    });
  }

  clear(table: Table) {
      table.clear();
  }
}
