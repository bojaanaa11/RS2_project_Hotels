import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CheckOutService {
  constructor(private httpClient: HttpClient) {}

  public checkOut(ReservationId:string, EndDateTime: string): Observable<void> {
    const params = new HttpParams()
    .set('reservationId', ReservationId)
    .set('endDateTime', EndDateTime);
    return this.httpClient.put<void>(`http://localhost:8005/api/v1/CheckInOut/CheckOutDate`,
        null,
        {params}
    );
  }
}