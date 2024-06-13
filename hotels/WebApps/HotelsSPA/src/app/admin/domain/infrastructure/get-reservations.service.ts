import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { IReservations } from '../models/reservation';

@Injectable({
  providedIn: 'root',
})
export class GuestReservationsService {
  constructor(private httpClient: HttpClient) {}

  public guestReservations(GuestId:string): Observable<IReservations[]> {
    return this.httpClient.get<{reservations: IReservations[]}>(`http://localhost:8005/api/v1/CheckInOut/GetUserReservations`,{
        params: {
            userId: GuestId
        }
    }).pipe(
      map(response => response.reservations)
    );
  }
}