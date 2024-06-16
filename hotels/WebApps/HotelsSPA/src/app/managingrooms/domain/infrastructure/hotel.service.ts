import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IHotelResponse } from '../models/hotel-response';

@Injectable({
  providedIn: 'root'
})
export class HotelService {

  constructor(private httpClient: HttpClient) { }

  public getAllHotels(): Observable<Array<IHotelResponse>> {
    return this.httpClient.get<Array<IHotelResponse>>("http://localhost:8000/api/v1/RoomManaging/GetHotels");
  }
}
