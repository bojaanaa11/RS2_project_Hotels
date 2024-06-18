import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CheckInService {
  constructor(private httpClient: HttpClient) {}

  public checkIn(GuestId:string, ReservationId:string, Date: string): Observable<void> {
    const params = new HttpParams()
      .set('userId', GuestId)
      .set('reservationId', ReservationId)
      .set('startDateTime',Date);
    return this.httpClient.put<void>(`http://localhost:8005/api/v1/CheckInOut`,
        null,
        {params}
    );
  }
}