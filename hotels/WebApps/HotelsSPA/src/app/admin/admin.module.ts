import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { CheckInUserComponent } from './components/check-in-user/check-in-user.component';
import { CheckOutUserComponent } from './components/check-out-user/check-out-user.component';


@NgModule({
  declarations: [
    AdminComponent,
    CheckInUserComponent,
    CheckOutUserComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ],
  bootstrap: [AdminComponent]
})
export class AdminModule { }
