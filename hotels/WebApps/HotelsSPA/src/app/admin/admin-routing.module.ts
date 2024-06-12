import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { CheckInUserComponent } from './components/check-in-user/check-in-user.component';
import { CheckOutUserComponent } from './components/check-out-user/check-out-user.component';

const routes: Routes = [{ path: '', component: AdminComponent },
  { path: 'checkin', component: CheckInUserComponent },
  { path: 'checkout', component: CheckOutUserComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
