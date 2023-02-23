import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: "market-crypto",
  templateUrl: "crypto.component.html"
})

export class CryptoComponent implements OnInit {
  public datasets: News;
  public data: any;
  public tableData: any;
  public clicked: boolean = true;
  public clicked1: boolean = false;
  public clicked2: boolean = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<News>(baseUrl + 'News/lastNewsForMostPopularSymbols').subscribe(result => {
      this.datasets = result;
      document.getElementById('tableForMostPopularSymbols').innerHTML = this.generateTable(result.SPY);
    }, error => console.error(error));
  }

  ngOnInit() { }  

  public updateOptions(): void {
    this.tableData = this.data;
    document.getElementById('tableForMostPopularSymbols').innerHTML = this.generateTable(this.tableData);
  }

  public generateTable(data): string {
    if (data === undefined) return 'No Data';
    var result: string = '';
    result += '<thead><tr><th>Symbol</th><th>Headline</th><th>Datetime</th></tr></thead>';
    result += '<tbody>';
    data.map(item => {
      result += '<tr>' + '<td>' + item.symbol + '</td>' + '<td style="width: 55%">' + this.handleHeadline(item.headline) + `<a href=${item.url}>` + '<i class=" tim-icons icon-attach-87 "> </i>' + '</a></td>' + '<td>' + this.getDateTime(new Date(item.datetime)) + '</td>' + '</tr>';
    });
    result += '</tbody>';
    return result;
  }

  public handleHeadline(headline: string): string {
    if (headline.length < 40) return headline;
    return `${headline.slice(0, 40)}...`;
  }

  public getDateTime(date: Date): string {
    return `${date.getFullYear()}-${date.getMonth()}-${date.getDate()} ${date.getHours()}:${date.getMinutes()}:${date.getSeconds()}`;
  }

  public searchForSymbol(searchItem: string) {
    this.http.get<News>(`/News/lastNews?symbol=${searchItem}`).subscribe(result => {
    document.getElementById('tableForLastNews').innerHTML = this.generateTable(result);
    }, error => { document.getElementById('tableForLastNews').innerHTML = 'No Data' });
  }
}

interface NewsPiece{
  symbol: string;
  datetime: string;
  headline: string;
  source: string;
  url: string;
  summary: string;
  related: string;
  image: string;
  lang: string;
  hasPaywall: boolean;
}

interface News {
  SPY: NewsPiece[]|undefined,
  IWM: NewsPiece[]|undefined,
  QQQ: NewsPiece[]|undefined,
}
