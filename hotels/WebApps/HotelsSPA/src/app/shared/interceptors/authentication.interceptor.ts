import { HttpEvent, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, switchMap, take } from 'rxjs';
import { AppStateService } from '../app-state/app-state.service';
import { IAppState } from '../app-state/app-state';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
  private readonly whiteListUrls: string[] = [
    '/api/v1/Authentication/LogIn'
  ]

  constructor(private appStateService: AppStateService) {}

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
}
