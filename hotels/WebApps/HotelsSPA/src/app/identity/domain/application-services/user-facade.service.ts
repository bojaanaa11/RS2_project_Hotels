import { Injectable } from '@angular/core';
import { UserService } from '../infrastructure/user.service';
import { Observable } from 'rxjs';
import { IUserDetails } from '../models/user-details';

@Injectable({
  providedIn: 'root'
})
export class UserFacadeService {

  constructor(private userService: UserService) { }

  public getUserDetails(username: string): Observable<IUserDetails> {
    return this.userService.getUserDetails(username);
  }
}
