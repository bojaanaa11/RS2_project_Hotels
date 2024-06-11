import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IdentityRoutingModule } from './identity-routing.module';
import { IdentityComponent } from './identity.component';
import { LoginFormComponent } from './feature-authentication/login-form/login-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserProfileComponent } from './feature-user-info/user-profile/user-profile.component';
import { LogoutComponent } from './feature-authentication/logout/logout.component';
import { RegisterComponent } from './feature-authentication/register/register.component';
import { RegisterGuestComponent } from './feature-authentication/register/register-guest/register-guest.component';
import { RegisterHotelComponent } from './feature-authentication/register/register-hotel/register-hotel.component';

@NgModule({
  declarations: [
    IdentityComponent,
    LoginFormComponent,
    UserProfileComponent,
    LogoutComponent,
    RegisterComponent,
    RegisterGuestComponent,
    RegisterHotelComponent,
  ],
  imports: [
    CommonModule,
    IdentityRoutingModule,
    ReactiveFormsModule
  ]
})
export class IdentityModule { }
