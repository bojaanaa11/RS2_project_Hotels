import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagingroomsComponent } from './managingrooms.component';
import { ClientHotelsComponent } from './feature-managingrooms/client-hotels/client-hotels.component';
import { CreateReservationFormComponent } from '../reservations/feature-add-cancel-reservation/create-reservation-form/create-reservation-form.component';
import { ClientRoomsComponent } from './feature-managingrooms/client-rooms/client-rooms.component';
import { RatingComponent } from '../rating/rating/rating.component';

const routes: Routes = [
  { path: '', component: ClientHotelsComponent },
  { path: 'reservations', loadChildren: () => import('../reservations/reservations.module').then(m => m.ReservationsModule) },
  { path: 'client-rooms', component: ClientRoomsComponent},
 // { path: 'rating', component: RatingComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManagingroomsRoutingModule { }
