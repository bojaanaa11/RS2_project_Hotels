import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GuestReservationsService } from '../infrastructure/get-reservations.service';
import { IReservations } from '../models/reservation';

@Injectable({
  providedIn: 'root',
})
export class GuestReservationsFacadeService {
  constructor(private guestReservationsService: GuestReservationsService) {}

  public GuestReservations(GuestId : string): Observable<IReservations[]> {
    return this.guestReservationsService.guestReservations(GuestId);
  }
}