import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import Chart from "chart.js";

@Component({
  selector: "app-dashboard",
  templateUrl: "stocks.component.html"
})
export class StocksComponent implements OnInit {
  public canvas: any;
  public ctx;
  public datasets: any;
  public data: any;
  public myChartData;
  public clicked: boolean = true;
  public clicked1: boolean = false;
  public clicked2: boolean = false;
  public entries: number = 5;
  public temp = [];
  public dividendstemp = [];
  public splitstemp = [];
  public rows: any = [];
  public dividendsrows: any = [];
  public splitsrows: any = [];
  public activeRow: any;
  public activeSplitsRow: any;
  
  public gradientChartOptionsConfigurationPurple = {
    maintainAspectRatio: false,
    legend: {
      display: false
    },

    tooltips: {
      backgroundColor: "#f5f5f5",
      titleFontColor: "#333",
      bodyFontColor: "#666",
      bodySpacing: 4,
      xPadding: 12,
      mode: "index",
      intersect: 0,
      position: "nearest"
    },
    responsive: true,
    scales: {
      yAxes: [
        {
          barPercentage: 1.6,
          gridLines: {
            drawBorder: false,
            color: "transparent",
            zeroLineColor: "transparent"
          },
          ticks: {
            padding: 0,
            fontColor: "#9e9e9e"
          }
        }
      ],

      xAxes: [
        {
          barPercentage: 1.6,
          gridLines: {
            drawBorder: false,
            color: "transparent",
            zeroLineColor: "transparent"
          },
          ticks: {
            padding: 20,
            fontColor: "#9e9e9e"
          }
        }
      ]
    }
  };

  constructor(private http: HttpClient ) { }

  ngOnInit() {
    this.getIntradayPricesForMostPopularSymbol();
    this.getUpcomingEarningsMarketInfo();
    this.getUpcomingSplitsMarketInfo();
    this.getUpcomingIposMarketInfo();
  }

  drawChart(data) {

    var gradientChartOptionsConfigurationBlue = {
      maintainAspectRatio: false,
      legend: {
        display: false
      },

      tooltips: {
        backgroundColor: "#f5f5f5",
        titleFontColor: "#333",
        bodyFontColor: "#666",
        bodySpacing: 1,
        xPadding: 12,
        mode: "index",
        intersect: 0,
        position: "nearest"
      },
      responsive: true,
      scales: {
        yAxes: [
          {
            barPercentage: 1.6,
            gridLines: {
              drawBorder: false,
              color: "rgba(0,0,255,0.0)",
              zeroLineColor: "transparent"
            },
            ticks: {
              padding: 0,
              fontColor: "#9e9e9e"
            }
          }
        ],

        xAxes: [
          {
            barPercentage: 1.6,
            gridLines: {
              drawBorder: false,
              color: "transparent",
              zeroLineColor: "transparent"
            },
            ticks: {
              padding: 20,
              fontColor: "#9e9e9e"
            }
          }
        ]
      }
    };

    var gradientChartOptionsConfigurationRed = {
      maintainAspectRatio: false,
      legend: {
        display: false
      },

      tooltips: {
        backgroundColor: "#f5f5f5",
        titleFontColor: "#333",
        bodyFontColor: "#666",
        bodySpacing: 1,
        xPadding: 12,
        mode: "index",
        intersect: 0,
        position: "nearest"
      },
      responsive: true,
      scales: {
        yAxes: [
          {
            barPercentage: 1.6,
            gridLines: {
              drawBorder: false,
              color: "rgba(255,0,0,0.0)",
              zeroLineColor: "transparent"
            },
            ticks: {
              padding: 0,
              fontColor: "#9e9e9e"
            }
          }
        ],

        xAxes: [
          {
            barPercentage: 1.6,
            gridLines: {
              drawBorder: false,
              color: "transparent",
              zeroLineColor: "transparent"
            },
            ticks: {
              padding: 20,
              fontColor: "#9e9e9e"
            }
          }
        ]
      }
    };
    this.canvas = document.getElementById("spyIntradayPriceForMostPopularSymbol");
    this.ctx = this.canvas.getContext("2d");
    var gradientStroke = this.ctx.createLinearGradient(0, 230, 0, 50);

    gradientStroke.addColorStop(1, "rgba(29,140,248,0.2)");
    gradientStroke.addColorStop(0.4, "rgba(29,140,248,0.0)");
    gradientStroke.addColorStop(0, "rgba(29,140,248,0)");

    var myChart = new Chart(this.ctx, {
      type: "line",
      responsive: true,
      data: {
        labels: data.SPY.filter((item, index) => item.average !== null).map(item => item.minute),
        datasets: [
          {
            label: "High",
            borderColor: "#51df98", 
            borderWidth: 1,
            borderDash: [],
            borderDashOffset: 0.0,
            pointBackgroundColor: "#51df98",
            pointBorderColor: "rgba(255,255,255,0)",
            pointHoverBackgroundColor: "#be55ed",
            pointHoverBorderColor: 'rgba(255,255,255,1)',
            pointBorderWidth: 20,
            pointHoverRadius: 0,
            pointHoverBorderWidth: 15,
            pointRadius: 0,
            data: data.SPY.filter(item => item.high !== 0).map(item => item.high),
          },
          {
            label: "Close",
            borderColor: "#bf7cfc",
            borderWidth: 1,
            borderDash: [],
            borderDashOffset: 0.0,
            pointBackgroundColor: "#bf7cfc",
            pointBorderColor: "rgba(255,255,255,0)",
            pointHoverBackgroundColor: "#be55ed",
            pointHoverBorderColor: 'rgba(255,255,255,1)',
            pointBorderWidth: 20,
            pointHoverRadius: 0,
            pointHoverBorderWidth: 15,
            pointRadius: 0,
            data: data.SPY.filter(item => item.close !== 0).map(item => item.close),
          },
          {
            label: "Low",
            borderColor: "#de4758",
            borderWidth: 1,
            borderDash: [],
            borderDashOffset: 0.0,
            pointBackgroundColor: "#de4758",
            pointBorderColor: "rgba(255,255,255,0)",
            pointHoverBackgroundColor: "#be55ed",
            pointHoverBorderColor: 'rgba(255,255,255,1)',
            pointBorderWidth: 20,
            pointHoverRadius: 0,
            pointHoverBorderWidth: 15,
            pointRadius: 0,
            data: data.SPY.filter(item => item.low !== 0).map(item => item.low),
          },
        ]
      },
      options: this.gradientChartOptionsConfigurationPurple
    });

    this.canvas = document.getElementById("qqqIntradayPriceForMostPopularSymbol");
    this.ctx = this.canvas.getContext("2d");
    var greengradientStroke = this.ctx.createLinearGradient(0, 330, 0, 50);

    greengradientStroke.addColorStop(1, "rgba(44,111,76,1)");
    greengradientStroke.addColorStop(0, "rgba(44,111,76,0)");

    var myChart = new Chart(this.ctx, {
      type: "line",
      responsive: true,
      data: {
        labels: data.QQQ.filter((item, index) => item.average !== null).map(item => item.minute),
        datasets: [
          {
            label: "High",
            borderColor: "#51df98",
            borderWidth: 1,
            borderDash: [],
            borderDashOffset: 0.0,
            pointBackgroundColor: "#51df98",
            pointBorderColor: "rgba(255,255,255,0)",
            pointHoverBackgroundColor: "#be55ed",
            pointHoverBorderColor: 'rgba(255,255,255,1)',
            pointBorderWidth: 20,
            pointHoverRadius: 0,
            pointHoverBorderWidth: 15,
            pointRadius: 0,
            data: data.QQQ.filter(item => item.high !== 0).map(item => item.high),
          },
          {
            label: "Close",
            borderColor: "#bf7cfc",
            borderWidth: 1,
            borderDash: [],
            borderDashOffset: 0.0,
            pointBackgroundColor: "#bf7cfc",
            pointBorderColor: "rgba(255,255,255,0)",
            pointHoverBackgroundColor: "#be55ed",
            pointHoverBorderColor: 'rgba(255,255,255,1)',
            pointBorderWidth: 20,
            pointHoverRadius: 0,
            pointHoverBorderWidth: 15,
            pointRadius: 0,
            data: data.QQQ.filter(item => item.close !== 0).map(item => item.close),
          },
          {
            label: "Low",
            borderColor: "#de4758",
            borderWidth: 1,
            borderDash: [],
            borderDashOffset: 0.0,
            pointBackgroundColor: "#de4758",
            pointBorderColor: "rgba(255,255,255,0)",
            pointHoverBackgroundColor: "#be55ed",
            pointHoverBorderColor: 'rgba(255,255,255,1)',
            pointBorderWidth: 20,
            pointHoverRadius: 0,
            pointHoverBorderWidth: 15,
            pointRadius: 0,
            data: data.QQQ.filter(item => item.low !== 0).map(item => item.low),
          },
        ]
      },
      options: gradientChartOptionsConfigurationBlue
    });

    this.canvas = document.getElementById("iwmIntradayPriceForMostPopularSymbol");
    this.ctx = this.canvas.getContext("2d");
    var redgradientStroke = this.ctx.createLinearGradient(0, 330, 0, 50);

    redgradientStroke.addColorStop(1, "rgba(233,32,16,0.4)");
    redgradientStroke.addColorStop(0, "rgba(233,32,16,0)");

    var myChart = new Chart(this.ctx, {
      type: "line",
      responsive: true,
      data: {
        labels: data.IWM.filter((item, index) => item.average !== null).map(item => item.minute),
        datasets: [
          {
            label: "High",
            borderColor: "#51df98",
            borderWidth: 1,
            borderDash: [],
            borderDashOffset: 0.0,
            pointBackgroundColor: "#51df98",
            pointBorderColor: "rgba(255,255,255,0)",
            pointHoverBackgroundColor: "#be55ed",
            pointHoverBorderColor: 'rgba(255,255,255,1)',
            pointBorderWidth: 20,
            pointHoverRadius: 0,
            pointHoverBorderWidth: 15,
            pointRadius: 0,
            data: data.IWM.filter(item => item.high !== 0).map(item => item.high),
          },
          {
            label: "Close",
            borderColor: "#bf7cfc",
            borderWidth: 1,
            borderDash: [],
            borderDashOffset: 0.0,
            pointBackgroundColor: "#bf7cfc",
            pointBorderColor: "rgba(255,255,255,0)",
            pointHoverBackgroundColor: "#be55ed",
            pointHoverBorderColor: 'rgba(255,255,255,1)',
            pointBorderWidth: 20,
            pointHoverRadius: 0,
            pointHoverBorderWidth: 15,
            pointRadius: 0,
            data: data.IWM.filter(item => item.close !== 0).map(item => item.close),
          },
          {
            label: "Low",
            borderColor: "#de4758",
            borderWidth: 1,
            borderDash: [],
            borderDashOffset: 0.0,
            pointBackgroundColor: "#de4758",
            pointBorderColor: "rgba(255,255,255,0)",
            pointHoverBackgroundColor: "#be55ed",
            pointHoverBorderColor: 'rgba(255,255,255,1)',
            pointBorderWidth: 20,
            pointHoverRadius: 0,
            pointHoverBorderWidth: 15,
            pointRadius: 0,
            data: data.IWM.filter(item => item.low !== 0).map(item => item.low),
          },
        ]
      },
      options: gradientChartOptionsConfigurationRed
    });
  }

  private getIntradayPricesForMostPopularSymbol() {
    this.http.get<IntradayPriceForMostPopularSymbols>('/StockPrices/intradayPricesForMostPopularSymbol')
      .subscribe(result => {
        this.drawChart(result);
      });
  }

  private getUpcomingEarningsMarketInfo() {
    this.http.get<MarketInfo[]>('/MarketInfo/upcomingEarningsMarket').subscribe(result => {
      this.rows = result;
      this.temp = this.rows.map((prop, key) => {
        return {
          ...prop,
          reportDate: prop.reportDate.slice(0, 10),
          id: key
        };
      });
    }, error => { document.getElementById("tableForUpcomingEarningsMarket").innerHTML = 'No Data available at the moment.'; });
  }

  private getUpcomingSplitsMarketInfo() {
    this.http.get<SplitsMarketInfo[]>('/MarketInfo/upcomingSplitsMarket').subscribe(result => {
      this.splitsrows = result.map((prop, key) => {
        return {
          ...prop,
          date: this.getDateTime(new Date(prop.date)),
          updated: this.getDateTime(new Date(prop.updated)),
          id: key
        };
      });
      this.splitstemp = this.splitsrows;
    }, error => { console.log(error); });
  }

  private getUpcomingIposMarketInfo() {
    this.http.get<any>(`/MarketInfo/upcomingIposMarket`).subscribe(result => {
      if (result !== null) this.drawIposTable(result.rawData[0].viewData[0]);
      else document.getElementById('iposTable').innerHTML = 'No data available at the moment.';
    }, error => { console.log(error); });
  }

  public getDateTime(date: Date): string {
    return `${date.getFullYear()}-${date.getMonth()}-${date.getDate()}`;
  }

  public getUpcomingDividendsInfo($event) {
    let symbol: string = $event.target.value;
    this.http.get<DividendsInfo[]>(`/MarketInfo/upcomingDividends?symbol=${symbol}`).subscribe(result => {
      console.log(result);
      this.drawDividendsTable(result[0]);
    }, error => { console.log(error); });
  }

  private drawDividendsTable(data) {
    document.getElementById('dividendsTable').innerHTML = '';
    if ((data === undefined)) {
      document.getElementById('dividendsTable').innerHTML += 'No data avaiable at the moment.';
    }
    for (let key in data) {
      document.getElementById('dividendsTable').innerHTML += `<tr><td style="width: 50%;">${key.toUpperCase()}</td><td>${data[key]}</td></tr>`;
    }
  }

  private drawIposTable(prop) {
    let temp = '';
    temp += `<tr><td style="width: 50%;">Company</td><td>${prop.company}</td></tr>`;
    temp += `<tr><td style="width: 50%;">Symbol</td><td>${prop.symbol}</td></tr>`;
    temp += `<tr><td style="width: 50%;">Price</td><td>${prop.price}</td></tr>`;
    temp += `<tr><td style="width: 50%;">Shares</td><td>${prop.shares}</td></tr>`;
    temp += `<tr><td style="width: 50%;">Amount</td><td>${prop.amount}</td></tr>`;
    temp += `<tr><td style="width: 50%;">Float</td><td>${prop.float}</td></tr>`;
    temp += `<tr><td style="width: 50%;">Percent</td><td>${prop.percent}</td></tr>`;
    temp += `<tr><td style="width: 50%;">Market</td><td>${prop.market}</td></tr>`;
    temp += `<tr><td style="width: 50%;">Expected</td><td>${prop.expected}</td></tr>`;
    temp += `<tr><td style="width: 50%;">Latest Price</td><td>${prop.quote.latestPrice}</td></tr>`;
    temp += `<tr><td style="width: 50%;">Change Percent</td><td>${prop.quote.changePercent}</td></tr>`;
    document.getElementById('iposTable').innerHTML = temp;

  }

  public searchIntradayPriceForSymbol(symbol: string) {
    this.http.get<StockPrice[]>(`/StockPrices/intradayPrices?symbol=${symbol}`).subscribe(result => {
      document.getElementById("intradayPriceForOneSymbolContent").style.height = '200px';
      this.drawIntradayPriceForSymbolChart(result);
    }, error => {
      document.getElementById("noData").innerHTML = 'No Data';
    });
  }

  public entriesChange($event) {
    this.entries = $event.target.value;
  }

  public filterTable($event) {
    let val = $event.target.value;
    this.temp = this.rows.filter(function (d) {
      for (var key in d) {
        if (d[key].toLowerCase().indexOf(val) !== -1) {
          return true;
        }
      }
      return false;
    });
  }

  public filterSplitsTable($event) {
    let val = $event.target.value;
      this.splitstemp = this.splitsrows.filter(function (d) {
        if (d['symbol'].toLowerCase().indexOf(val) !== -1) {
          return true;
      }
      return false;
    });
  }

  public onActivate(event) {
    this.activeRow = event.row;
  }

  public onSplitsActivate(event) {
    this.activeSplitsRow = event.row;
  }

  public drawIntradayPriceForSymbolChart(data) {

    this.canvas = document.getElementById("intradayPriceForOneSymbol");
    this.ctx = this.canvas.getContext("2d");
    var gradientStroke = this.ctx.createLinearGradient(0, 230, 0, 50);

    gradientStroke.addColorStop(1, "rgba(29,140,248,0.2)");
    gradientStroke.addColorStop(0.4, "rgba(29,140,248,0.0)");
    gradientStroke.addColorStop(0, "rgba(29,140,248,0)");

    var myChart = new Chart(this.ctx, {
      type: "line",
      responsive: true,
      data: {
        labels: data.filter(item => item.average !== null).map(item => item.minute),
        datasets: [
          {
            label: "High",
            borderColor: "#51df98",
            borderWidth: 1,
            borderDash: [],
            borderDashOffset: 0.0,
            pointBackgroundColor: "#51df98",
            pointBorderColor: "rgba(255,255,255,0)",
            pointHoverBackgroundColor: "#be55ed",
            pointHoverBorderColor: 'rgba(255,255,255,1)',
            pointBorderWidth: 20,
            pointHoverRadius: 0,
            pointHoverBorderWidth: 15,
            pointRadius: 0,
            data: data.filter(item => item.high !== 0).map(item => item.high),
          },
          {
            label: "Average",
            borderColor: "#bf7cfc",
            borderWidth: 1,
            borderDash: [],
            borderDashOffset: 0.0,
            pointBackgroundColor: "#bf7cfc",
            pointBorderColor: "rgba(255,255,255,0)",
            pointHoverBackgroundColor: "#be55ed",
            pointHoverBorderColor: 'rgba(255,255,255,1)',
            pointBorderWidth: 20,
            pointHoverRadius: 0,
            pointHoverBorderWidth: 15,
            pointRadius: 0,
            data: data.filter(item => item.close !== 0).map(item => item.close),
          },
          {
            label: "Low",
            borderColor: "#de4758",
            borderWidth: 1,
            borderDash: [],
            borderDashOffset: 0.0,
            pointBackgroundColor: "#de4758",
            pointBorderColor: "rgba(255,255,255,0)",
            pointHoverBackgroundColor: "#be55ed",
            pointHoverBorderColor: 'rgba(255,255,255,1)',
            pointBorderWidth: 20,
            pointHoverRadius: 0,
            pointHoverBorderWidth: 15,
            pointRadius: 0,
            data: data.filter(item => item.low !== 0).map(item => item.low),
          },
        ]
      },
      options: this.gradientChartOptionsConfigurationPurple
    });
  }
}

interface StockPrice {
  symbol: string;
  date: string;
  minute: string;
  high: number;
  low: number;
  open: number;
  close: number;
  average: number;
  volume: number;
  notional: number;
  numberOfTrades: number;
  changeOverTime: number;
  marketOpen: number;
  marketClose: number;
  marketHigh: number;
  marketLow: number;
  marketAverage: number;
  marketVolume: number;
  marketNotional: number;
  marketNumberOfTrades: number;
  marketChangeOverTime: number;
}

interface IntradayPriceForMostPopularSymbols {
  SPY: StockPrice[],
  QQQ: StockPrice[],
  IWM: StockPrice[],
}

interface MarketInfo {
  symbol: string;
  reportDate: string;
}

interface DividendsInfo {
  exDate: string,
  paymentDate: string,
  recordDate: string,
  declaredDate: string,
  date: string,
  updated: string,
  amount: number,
  id: string,
  key: string,
  subkey: string,
  refid: number,
  flag: string,
  currency: string,
  description: string,
  frequency: string,
  symbol: string,
}

interface SplitsMarketInfo {
  declaredDate: string,
  description: string,
  exDate: string,
  date: number,
  fromFactor: number,
  ratio: number,
  refid: number,
  symbol: string,
  toFactor: number,
  id: string,
  key: string,
  subkey: string,
  updated: number,
}

interface IposInfo {

}
