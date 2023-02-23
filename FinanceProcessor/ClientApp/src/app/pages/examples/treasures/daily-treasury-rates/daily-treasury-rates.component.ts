import { Component, OnInit, Inject } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "treasures-daily-treasury-rates",
  templateUrl: "daily-treasury-rates.component.html"
})
export class DailyTreasuryRatesComponent implements OnInit {

  selectedDailyTreasuryRatesDatapointsSymbol: string;
  datapoints: DataPoint[];
  timeseries: TimeSeries[];
  dailyTreasuryRatesDataPointsLoading: boolean = false;
  dailyTreasuryRatesTimeSeriesLoading: boolean = false;
  symbols: any[];
  filteredSymbols: any[];

  constructor( private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, public toastr: ToastrService ) {
    this.selectedDailyTreasuryRatesDatapointsSymbol = "DGS30";
   }

  ngOnInit() {
    this.getDailyTreasuryRates(this.selectedDailyTreasuryRatesDatapointsSymbol);
    this.symbols = [
      {label: "Symbol", value: "DGS30" },
      {label: "DGS30 | 30 Year constant maturity rate", value: "DGS30" },
      {label: "DGS20 | 20 Year constant maturity rate", value: "DGS20" },
      {label: "DGS10 | 10 Year constant maturity rate", value: "DGS10" },
      {label: "DGS5 | 5 Year constant maturity rate", value: "DGS5" },
      {label: "DGS2 | 2 Year constant maturity rate", value: "DGS2" },
      {label: "DGS1 | 1 Year constant maturity rate", value: "DGS1" },
      {label: "DGS6MO | 6 Month constant maturity rate", value: "DGS6MO" },
      {label: "DGS3MO | 3 Month constant maturity rate", value: "DGS3MO" },
      {label: "DGS1MO | 1 Month constant maturity rate", value: "DGS1MO" }
    ]
  }

  getDailyTreasuryRates(symbol) {
    this.getDailyTreasuryRatesDatapoints(symbol);
    this.getDailyTreasuryRatesTimeSeries(symbol);
  }

  getDailyTreasuryRatesDatapoints(symbol) {
    this.dailyTreasuryRatesDataPointsLoading = true;
    this.datapoints = [];
    this.http.get<any>(this.baseUrl + `Treasuries/dataPoints?symbol=${symbol}`).subscribe(result => {
      this.datapoints.push({ rate: result });
      this.dailyTreasuryRatesDataPointsLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.toastr.show(
          '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
          'Network connection failed. Please check network connection',
          {
            timeOut: 4000,
            closeButton: true,
            enableHtml: true,
            toastClass: "alert alert-danger alert-with-icon",
            positionClass: "toast-top-right"
          }
        );
      }
      this.dailyTreasuryRatesDataPointsLoading = false;
    });
  }

  getDailyTreasuryRatesTimeSeries(symbol) {
    this.dailyTreasuryRatesTimeSeriesLoading = true;
    this.http.get<TimeSeries[]>(this.baseUrl + `Treasuries/timeSeries?symbol=${symbol}`).subscribe(result => {
      this.timeseries = result;
      this.dailyTreasuryRatesTimeSeriesLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.toastr.show(
          '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
          'Network connection failed. Please check network connection',
          {
            timeOut: 4000,
            closeButton: true,
            enableHtml: true,
            toastClass: "alert alert-danger alert-with-icon",
            positionClass: "toast-top-right"
          }
        );
      }
      this.dailyTreasuryRatesTimeSeriesLoading = false;
    });
  }
}

interface DataPoint {
  rate: number;
}

interface TimeSeries {
  dataId: string;
  date: string;
  frequency: string;
  value: number;
  id: string;
  key: string;
  subkey: string;
  updated: string | Date;
}
