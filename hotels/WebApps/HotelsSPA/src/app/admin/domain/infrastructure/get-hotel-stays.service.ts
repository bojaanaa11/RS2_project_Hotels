import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { IHotelStay } from '../models/hotel-stay';

@Injectable({
  providedIn: 'root',
})
export class GuestHotelStaysService {
  constructor(private httpClient: HttpClient) {}

  public guestHotelStays(GuestId:string): Observable<IHotelStay[]> {
    return this.httpClient.get<IHotelStay[]>(`http://localhost:8005/api/v1/CheckInOut/HotelStayByGuestId`,{
        params: {
            guestId: GuestId
        }
    });
  }
}