import { Injectable } from '@angular/core';
import { ManageReservationsService } from '../infrastructure/manage-reservations.service';
import { IAddReservationRequest } from '../models/add-reservation-request';
import { Observable, catchError, map, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ManageReservationsFacadeService {

  constructor(private manageReservationsService: ManageReservationsService) { }

  public create(
    id: string,
    userId: string, 
    hotelId: string, 
    hotelName: string, 
    roomId: string,
    bookingDateTime: string,
    startDateTime: string, 
    endDateTime: string, 
    status: string): Observable<boolean> {
    const request: IAddReservationRequest = {
      id,
      userId,
      hotelId,
      hotelName,
      roomId,
      bookingDateTime,
      startDateTime,
      endDateTime,
      status
    }; 

    return this.manageReservationsService.create(request).pipe(
      map(() => {
        console.log('Reservation created!');
        return true;
      }),
      catchError((err) => {
        console.log(err);
        return of(false);
      })
    );
  }
}
