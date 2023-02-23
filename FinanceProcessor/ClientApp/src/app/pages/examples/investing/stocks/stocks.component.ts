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

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getIntradayPricesForMostPopularSymbol();
    this.getUpcomingEarningsMarketInfo();
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
      document.getElementById('tableForUpcomingEarningsMarket').innerHTML = this.generateTable(result);
    }, error => { document.getElementById("tableForUpcomingEarningsMarket").innerHTML = 'No Data'; });
  }

  private generateTable(data): string {
    if (data === undefined) return 'No Data';
    var result: string = '';
    result += '<thead><tr><th>Symbol</th><th>Datetime</th></tr></thead>';
    result += '<tbody>';
    data.map(item => {
      result += '<tr>' + '<td>' + item.symbol + '</td>' + '<td style="width: 55%">' + item.reportDate + '</td>' + '</tr>';
    });
    result += '</tbody>';
    return result;
  }

  public searchIntradayPriceForSymbol(symbol: string) {
    this.http.get<StockPrice[]>(`/StockPrices/intradayPrices?symbol=${symbol}`).subscribe(result => {
      this.drawIntradayPriceForSymbolChart(result);
    }, error => { document.getElementById("intradayPriceForOneSymbolContent").innerHTML = 'No Data'; });
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
            data: data.filter(item => item.average !== null).map(item => item.average),
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
  reportData: string;
}
