import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

const API_URL = 'https://machinelearningintelligence.com/User/';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(
    private http: HttpClient,
    private tokenStorage: TokenStorageService
  ) {}
  token = this.tokenStorage.getUser().token;

  httpOptions = {
    headers: new HttpHeaders({ Authorization: `Bearer ${this.token}` }),
  };

  createProfile(
    Id: string,
    email: string,
    firstName: string,
    lastName: string,
    address: string,
    aptSuite: string,
    city: string,
    postalCode: string,
    regionCode: string,
    country: string,
    aboutMe: string
  ): Observable<any> {
    return this.http.put(
      API_URL + 'profile',
      {
        Id,
        email,
        firstName,
        lastName,
        address,
        aptSuite,
        city,
        postalCode,
        regionCode,
        country,
        aboutMe,
      },
      this.httpOptions
    );
  }

  getUserInfo(userId: string): Observable<any> {
    return this.http.get(API_URL + 'get-user/' + userId, this.httpOptions);
  }

  getPublicContent(): Observable<any> {
    return this.http.get(API_URL + 'all', { responseType: 'text' });
  }

  getUserBoard(): Observable<any> {
    return this.http.get(API_URL + 'user', { responseType: 'text' });
  }

  getModeratorBoard(): Observable<any> {
    return this.http.get(API_URL + 'mod', { responseType: 'text' });
  }

  getAdminBoard(): Observable<any> {
    return this.http.get(API_URL + 'admin', { responseType: 'text' });
  }
}
