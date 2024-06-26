import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './ui-utils/home/home.component';

const routes: Routes = [
  { path: 'identity', loadChildren: () => import('./identity/identity.module').then(m => m.IdentityModule)},
  { path: '', component: HomeComponent},
  { path: 'rating', loadChildren: () => import('./rating/rating/rating.module').then(m => m.RatingModule) },
  { path: 'admin', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule) },
  { path: 'reservations', loadChildren: () => import('./reservations/reservations.module').then(m => m.ReservationsModule) },
  { path: 'managingrooms', loadChildren: () => import('./managingrooms/managingrooms.module').then(m => m.ManagingroomsModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
