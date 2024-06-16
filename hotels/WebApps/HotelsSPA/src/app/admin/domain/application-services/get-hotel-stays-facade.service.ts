import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GuestHotelStaysService } from '../infrastructure/get-hotel-stays.service';
import { IHotelStay } from '../models/hotel-stay';

@Injectable({
  providedIn: 'root',
})
export class GuestHotelStaysFacadeService {
  constructor(private guestHotelStaysService: GuestHotelStaysService) {}

  public GuestHotelStays(GuestId : string): Observable<IHotelStay[]> {
    return this.guestHotelStaysService.guestHotelStays(GuestId);
  }
}