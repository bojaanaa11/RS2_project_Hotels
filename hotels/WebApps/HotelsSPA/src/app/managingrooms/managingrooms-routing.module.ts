import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagingroomsComponent } from './managingrooms.component';
import { ClientHotelsComponent } from './feature-managingrooms/client-hotels/client-hotels.component';

const routes: Routes = [{ path: '', component: ClientHotelsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManagingroomsRoutingModule { }
