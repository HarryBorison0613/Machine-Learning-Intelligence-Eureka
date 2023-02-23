import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from '../../../service/stockservice';
import { ViewData, Earning, DividendsBasic, IPO, SplitsBasic } from "src/app/pages/domain/stock";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-upcoming-events",
  templateUrl: "upcoming-events.component.html",
  styleUrls: ['../subpage.css'],
})
export class UpcomingEventsComponent implements OnInit {

  symbols: string[];
  filteredSymbols: any[];
  
  upcomingIpos: IPO[];
  selectedUpcomingIposSymbol: string;
  upcomingIposLoading: boolean = true;
  viewData: ViewData[];

  upcomingDividendsMarket: DividendsBasic[];
  selectedUpcomingDividendsMarketSymbol: string;
  upcomingDividendsMarketLoading: boolean = true;

  upcomingEarningsMarket: Earning[];
  selectedUpcomingEarningsMarketSymbol: string;
  upcomingEarningsMarketLoading: boolean = true;

  upcomingSplitsMarket: SplitsBasic[];
  selectedUpcomingSplitsMarketSymbol: string;
  upcomingSplitsMarketLoading: boolean = true;

  constructor( private stockService: StockService, private globalVariable: GlobalVariable) {
   }

  ngOnInit() {
    this.getUpcomingDividendsMarket();
    this.getUpcomingEarningsMarket();
    this.getUpcomingSplitsMarket();
    this.getExistingSymbols();
  }

  getUpcomingIpos(symbol) {
    this.upcomingIposLoading = true;
    this.stockService.getUpcomingIpos(symbol).then(collections => {
      this.upcomingIpos= collections;
      this.upcomingIposLoading = false;
    }).catch(() => {
      this.upcomingIposLoading = false;
    });
  }

  getUpcomingDividendsMarket() {
    this.upcomingDividendsMarketLoading = true;
    this.stockService.getUpcomingDividendsMarket().then(collections => {
      this.upcomingDividendsMarket= collections;
      this.upcomingDividendsMarket.map(item => {
        item.exDate = new Date(item.exDate);
        item.declaredDate = new Date(item.declaredDate);
        item.recordDate = new Date(item.recordDate);
        item.paymentDate = new Date(item.paymentDate);
        item.date = new Date(item.date);
        item.updated = new Date(item.updated);
      })
      this.upcomingDividendsMarketLoading = false;
    }).catch(() => {
      this.upcomingDividendsMarketLoading = false;
    });
  }

  getUpcomingEarningsMarket() {
    this.upcomingEarningsMarketLoading = true;
    this.stockService.getUpcomingEarningsMarket().then(collections => {
      this.upcomingEarningsMarket = collections;
      this.upcomingEarningsMarket.map(item => {
        item.reportDate = new Date(item.reportDate);
      })
      this.upcomingEarningsMarketLoading = false;
    }).catch(() => {
      this.upcomingEarningsMarketLoading = false;
    });
  }

  getUpcomingSplitsMarket() {
    this.upcomingSplitsMarketLoading = true;
    this.stockService.getUpcomingSplitsMarket().then(collections => {
      this.upcomingSplitsMarket = collections;
      this.upcomingSplitsMarket.map(item => {
        item.exDate = new Date(item.exDate);
        item.declaredDate = new Date(item.declaredDate);
        item.date = new Date(item.date);
        item.updated = new Date(item.updated);
      })
      this.upcomingSplitsMarketLoading = false;
    }).catch(() => {
      this.upcomingSplitsMarketLoading = false;
    });
  }

  getExistingSymbols(): void {
    this.stockService.getExistingSymbols().then(collections => {
      this.symbols = collections.map(item => item.symbol).sort();
    })
  }

  filterSymbol(event) {
    let filtered: any[] = [];
    let query = event.query;
    for (let i = 0; i < this.symbols.length; i++) {
      let symbol = this.symbols[i];
      if (symbol.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(symbol);
      }
    }
    this.filteredSymbols = filtered;
  }

  clear(table: Table) {
      table.clear();
  }
}
