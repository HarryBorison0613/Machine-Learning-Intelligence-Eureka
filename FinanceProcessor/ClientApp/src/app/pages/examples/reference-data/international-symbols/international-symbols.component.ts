import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { ErrorService } from "src/app/pages/service/errorservice";
import { ParameterService } from "src/app/pages/service/parameterservice";
import { Symbol } from "src/app/pages/domain/reference";

@Component({
  selector: "reference-data-international-symbols",
  templateUrl: "international-symbols.component.html",
  styleUrls: ["./international-symbols.css"]
})
export class InternationalSymbolsComponent implements OnInit {

  countries: any[];
  exchanges: Exchange[];
  selectedCountry: string;
  symbolsForRegion: Symbol[];
  regionLoading: boolean = false;
  filteredCountries: any[];
  filteredExchanges: any[];

  symbolsForExchange: Symbol[];
  selectedExchange: string;
  exchangeLoading: boolean = false;

  constructor( 
    private http: HttpClient, 
    private errors: ErrorService, 
    private parameterService: ParameterService,
    @Inject('BASE_URL') private baseUrl: string, 
    ) {
    this.selectedCountry = 'United States(us)';
    this.selectedExchange = 'tse';
    this.countries = this.parameterService.getCountries();
  }

  ngOnInit() {
    this.getSymbolsForRegion(this.selectedCountry);
    this.getSymbolsForExchange(this.selectedExchange);
    this.getExistingInternationalExchanges();
  }

  getExistingInternationalExchanges() {
    this.http.get<Exchange[]>(this.baseUrl + `References/internationalExchanges`).subscribe(res => {
      this.exchanges = res;
    }, (err) => {
      console.log(err);
    });
  }

  getSymbolsForRegion(country) {
    let countryCode = country.split('(')[1].slice(0,2);
    this.regionLoading = true;
    this.http.get<Symbol[]>(this.baseUrl + `References/symbolsInternationalRegionAsync?region=${countryCode}`).subscribe(res => {
      this.symbolsForRegion = res;
      this.regionLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.regionLoading = false;
    });
  }

  filterCountry(event) {
    let filtered: any[] = [];
    let query = event.query;
    for (let i = 0; i < this.countries.length; i++) {
      let country = this.countries[i];
      if (country.name.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(country.name + '(' + country.code.toLowerCase() + ')');
      }
    }
    this.filteredCountries = filtered;
  }

  getSymbolsForExchange(exchange) {
    this.exchangeLoading = true;
    this.http.get<Symbol[]>(this.baseUrl + `References/symbolsInternationalExchangeAsync?exchange=${exchange}`).subscribe(res => {
      this.symbolsForExchange = res;
      this.exchangeLoading = false;
    }, (err) => {
      if(err.status === 500) {
        this.errors.showErr500Msg();
      }
      this.exchangeLoading = false;
    });
  }

  filterExchange(event) {
    let filtered: any[] = [];
    let query = event.query;
    for (let i = 0; i < this.exchanges.length; i++) {
      let exchange = this.exchanges[i].exchange;
      if (exchange.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(exchange);
      }
    }
    this.filteredExchanges = filtered;
  }
}

interface Exchange {
  exchange: string;
  region: string;
  description: string;
  mic: string;
  exchangeSuffix: string;
}
