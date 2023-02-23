import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { DashboardService } from '../../../service/dashboardservice';
import { SectorPerformance } from "src/app/pages/domain/stock";

@Component({
  selector: "stocks-equities-sector-performance",
  templateUrl: "sector-performance.component.html",
  styleUrls: ['../subpage.css'],
})
export class SectorPerformanceComponent implements OnInit {

  sectors: SectorPerformance[];
  sectorPerformanceLoading: boolean = true;

  constructor( private dashboardService: DashboardService) { }

  ngOnInit() {
    this.getSectors();
  }

  public getSectors(): void {
    this.sectorPerformanceLoading = true;
    this.dashboardService.getSectors().then(sectors => {
      this.sectors = sectors;
      this.sectors.map(item => {
        item.performance = Math.round((item.performance + Number.EPSILON) * 10000) / 100;
      })
    }).catch(() => {
      this.sectors = [];
    });
    this.sectorPerformanceLoading = false;
  }

  clear(table: Table) {
      table.clear();
  }
}