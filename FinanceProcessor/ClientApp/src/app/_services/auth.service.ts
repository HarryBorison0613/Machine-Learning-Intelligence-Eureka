import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = 'https://machinelearningintelligence.com/User/';

export const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  login(UserName: string, Password: string): Observable<any> {
    return this.http.post(AUTH_API + 'Login', {
      UserName,
      Password
    }, httpOptions);
  }

  register( FirstName: string, LastName: string, Email: string, Password: string): Observable<any> {
    return this.http.put(AUTH_API + 'CreateUser', {
      FirstName,
      LastName,
      Email,
      Password
    }, httpOptions);
  }
}
