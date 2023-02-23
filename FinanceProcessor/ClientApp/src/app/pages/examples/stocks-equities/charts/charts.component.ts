import { Component, OnInit } from "@angular/core";
import Chart from "chart.js";
import { StockService } from "src/app/pages/service/stockservice";
import { DashboardService } from "src/app/pages/service/dashboardservice";
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-charts",
  templateUrl: "charts.component.html",
})
export class ChartsComponent implements OnInit {
  public canvas: any;
  public ctx;
  public datasets: any;
  public data: any;
  public bigChartData;
  public clicked: boolean = true;
  public symbols: any[];
  public filteredSymbols: any[];
  public intradayPrices: any[];
  public selectedSymbol: string;

  constructor( 
    private stockService: StockService,
    private dashboardService: DashboardService,
    private globalVariable: GlobalVariable,
  ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
  }
  
  ngOnInit() {
    this.getExistingSymbols();
    this.getIntradayPrices(this.selectedSymbol);
    this.drawChart([]);
  }

  public updateOptions(collections) {
    this.bigChartData.data.labels = collections.filter(item => item.high !== 0).map(item => item.minute);
    this.bigChartData.data.datasets[0].data = collections.filter(item => item.high !== 0).map(item => item.high);
    this.bigChartData.update();
  }

  getIntradayPrices(query) {
    let symbol = query.split('|')[1];
    if(symbol === "" || symbol === undefined)  {
      return;
    }
    this.stockService.getIntradayPrices(symbol).then(collections => {
      collections.map(collections => collections.symbol = symbol);
      this.intradayPrices = collections;
      this.updateOptions(collections);
    }).catch(() => {
      this.intradayPrices = [];
    });
  }

   getExistingSymbols(): void {
     this.stockService.getExistingSymbols().then(collections => {
       this.symbols = collections;
     })
   }

   filterSymbol(event) {
     let filtered: any[] = [];
     let query = event.query;
     for (let i = 0; i < this.symbols.length; i++) {
       let symbol = this.symbols[i];
       if (symbol.symbol.toLowerCase().indexOf(query.toLowerCase()) == 0 || symbol.name.toLowerCase().indexOf(query.toLowerCase()) > -1) {
         filtered.push(symbol.name + '|' + symbol.symbol);
       }
     }
     this.filteredSymbols = filtered;
   }

   drawChart(collections) {
     this.canvas = document.getElementById("chartBig1");
     this.ctx = this.canvas.getContext("2d");
     var gradientStroke = this.ctx.createLinearGradient(0, 230, 0, 50);
 
     gradientStroke.addColorStop(1, "rgba(233,32,16,0.2)");
     gradientStroke.addColorStop(0.4, "rgba(233,32,16,0.0)");
     gradientStroke.addColorStop(0, "rgba(233,32,16,0)");
 
     this.bigChartData = new Chart(this.ctx, {
       type: "line",
       data: {
         labels: collections.filter(item => item.high !== null).map(item => item.minute),
         datasets: [
           {
             label: "High",
             fill: true,
             backgroundColor: gradientStroke,
             borderColor: "#ec250d",
             borderWidth: 2,
             borderDash: [],
             borderDashOffset: 0.0,
             pointBackgroundColor: "#ec250d",
             pointBorderColor: "rgba(255,255,255,0)",
             pointHoverBackgroundColor: "#ec250d",
             pointBorderWidth: 20,
             pointHoverRadius: 1,
             pointHoverBorderWidth: 15,
             pointRadius: 0,
             data: collections.filter(item => item.high !== null).map(item => item.high),
           },
         ]
       },
       options: this.dashboardService.gradientChartOptionsConfigurationWithTooltipRed
     });
   }

   cancel() {
     this.selectedSymbol = '';
   }
}
