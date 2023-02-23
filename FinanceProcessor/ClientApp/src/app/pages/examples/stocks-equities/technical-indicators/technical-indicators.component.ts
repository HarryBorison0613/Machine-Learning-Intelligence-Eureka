import { Component, OnInit } from "@angular/core";
import { Table } from "primeng/table";

import { StockService } from "../../../service/stockservice";
import { Chart } from '../../../domain/stock';
import { GlobalVariable } from "src/app/_services/global.variable";

@Component({
  selector: "stocks-equities-technical-indicators",
  templateUrl: "technical-indicators.component.html"
})
export class TechnicalIndicatorsComponent implements OnInit {
  symbols: any[];

  indicatorNames: any[];

  ranges: any[];

  selectedSymbol: string;

  selectedTechnicalIndicatorName: string;

  selectedTechnicalIndicatorRange: string;

  selectedTechnicalIndicatorLastIndicator: boolean;

  selectedTechnicalIndicatorOnly: boolean;
  
  technicalIndicators: string[];

  technicalIndicatorsLoading: boolean = true;

  charts: Chart[];
  
  filteredSymbols: any[];

  constructor( private stockService: StockService, private globalVariable: GlobalVariable ) {
    this.selectedSymbol = this.globalVariable.getGlobalSearchSymbolName();
    this.selectedTechnicalIndicatorName = 'Abs';
    this.selectedTechnicalIndicatorRange = 'Ytd';
    this.selectedTechnicalIndicatorLastIndicator = true;
    this.selectedTechnicalIndicatorOnly  = true;
   }

  ngOnInit() {
    this.getTechnicalIndicators(this.selectedSymbol, this.selectedTechnicalIndicatorName, this.selectedTechnicalIndicatorRange, this.selectedTechnicalIndicatorLastIndicator, this.selectedTechnicalIndicatorOnly);
    this.getExistingSymbols();
    
    this.indicatorNames = [
      { label: 'Indicator Name', value: 'Abs' },
      { label: 'Abs', value: 'Abs' },
      { label: 'Acos', value: 'Acos' },
      { label: 'Ad', value: 'Ad' },
      { label: 'Add', value: 'Add' },
      { label: 'Adosc', value: 'Adosc' },
      { label: 'Adx', value: 'Adx' },
      { label: 'adxr', value: 'adxr' },
      { label: 'Ao', value: 'Ao' },
      { label: 'Apo', value: 'Apo' },
      { label: 'Aroon', value: 'Aroon' },
      { label: 'Aroonosc', value: 'Aroonosc' },
      { label: 'Asin', value: 'Asin' },
      { label: 'Atan', value: 'Atan' },
      { label: 'Atr', value: 'Atr' },
      { label: 'Avgprice', value: 'Avgprice' },
      { label: 'Bbands', value: 'Bbands' },
      { label: 'Bop', value: 'Bop' },
      { label: 'Cci', value: 'Cci' },
      { label: 'Ceil', value: 'Ceil' },
      { label: 'Cmo', value: 'Cmo' },
      { label: 'Cos', value: 'Cos' },
      { label: 'Cosh', value: 'Cosh' },
      { label: 'Crossany', value: 'Crossany' },
      { label: 'Crossover', value: 'Crossover' },
      { label: 'Cvi', value: 'Cvi' },
      { label: 'Decay', value: 'Decay' },
      { label: 'Dema', value: 'Dema' },
      { label: 'Di', value: 'Di' },
      { label: 'Div', value: 'Div' },
      { label: 'Dm', value: 'Dm' },
      { label: 'Dpo', value: 'Dpo' },
      { label: 'Dx', value: 'Dx' },
      { label: 'Edecay', value: 'Edecay' },
      { label: 'Ema', value: 'Ema' },
      { label: 'Emv', value: 'Emv' },
      { label: 'Exp', value: 'Exp' },
      { label: 'Fisher', value: 'Fisher' },
      { label: 'Floor', value: 'Floor' },
      { label: 'Fosc', value: 'Fosc' },
      { label: 'Hma', value: 'Hma' },
      { label: 'Kama', value: 'Kama' },
      { label: 'Kvo', value: 'Kvo' },
      { label: 'Lag', value: 'Lag' },
      { label: 'Linreg', value: 'Linreg' },
      { label: 'Linregintercept', value: 'Linregintercept' },
      { label: 'Linregslope', value: 'Linregslope' },
      { label: 'Ln', value: 'Ln' },
      { label: 'Log10', value: 'Log10' },
      { label: 'Macd', value: 'Macd' },
      { label: 'Marketfi', value: 'Marketfi' },
      { label: 'Mass', value: 'Mass' },
      { label: 'Max', value: 'Max' },
      { label: 'Md', value: 'Md' },
      { label: 'Medprice', value: 'Medprice' },
      { label: 'Mfi', value: 'Mfi' },
      { label: 'Min', value: 'Min' },
      { label: 'Mom', value: 'Mom' },
      { label: 'Msw', value: 'Msw' },
      { label: 'Mul', value: 'Mul' },
      { label: 'Natr', value: 'Natr' },
      { label: 'Nvi', value: 'Nvi' },
      { label: 'Obv', value: 'Obv' },
      { label: 'Ppo', value: 'Ppo' },
      { label: 'Psar', value: 'Psar' },
      { label: 'Pvi', value: 'Pvi' },
      { label: 'Qstick', value: 'Qstick' },
      { label: 'Roc', value: 'Roc' },
      { label: 'Rocr', value: 'Rocr' },
      { label: 'Round', value: 'Round' },
      { label: 'Rsi', value: 'Rsi' },
      { label: 'Sin', value: 'Sin' },
      { label: 'Sinh', value: 'Sinh' },
      { label: 'Sma', value: 'Sma' },
      { label: 'Sqrt', value: 'Sqrt' },
      { label: 'Stddev', value: 'Stddev' },
      { label: 'Stderr', value: 'Stderr' },
      { label: 'Stoch', value: 'Stoch' },
      { label: 'Stochrsi', value: 'Stochrsi' },
      { label: 'Sub', value: 'Sub' },
      { label: 'Sum', value: 'Sum' },
      { label: 'Tan', value: 'Tan' },
      { label: 'Tanh', value: 'Tanh' },
      { label: 'Tema', value: 'Tema' },
      { label: 'Todeg', value: 'Todeg' },
      { label: 'Torad', value: 'Torad' },
      { label: 'Tr', value: 'Tr' },
      { label: 'Trima', value: 'Trima' },
      { label: 'Trix', value: 'Trix' },
      { label: 'Trunc', value: 'Trunc' },
      { label: 'Tsf', value: 'Tsf' },
      { label: 'Typprice', value: 'Typprice' },
      { label: 'Ultosc', value: 'Ultosc' },
      { label: 'Var', value: 'Var' },
      { label: 'Vhf', value: 'Vhf' },
      { label: 'Vidya', value: 'Vidya' },
      { label: 'Volatility', value: 'Volatility' },
      { label: 'Vosc', value: 'Vosc' },
      { label: 'Vwma', value: 'Vwma' },
      { label: 'Wad', value: 'Wad' },
      { label: 'Wcprice', value: 'Wcprice' },
      { label: 'Wilders', value: 'Wilders' },
      { label: 'Willr', value: 'Willr' },
      { label: 'Wma', value: 'Wma' },
      { label: 'Zlema', value: 'Zlema' },
    ];
    this.ranges = [
      { label: 'Range', value: 'Ytd' },
      { label: 'FiveDay', value: 'FiveDay' }, 
      { label: 'OneMonth', value: 'OneMonth' }, 
      { label: 'ThreeMonths', value: 'ThreeMonths' }, 
      { label: 'SixMonths', value: 'SixMonths' }, 
      { label: 'Ytd', value: 'Ytd' }, 
      { label: 'OneYear', value: 'OneYear' }, 
      { label: 'TwoYears', value: 'TwoYears' }, 
      { label: 'FiveYears', value: 'FiveYears' }, 
      { label: 'Max', value: 'Max' }, 
    ];
  }

  getTechnicalIndicators(query, indicatorName, range, lastIndicator, indicatorOnly) {
    this.technicalIndicatorsLoading = true;
    let symbol = query.split('|')[1];
    this.stockService.getTechnicalIndicators(symbol, indicatorName, range, lastIndicator, indicatorOnly).then(res => {
      this.technicalIndicators = res.indicator;
      this.charts = res.chart;
      this.technicalIndicatorsLoading = false;
    }).catch(() => {
      this.technicalIndicatorsLoading = false;
      this.technicalIndicators = [];
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

  clear(table: Table) {
      table.clear();
  }

  cancel() {
    this.selectedSymbol = '';
  }
}
