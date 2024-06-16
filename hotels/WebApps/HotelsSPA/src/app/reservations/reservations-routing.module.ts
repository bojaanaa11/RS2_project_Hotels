import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReservationsComponent } from './reservations.component';
import { CreateReservationFormComponent } from './feature-add-cancel-reservation/create-reservation-form/create-reservation-form.component';

const routes: Routes = [
  { path: '', component: ReservationsComponent },
  { path: 'create-reservation/:hotelId/:hotelName/:roomId', component: CreateReservationFormComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReservationsRoutingModule { }
