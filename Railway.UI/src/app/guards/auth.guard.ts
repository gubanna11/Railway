import { Injectable } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
//import * as toastr from 'toastr';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private auth: AuthService,
    private router: Router,
    ){
      //toastr.options.timeOut = 3000;      
  }
  
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if(this.auth.isAuthenticated()){
      return true;
    }      

    //toastr.error('Log in', 'Error', {timeOut: 5000});
    this.router.navigate(['login'], { queryParams: {returnUrl: state.url}});
    return false;
  }
  
}
