import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './ui-utils/home/home.component';

const routes: Routes = [
  { path: 'identity', loadChildren: () => import('./identity/identity.module').then(m => m.IdentityModule)},
  { path: '', component: HomeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
