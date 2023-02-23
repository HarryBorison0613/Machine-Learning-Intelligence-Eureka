import { Component, OnInit, Inject } from "@angular/core";
import { ToastrService } from "ngx-toastr";

import { HttpClient } from "@angular/common/http";

@Component({
  selector: "reference-data-us-holidays-and-trading-dates",
  templateUrl: "us-holidays-and-trading-dates.component.html",
  styleUrls: ["./us-holidays-and-trading-dates.css"]
})
export class USHolidaysandTradingDatesComponent implements OnInit {
  types: string[];

  directions: string[];
  
  holidays: Holiday[];

  loading: boolean = false;

  constructor( 
    private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, public toastr: ToastrService ) {
    //Toast shows
    this.toastr.show(
      '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
      'Please input parameters to get search result.',
      {
        timeOut: 3500,
        closeButton: true,
        enableHtml: true,
        toastClass: "alert alert-info alert-with-icon",
        positionClass: "toast-top-right"
      }
    );
   }

  ngOnInit() {
    this.types = ["Trade", "Holiday"];
    this.directions = ["Next", "Last"];
  }

  getHolidaysAndTradingDatesUs(type, direction, last, start) {
    const startDate = (new Date(start)).toISOString().slice(0, 10);
    this.loading = true;
    this.http.get<Holiday[]>(this.baseUrl + `References/holidaysAndTradingDatesUS?type=${type}&direction=${direction}&last=${last}&startDate=${startDate}`)
    .subscribe(result => {
      this.holidays = result;
      this.loading = false;
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
      this.loading = false;
    });
  }
}

interface Holiday {
  date: string | Date;
  settlementDate: string | Date;
}