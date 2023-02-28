import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, CanLoad, Route, UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import {  UserFront } from '../models/user-front.model';
import { SubSink } from 'subsink';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class PagesGuard implements CanActivate, CanActivateChild, CanLoad {

  subs: SubSink = new SubSink();
  _usuarioFront: UserFront;
  _estaLogeado : boolean;
  
  constructor(
    private authService: AuthService,
    private router: Router
  ){

    this.subs.add(
      this.authService.usuarioChanged$
          .subscribe((usuarioFront: UserFront) => {
             
              this._usuarioFront = { ...usuarioFront };
          }));


          this.subs.add(
            this.authService.estaLogeadoChanged$
                .subscribe((estaLogeado: boolean) => {
                   
                    this._estaLogeado = estaLogeado ;
                }));

  }


  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
   

      return new Promise((resolve) => {
        if ( this._estaLogeado) {
                  
             this.router.navigate(['/sistema']);
            
          resolve(false);
        } else {
          
          resolve(true);
        }
      });

     
  }
  canActivateChild(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return true;
  }
  canLoad(
    route: Route,
    segments: UrlSegment[]): Observable<boolean> | Promise<boolean> | boolean {
    return true;
  }
}
