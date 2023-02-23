import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

const PAY_API = 'https://machinelearningintelligence.com/Payment/';

@Injectable({
  providedIn: 'root',
})
export class PaymentService {
  constructor(
    private http: HttpClient,
    private tokenStorage: TokenStorageService
  ) {}
  token = this.tokenStorage.getUser().token;

  httpOptions = {
    headers: new HttpHeaders({ Authorization: `Bearer ${this.token}` }),
  };

  createorder(
    application_context: any,
    purchase_units: any,
    claimed_role: string
  ): Observable<any> {
    return this.http.post(
      PAY_API + 'createorder',
      {
        application_context,
        purchase_units,
        claimed_role,
      },
      this.httpOptions
    );
  }

  paytheorder(userId: string, orderId: string): Observable<any> {
    return this.http.post(
      PAY_API + 'paytheorder/' + orderId + '/' + userId,
      {},
      this.httpOptions
    );
  }

  createPlan(
    requested_role: string,
    image_url: string,
    home_url: string
  ): Observable<any> {
    return this.http.post(
      PAY_API + 'createplan',
      {
        requested_role,
        image_url,
        home_url,
      },
      this.httpOptions
    );
  }

  startSubscription(
    plan_id: string,
    subscriber: any,
    locale: string,
    return_url: string,
    cancel_url: string
  ): Observable<any> {
    return this.http.post(
      PAY_API + 'subscription',
      {
        plan_id,
        subscriber,
        locale,
        return_url,
        cancel_url,
      },
      this.httpOptions
    );
  }
}
