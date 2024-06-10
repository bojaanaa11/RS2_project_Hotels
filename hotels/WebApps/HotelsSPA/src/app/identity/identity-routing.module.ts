import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IdentityComponent } from './identity.component';
import { LoginFormComponent } from './feature-authentication/login-form/login-form.component';
import { UserProfileComponent } from './feature-user-info/user-profile/user-profile.component';

const routes: Routes = [
  { path: '', component: IdentityComponent },
  { path: 'login', component: LoginFormComponent},
  { path: 'profile', component: UserProfileComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IdentityRoutingModule { }
