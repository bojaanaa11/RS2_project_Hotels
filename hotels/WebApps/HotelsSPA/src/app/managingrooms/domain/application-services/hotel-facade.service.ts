import { Injectable } from '@angular/core';
import { HotelService } from '../infrastructure/hotel.service';
import { IHotelResponse } from '../models/hotel-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HotelFacadeService {

  constructor(private hotelService: HotelService) { }

  public getAllHotels(): Observable<Array<IHotelResponse>> {
    return this.hotelService.getAllHotels();
  }
}
