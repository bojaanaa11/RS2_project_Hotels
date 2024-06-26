import { Component, OnInit } from '@angular/core';
import { AuthenticationFacadeService } from '../../domain/application-services/authentication-facade.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent implements OnInit {

  public logoutSuccess$: Observable<boolean>;

  constructor(private authenticationService: AuthenticationFacadeService) {
    this.logoutSuccess$ = this.authenticationService.logout();
  }

  ngOnInit(): void {
  }
}
