import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Roles } from '../models/static/roles';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(private authService: AuthService,
    private router: Router,
    ){
      //toastr.options.timeOut = 30000;      
  }
  
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    
    let role = this.authService.getRoleFromToken();
    
    if(role !== Roles.Admin){        
      //toastr.error("You aren't allowed", 'Error', {timeOut: 5000});
      this.router.navigate(['login'], { queryParams: {returnUrl: state.url}});
      return false;
     }
     else{
      return true;
     }
  }
  
}
