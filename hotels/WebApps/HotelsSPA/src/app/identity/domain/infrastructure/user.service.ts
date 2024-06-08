import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, switchMap, take } from 'rxjs';
import { IUserDetails } from '../models/user-details';
import { AppStateService } from '../../../shared/app-state/app-state.service';
import { IAppState } from '../../../shared/app-state/app-state';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient, private appStateService: AppStateService) { }

  public getUserDetails(username: string): Observable<IUserDetails> {
    return this.appStateService.getAppState().pipe(
      take(1),
      switchMap((appState: IAppState) => {
        const accessToken: string | undefined = appState.accessToken;

        const headers: HttpHeaders = new HttpHeaders().append('Authorization', `Bearer ${accessToken}`);

        return this.httpClient.get<IUserDetails>(`http://localhost:8000/api/v1/User/${username}`, { headers: headers });  
      })
    );
  }
}
