import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { BehaviorSubject, catchError, filter, Observable, switchMap, take, throwError } from 'rxjs';
import { AppStateService } from '../app-state/app-state.service';
import { IAppState } from '../app-state/app-state';
import { PendingRatingFacadeService } from '../../rating/rating/domain/application-services/pendingrating-facade.service';

@Injectable()
export class RatingInterceptor implements HttpInterceptor {
  //private readonly whitelistUrls: string[] = ['/api/v1/Rating/pendingRatings/6'];

  private isRefreshing: boolean = false;
  private refreshedAccessTokenSubject: BehaviorSubject<string | null> = new BehaviorSubject<string | null>(null);

  constructor(private appStateService: AppStateService, private ratingService: PendingRatingFacadeService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    console.log("intercepting")
    /*if (this.isWhitelisted(request.url)) {
      return next.handle(request);
    }*/

    return this.appStateService.getAppState().pipe(
      take(1),
      switchMap((appState: IAppState) => {
        if (appState.accessToken !== undefined) {
          request = this.addToken(request, appState.accessToken);
        }
        console.log(appState.accessToken);

        return next.handle(request);
      }),
      catchError((err) => {
        return throwError(() => err);
      })
    );
  }

  private isWhitelisted(url: string): boolean {
    return true;
    //return this.whitelistUrls.some((whitelistedUrl: string) => url.includes(whitelistedUrl));
  }

  private addToken(request: HttpRequest<unknown>, accessToken: string): HttpRequest<unknown> {
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${accessToken}`,
      },
    });
  } 
}