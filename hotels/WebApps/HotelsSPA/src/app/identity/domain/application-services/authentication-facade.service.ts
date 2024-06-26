import { Injectable } from '@angular/core';
import { AuthenticationService } from '../infrastructure/authentication.service';
import { ILoginRequest } from '../models/login-request';
import { Observable, catchError, map, of, switchMap, take } from 'rxjs';
import { ILoginResponse } from '../models/login-response';
import { AppStateService } from '../../../shared/app-state/app-state.service';
import { JwtService } from '../../../shared/jwt/jwt.service';
import { JwtPayloadKeys } from '../../../shared/jwt/jwt-payload-keys';
import { UserFacadeService } from './user-facade.service';
import { IUserDetails } from '../models/user-details';
import { IAppState } from '../../../shared/app-state/app-state';
import { ILogoutRequest } from '../models/logout-request';
import { IRefreshTokenRequest } from '../models/refresh-token-request';
import { IRefreshTokenResponse } from '../models/refresh-token-response';
import { IRegisterGuestRequest } from '../models/register-guest-request';
import { IRegisterHotelRequest } from '../models/register-hotel-request';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationFacadeService {

  constructor(private authenticationService: AuthenticationService, private appStateService: AppStateService, 
    private jwtService: JwtService, private userService: UserFacadeService) { }

  public login(username: string, password: string): Observable<boolean> {
    const request: ILoginRequest = { username, password };

    return this.authenticationService.login(request).pipe(
      switchMap((loginResponse: ILoginResponse) => {
        this.appStateService.setAccessToken(loginResponse.accessToken);
        this.appStateService.setRefreshToken(loginResponse.refreshToken);

        const payload = this.jwtService.parsePayload(loginResponse.accessToken);
        this.appStateService.setUsername(payload[JwtPayloadKeys.Username]);
        this.appStateService.setEmail(payload[JwtPayloadKeys.Email]);
        this.appStateService.setRoles(payload[JwtPayloadKeys.Role]);

        return this.userService.getUserDetails(payload[JwtPayloadKeys.Username]);
      }),
      map((userDetails: IUserDetails) => {
        this.appStateService.setFirstName(userDetails.firstName);
        this.appStateService.setLastName(userDetails.lastName);
        this.appStateService.setUserId(userDetails.id);

        return true;
      }),
      catchError((err) => {
        console.log(err);
        this.appStateService.clearAppState();
        return of(false);
      })
    );
  }

  public logout(): Observable<boolean> {
    return this.appStateService.getAppState().pipe(
      take(1),
      map((appState: IAppState) => {
        const request: ILogoutRequest = { userName: appState.username as string, refreshToken: appState.refreshToken as string };
        return request;
      }),
      switchMap( (request: ILogoutRequest) => this.authenticationService.logout(request)),
      map(() => {
        this.appStateService.clearAppState();
        return true;
      }),
      catchError((err) => {
        console.error(err);
        return of(false);
      })
    );
  }

  public refreshToken(): Observable<string | null> {
    return this.appStateService.getAppState().pipe(
      take(1),
      map((appState: IAppState) => {
        const request: IRefreshTokenRequest = { userName: appState.username as string, refreshToken: appState.refreshToken as string };
        return request;
      }),
      switchMap( (request: IRefreshTokenRequest) => this.authenticationService.refreshToken(request)),
      map((response: IRefreshTokenResponse) => {
        this.appStateService.setAccessToken(response.accessToken);
        this.appStateService.setRefreshToken(response.refreshToken);

        return response.accessToken;
      }),
      catchError((err) => {
        console.log(err);
        this.appStateService.clearAppState();
        return of(null);
      })
    );
  }

  public registerAsGuest(firstName: string, lastName: string, username: string, password: string, email: string, phoneNumber: string): Observable<boolean> {
    const request: IRegisterGuestRequest = { 
      firstName,
      lastName,
      username, 
      password,
      email,
      phoneNumber
    };

    return this.authenticationService.registerAsGuest(request).pipe(
      map(() => {
        return true;
      }),
      catchError((err) => {
          console.log(err);
          this.appStateService.clearAppState();
          return of(false);
      })
    );
  }

  public registerAsHotel(firstName: string, lastName: string, username: string, password: string, email: string, phoneNumber: string): Observable<boolean> {
    const request: IRegisterHotelRequest = { 
      firstName,
      lastName,
      username, 
      password,
      email,
      phoneNumber
    };

    return this.authenticationService.registerAsHotel(request).pipe(
      map(() => {
        return true;
      }),
      catchError((err) => {
          console.log(err);
          this.appStateService.clearAppState();
          return of(false);
      })
    );
  }
}
