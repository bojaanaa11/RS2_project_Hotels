import { Injectable } from '@angular/core';
import { HotelService } from '../infrastructure/hotel.service';
import { IHotel } from '../models/hotel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HotelFacadeService {

  constructor(private hotelService: HotelService) { }

  public GetHotels(): Observable<IHotel[]> {
    return this.hotelService.getHotels();
  }

  public GetHotel(Id: string): Observable<IHotel> {
    return this.hotelService.getHotel(Id);
  }

  public AddHotel(Hotel: IHotel): Observable<IHotel> {
    return this.hotelService.addHotel(Hotel);
  }

  public UpdateHotel(Hotel: IHotel): Observable<IHotel> {
    return this.hotelService.updateHotel(Hotel);
  }

  public DeleteHotel(Id: string): Observable<void> {
    return this.hotelService.deleteHotel(Id);
  }
}
