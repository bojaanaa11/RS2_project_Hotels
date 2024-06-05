import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { AppState, IAppState } from './app-state';
import { Role } from './role';
import { LocalStorageService } from '../local-storage/local-storage.service';
import { LocalStorageKeys } from '../local-storage/local-storage-keys';

@Injectable({
  providedIn: 'root'
})
export class AppStateService {
  private appState: IAppState = new AppState();
  private appStateSubject: BehaviorSubject<IAppState> = new BehaviorSubject<IAppState>(this.appState);
  private appStateObservable: Observable<IAppState> = this.appStateSubject.asObservable();

  constructor(private localStorageService: LocalStorageService) { 
    this.restoreFromLocalStorage();
  }

  public getAppState(): Observable<IAppState> {
    return this.appStateObservable;
  }

  setAccessToken(accessToken: string): void {
    this.appState = this.appState.clone();
    this.appState.accessToken = accessToken;
    this.appStateSubject.next(this.appState);
    this.localStorageService.set(LocalStorageKeys.AppState, this.appState);
  }

  setRefreshToken(refreshToken: string): void {
    this.appState = this.appState.clone();
    this.appState.refreshToken = refreshToken;
    this.appStateSubject.next(this.appState);
    this.localStorageService.set(LocalStorageKeys.AppState, this.appState);
  }

  setUsernameToken(username: string): void {
    this.appState = this.appState.clone();
    this.appState.username = username;
    this.appStateSubject.next(this.appState);
    this.localStorageService.set(LocalStorageKeys.AppState, this.appState);
  }

  setRolesToken(roles: Role | Role[]): void {
    this.appState = this.appState.clone();
    this.appState.roles = roles;
    this.appStateSubject.next(this.appState);
    this.localStorageService.set(LocalStorageKeys.AppState, this.appState);
  }

  private restoreFromLocalStorage(): void {
    const appState: IAppState | null = this.localStorageService.get(LocalStorageKeys.AppState);
    if(appState !== null) {
      this.appState = new AppState(appState.accessToken, appState.refreshToken, appState.username, appState.roles);
      this.appStateSubject.next(this.appState);
    }
  }
}
