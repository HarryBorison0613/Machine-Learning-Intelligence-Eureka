import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class GlobalVariable {
  public monthlyPay: string = "0";
  public annuallyPay: string = "0";
  public globalSearchSymbolName: string = 'Apple Inc.|AAPL';

  public setPrice(monthlyPay: string, annuallyPay: string) {
    this.monthlyPay = monthlyPay;
    this.annuallyPay = annuallyPay;
  }

  public getPrice() {
    return {
      monthlyPrice: this.monthlyPay,
      annualPrice: this.annuallyPay
    }
  }

  public setGlobalSearchSymbolName(symbolName: string) {
    this.globalSearchSymbolName = symbolName;
  }

  public getGlobalSearchSymbolName() {
    return this.globalSearchSymbolName;
  }
}
