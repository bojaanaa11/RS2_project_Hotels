import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { CheckInUserComponent } from './components/check-in-user/check-in-user.component';
import { CheckOutUserComponent } from './components/check-out-user/check-out-user.component';
import { ReservationComponent } from './components/reservation/reservation.component';
import { HotelStayComponent } from './components/hotel-stay/hotel-stay.component';


@NgModule({
  declarations: [
    AdminComponent,
    CheckInUserComponent,
    CheckOutUserComponent,
    ReservationComponent,
    HotelStayComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule
  ],
  bootstrap: [AdminComponent]
})
export class AdminModule { }
