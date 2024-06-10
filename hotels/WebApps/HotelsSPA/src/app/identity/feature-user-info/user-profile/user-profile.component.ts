import { Component, OnInit } from '@angular/core';
import { AppStateService } from '../../../shared/app-state/app-state.service';
import { IAppState } from '../../../shared/app-state/app-state';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent implements OnInit {
  public appState$: Observable<IAppState>;

  constructor(private appStateService: AppStateService) {
    this.appState$ = this.appStateService.getAppState();
  }

  ngOnInit(): void {
  }

}
