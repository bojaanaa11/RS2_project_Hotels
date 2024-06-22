import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IRoomResponse } from '../models/room-response';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  constructor(private httpClient: HttpClient) { }

  public getAllRooms(hotelId: string): Observable<Array<IRoomResponse>> {
    return this.httpClient.get<Array<IRoomResponse>>(`http://localhost:8004/api/vi/ManagingRooms/GetRoomsInHotel?hotelId=${hotelId}`);
  }
}
