import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AppState, IAppState } from '../../shared/app-state/app-state';
import { AppStateService } from '../../shared/app-state/app-state.service';
import { Role } from '../../shared/app-state/role';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {
  public appState$: Observable<IAppState>;

  constructor(private appStateService: AppStateService) {
    this.appState$ = this.appStateService.getAppState();
  }

  ngOnInit(): void {
  }

  public getNavBarTitle(appState: IAppState): string {
    if (appState.firstName !== undefined && appState.lastName !== undefined) {
      return {
        title: `Welcome to Hotels, `,
        name: `${appState.firstName} ${appState.lastName}`
      };
    }

    return {
      title: `Hotels`,
      name: ''
    };
  }

  public canShowReservations(appState: IAppState): boolean {
    return appState.hasRole(Role.Guest);
  }

  public canShowAdminPanel(appState: IAppState): boolean {
    return appState.hasRole(Role.Hotel);
  }

  public canShowRatingPanel(appState: IAppState): boolean {
    return appState.hasRole(Role.Guest);
  }

  public userLoggedIn(appState: IAppState): boolean {
    return !appState.isEmpty();
  }

  public userLoggedOut(appState: IAppState): boolean {
    return appState.isEmpty();
  }
}
