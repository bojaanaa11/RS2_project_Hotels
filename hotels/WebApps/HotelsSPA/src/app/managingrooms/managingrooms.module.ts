import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ManagingroomsRoutingModule } from './managingrooms-routing.module';
import { ManagingroomsComponent } from './managingrooms.component';
import { ClientHotelsComponent } from './feature-managingrooms/client-hotels/client-hotels.component';


@NgModule({
  declarations: [
    ManagingroomsComponent,
    ClientHotelsComponent
  ],
  imports: [
    CommonModule,
    ManagingroomsRoutingModule
  ]
})
export class ManagingroomsModule { }
