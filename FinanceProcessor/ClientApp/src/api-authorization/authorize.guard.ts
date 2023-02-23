import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthorizeService } from './authorize.service';
import { tap } from 'rxjs/operators';
import { ApplicationPaths, QueryParameterNames } from './api-authorization.constants';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeGuard implements CanActivate {
  constructor(private authorize: AuthorizeService, private router: Router) {
  }
  canActivate(
    _next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
      const user = window.sessionStorage.getItem("auth-user");
      console.log("this is user",user);
      
      if(user==null){
        this.router.navigate(['/login']);
        return false;
      }else{
        return true;
      }
  }

  private handleAuthorization(isAuthenticated: boolean, state: RouterStateSnapshot) {
    const user = window.sessionStorage.getItem("auth-user");
    if(user==""){
      this.router.navigate(['/login']);
    }else{
      isAuthenticated=true;
    }
  }
}
