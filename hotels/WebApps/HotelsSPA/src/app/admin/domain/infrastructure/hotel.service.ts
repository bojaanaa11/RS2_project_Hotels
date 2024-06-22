import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IHotel } from '../models/hotel';

@Injectable({
  providedIn: 'root'
})
export class HotelService {

  constructor(private httpClient: HttpClient) { }

  public getHotels(): Observable<IHotel[]> {
    return this.httpClient.get<IHotel[]>(`http://localhost:8004/api/v1/ManagingRooms/GetHotels`)
  }

  getHotel(Id: string): Observable<IHotel> {
    return this.httpClient.get<IHotel>(`http://localhost:8004/api/v1/ManagingRooms/GetHotel`,
      {
        params: {
            id: Id
        }
      }
    );
  }

  addHotel(Hotel: IHotel): Observable<IHotel> {
    return this.httpClient.post<IHotel>('http://localhost:8004/api/v1/ManagingRooms/CreateHotel',
      {
        params: {
          hotel: Hotel
        }
      }
    );
  }

  deleteHotel(Id:string): Observable<void> {
    return this.httpClient.delete<void>('http://localhost:8004/api/v1/ManagingRooms/DeleteHotel',
      {
        params: {
          id: Id
        }
      }
    );
  }
}
