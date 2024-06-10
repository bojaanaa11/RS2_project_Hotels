import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILoginRequest } from '../models/login-request';
import { ILoginResponse } from '../models/login-response';
import { Observable } from 'rxjs';
import { ILogoutRequest } from '../models/logout-request';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private readonly url: string = "http://localhost:8000/api/v1/Authentication";

  constructor(private httpClient: HttpClient) { }

  public login(request: ILoginRequest): Observable<ILoginResponse> {
    return this.httpClient.post<ILoginResponse>(`${this.url}/LogIn`, request);
  }

  public logout(request: ILogoutRequest): Observable<Object> {
    return this.httpClient.post(`${this.url}/LogOut`, request);
  }
}
