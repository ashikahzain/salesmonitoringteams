import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authservice: AuthService, private route: Router) { }
  canActivate(
    next: ActivatedRouteSnapshot): boolean {

    //expected role vs curret role
    //routes  login
    const expectedRole = next.data.role;
    const currentRole = localStorage.getItem('ACCESS_ROLE');

    //CHECK
    if (currentRole !== expectedRole) {
      this.route.navigateByUrl('login');
      return false;
    }
    return true;
  }

}
