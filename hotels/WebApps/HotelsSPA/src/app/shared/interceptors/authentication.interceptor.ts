import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, catchError, filter, switchMap, take, throwError } from 'rxjs';
import { AppStateService } from '../app-state/app-state.service';
import { IAppState } from '../app-state/app-state';
import { AuthenticationFacadeService } from '../../identity/domain/application-services/authentication-facade.service';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
  private readonly whiteListUrls: string[] = [
    '/api/v1/Authentication/LogIn',
    '/api/v1/Authentication/Refresh'
  ]

  private isRefreshing: boolean = false;
  private refreshedAccessTokenSubject: BehaviorSubject<string | null> = new BehaviorSubject<string | null>(null);

  constructor(private appStateService: AppStateService, private authenticationSerice: AuthenticationFacadeService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if(this.isWhiteListed(request.url)) {
      return next.handle(request);
    }

    return this.appStateService.getAppState().pipe(
      take(1),
      switchMap((appState: IAppState) => {
        if(appState.accessToken !== undefined) {
          request = this.addToken(request, appState.accessToken);
        }

        return next.handle(request);
      }),
      catchError((err) => {
        if(err instanceof HttpErrorResponse && err.status === 401) {
          return this.handle401Error(request, next);
        } 

        return throwError(() => err);
      })
    );
  }

  private isWhiteListed(url: string): boolean {
    return this.whiteListUrls.some((whiteListedUrl: string) => url.includes(whiteListedUrl));
  }

  private addToken(request: HttpRequest<unknown>, accessToken: string): HttpRequest<unknown> {
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${accessToken}`,
      }
    })
  }

  private handle401Error(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if(!this.isRefreshing) {
      this.isRefreshing = true;
      this.refreshedAccessTokenSubject.next(null);

      return this.authenticationSerice.refreshToken().pipe(
        switchMap((accessToken: string | null) => {
          if(accessToken === null) {
            return throwError(() => Error("Refresh token flow failed."));
          }

          this.isRefreshing = false;
          this.refreshedAccessTokenSubject.next(accessToken);
          return next.handle(this.addToken(request, accessToken));
        })
      )
    } 

    return this.refreshedAccessTokenSubject.pipe(
      filter((token: string | null) => token !== null),
      take(1),
      switchMap((accessToken: string | null) => next.handle(this.addToken(request, accessToken as string)))
    )
  }
}
