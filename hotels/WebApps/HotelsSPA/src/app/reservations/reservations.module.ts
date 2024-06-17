import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReservationsRoutingModule } from './reservations-routing.module';
import { ReservationsComponent } from './reservations.component';
import { CreateReservationFormComponent } from './feature-add-cancel-reservation/create-reservation-form/create-reservation-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ListReservationsComponent } from './feature-list-reservations/list-reservations/list-reservations.component';


@NgModule({
  declarations: [
    ReservationsComponent,
    CreateReservationFormComponent,
    ListReservationsComponent
  ],
  imports: [
    CommonModule,
    ReservationsRoutingModule,
    ReactiveFormsModule
  ]
})
export class ReservationsModule { }
