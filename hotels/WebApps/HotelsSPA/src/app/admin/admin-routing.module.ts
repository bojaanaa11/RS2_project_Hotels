import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { CheckInUserComponent } from './components/check-in-user/check-in-user.component';
import { CheckOutUserComponent } from './components/check-out-user/check-out-user.component';
import { FormsModule } from '@angular/forms'; 
import { AddHotelComponent } from './components/add-hotel/add-hotel.component';
import { UpdateHotelComponent } from './components/update-hotel/update-hotel.component';
import { ManagingroomsComponent } from '../managingrooms/managingrooms.component';

const routes: Routes = [{ path: '', component: AdminComponent },
  { path: 'checkin', component: CheckInUserComponent },
  { path: 'checkout', component: CheckOutUserComponent },
  { path: 'add-hotel', component: AddHotelComponent},
  { path: 'update-hotel', component: UpdateHotelComponent},
  { path: 'managingrooms', component: ManagingroomsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes), FormsModule],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
