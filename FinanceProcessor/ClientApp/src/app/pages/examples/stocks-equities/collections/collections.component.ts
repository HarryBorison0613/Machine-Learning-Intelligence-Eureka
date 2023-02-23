import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { Collection } from '../../../domain/stock';
import { StockService } from "../../../service/stockservice";

@Component({
  selector: "stocks-equities-collections",
  templateUrl: "collections.component.html",
  styleUrls: ['../subpage.css'],
})
export class CollectionsComponent implements OnInit {
  selectedCollectionType: string;
  
  selectedCollectionName: string;

  collectionTypes: any[];

  collectionNames: any[];

  collections: Collection[];

  statuses: any[];

  loading: boolean = true;

  constructor( private stockService: StockService ) {
    this.selectedCollectionType = 'Sector';
    this.selectedCollectionName = 'Technology';
   }

  ngOnInit() {
    this.getCollections(this.selectedCollectionType, this.selectedCollectionName);

    this.statuses = [
        {label: 'close', value: 'close'},
        {label: 'previousclose', value: 'previousclose'},
    ]

    this.collectionTypes = [
      'Sector',
      'Tag',
      'List'
    ];

    this.collectionNames = [
      'Technology',
      'Energy',
      'Financials',
      'Materials',
      'consumer Discretionary',
      'Communication Services',
      'Health Care',
      'Utilities',
      'Real Estate',
      'Industries',
    ];
  }

  getCollections(cType, cName) {
    this.loading = true;
    this.stockService.getCollections(cType, cName).then(collections => {
      this.collections = collections;

      this.collections.forEach(collection => {
        collection.openTime = new Date(collection.openTime);
        collection.closeTime = new Date(collection.closeTime);
        collection.highTime = new Date(collection.highTime);
        collection.lowTime = new Date(collection.lowTime);
        collection.latestTime = new Date(collection.latestTime);
        collection.latestUpdate = new Date(collection.latestUpdate);
        collection.delayedPriceTime = new Date(collection.delayedPriceTime);
        collection.oddLotDelayedPriceTime = new Date(collection.oddLotDelayedPriceTime);
        collection.extendedPriceTime = new Date(collection.extendedPriceTime);
        collection.iexOpenTime = new Date(collection.iexOpenTime);
        collection.iexCloseTime = new Date(collection.iexCloseTime);
        collection.lastTradeTime = new Date(collection.lastTradeTime);
      });
    });
    this.loading = false;
  }

  clear(table: Table) {
      table.clear();
  }
}

