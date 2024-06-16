import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable, map, take } from "rxjs";
import { AppStateService } from "../app-state/app-state.service";
import { IAppState } from "../app-state/app-state";

@Injectable({
  providedIn: 'root'
})
export class NotAuthenticatedGuard implements CanActivate {
  public constructor(private appStateService: AppStateService, private routerService: Router) {}

  canActivate(route: ActivatedRouteSnapshot, 
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      return this.appStateService.getAppState().pipe(
        take(1),
        map((appState: IAppState) => {
          if(!appState.isEmpty()) {
            return true;
          }

          return this.routerService.createUrlTree(['/identity', 'login']);
        })
      );
  }
}
