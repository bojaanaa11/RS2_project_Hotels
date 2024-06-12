import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RatingRoutingModule } from './rating-routing.module';
import { RatingComponent } from './rating.component';
import { HotelStayComponent } from './components/hotel-stay/hotel-stay.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { RatingInterceptor } from '../../shared/interceptors/rating.interceptor';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    RatingComponent,
    HotelStayComponent
  ],
  imports: [
    CommonModule,
    RatingRoutingModule,
    FormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: RatingInterceptor,
      multi: true
    }
  ]
})
export class RatingModule { }
