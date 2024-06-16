import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IdentityComponent } from './identity.component';
import { LoginFormComponent } from './feature-authentication/login-form/login-form.component';
import { UserProfileComponent } from './feature-user-info/user-profile/user-profile.component';
import { LogoutComponent } from './feature-authentication/logout/logout.component';
import { NotAuthenticatedGuard } from '../shared/guards/not-authenticated.guard';
import { RegisterComponent } from './feature-authentication/register/register.component';
import { RegisterGuestComponent } from './feature-authentication/register/register-guest/register-guest.component';
import { RegisterHotelComponent } from './feature-authentication/register/register-hotel/register-hotel.component';

const routes: Routes = [
  { path: '', component: IdentityComponent },
  { path: 'login', component: LoginFormComponent},
  { path: 'profile', component: UserProfileComponent, canActivate: [NotAuthenticatedGuard]},
  { path: 'logout', component: LogoutComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'register/register-guest', component: RegisterGuestComponent},
  { path: 'register/register-hotel', component: RegisterHotelComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IdentityRoutingModule { }
