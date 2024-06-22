import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagingroomsComponent } from './managingrooms.component';
import { ClientHotelsComponent } from './feature-managingrooms/client-hotels/client-hotels.component';
import { CreateReservationFormComponent } from '../reservations/feature-add-cancel-reservation/create-reservation-form/create-reservation-form.component';

const routes: Routes = [
  { path: '', component: ClientHotelsComponent },
  { path: 'reservations/:hotelId', loadChildren: () => import('../reservations/reservations.module').then(m => m.ReservationsModule) }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManagingroomsRoutingModule { }
