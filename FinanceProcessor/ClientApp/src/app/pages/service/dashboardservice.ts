import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Collection, MarketVolume, SectorPerformance } from '../domain/stock';

@Injectable()
export class DashboardService {

    constructor(private http: HttpClient) { }

    getGainers(limit) {
        return this.http.get<Collection[]>(`/MarketInfo/list?listType=Gainers&displayPercent=true&listLimit=${limit}`)
            .toPromise()
            .then(result => <Collection[]>result);
    }

    getLosers(limit) {
        return this.http.get<Collection[]>(`/MarketInfo/list?listType=Losers&displayPercent=true&listLimit=${limit}`)
            .toPromise()
            .then(result => <Collection[]>result);
    }

    getSectors() {
        return this.http.get<SectorPerformance[]>('/MarketInfo/sectorPerformance')
            .toPromise()
            .then(result => <SectorPerformance[]>result);
    }

    getVolumes() {
        return this.http.get<MarketVolume[]>('/MarketInfo/marketVolumeUSA')
            .toPromise()
            .then(result => <MarketVolume[]>result);
    }

    getMarkets() {
      return this.http.get<MarketVolume[]>('/MarketInfo/markets')
          .toPromise()
          .then(result => <MarketVolume[]>result);
    }

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

    public gradientChartOptionsConfigurationBlue = {
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

    public gradientChartOptionsConfigurationRed = {
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
    public gradientChartOptionsConfigurationWithTooltipRed: any = {
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
          mode: "nearest",
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
              color: "rgba(29,140,248,0.0)",
              zeroLineColor: "transparent"
              },
              ticks: {
              padding: 20,
              fontColor: "#aaaaaa"
              }
          }
          ],
  
          xAxes: [
          {
              barPercentage: 1.6,
              gridLines: {
              drawBorder: false,
              color: "rgba(233,32,16,0.1)",
              zeroLineColor: "transparent"
              },
              ticks: {
              padding: 20,
              fontColor: "#aaaaaa"
              }
          }
          ]
      }
  };
  
  public gradientChartOptionsConfigurationWithTooltipOrange: any = {
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
          mode: "nearest",
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
              color: "rgba(29,140,248,0.0)",
              zeroLineColor: "transparent"
              },
              ticks: {
              padding: 0,
              fontColor: "#aaaaaa"
              }
          }
          ],
  
          xAxes: [
          {
              barPercentage: 1.6,
              gridLines: {
              drawBorder: false,
              color: "rgba(220,53,69,0.1)",
              zeroLineColor: "transparent"
              },
              ticks: {
              padding: 0,
              fontColor: "#aaaaaa"
              }
          }
          ]
      }
  };
  
  public gradientChartOptionsConfigurationWithTooltipGreen: any = {
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
      mode: "nearest",
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
          color: "rgba(29,140,248,0.0)",
          zeroLineColor: "transparent"
          },
          ticks: {
          padding: 0,
          fontColor: "#aaaaaa"
          }
      }
      ],
  
      xAxes: [
      {
          barPercentage: 1.6,
          gridLines: {
          drawBorder: false,
          color: "rgba(0,242,195,0.1)",
          zeroLineColor: "transparent"
          },
          ticks: {
          padding: 0,
          fontColor: "#aaaaaa"
          }
      }
      ]
  }
  };
  
  public gradientBarChartConfiguration: any = {
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
      mode: "nearest",
      intersect: 0,
      position: "nearest"
  },
  responsive: true,
  scales: {
      yAxes: [
      {
          gridLines: {
          drawBorder: false,
          color: "rgba(29,140,248,0.1)",
          zeroLineColor: "transparent"
          },
          ticks: {
          suggestedMin: 60,
          suggestedMax: 120,
          padding: 20,
          fontColor: "#1f8ef1"
          }
      }
      ],
  
      xAxes: [
      {
          gridLines: {
          drawBorder: false,
          color: "rgba(29,140,248,0.1)",
          zeroLineColor: "transparent"
          },
          ticks: {
          padding: 20,
          fontColor: "#1f8ef1"
          }
      }
      ]
  }
  };
}
