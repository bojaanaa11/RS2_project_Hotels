import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ObservedValueOf } from 'rxjs';
import { IHotel } from '../models/hotel';
import { IRoom } from '../models/room';

@Injectable({
  providedIn: 'root'
})
export class HotelService {

  constructor(private httpClient: HttpClient) { }

  private readonly url: string = "http://localhost:8004/api/v1/RoomManaging"

  public getHotels(): Observable<IHotel[]> {
    return this.httpClient.get<IHotel[]>(`${this.url}/GetHotels`)

  }

  getHotel(Id: string): Observable<IHotel> {
    return this.httpClient.get<IHotel>(`${this.url}/${Id}`,
      {
        params: {
            id: Id
        }
      }
    );
  }

  addHotel(Hotel: IHotel): Observable<IHotel> {
    const body = {
      id : Hotel.id,
      name : Hotel.name,
      address: Hotel.address,
      city: Hotel.city,
      country: Hotel.country,
      fileImages: Hotel.fileImages,
      rooms: Hotel.rooms,
      //description: Hotel.description
    }      
    return this.httpClient.post<IHotel>(`${this.url}`,
      body, {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      });
  }

  updateHotel(Hotel: IHotel): Observable<IHotel> {
    const body = {
      id : Hotel.id,
      name : Hotel.name,
      address: Hotel.address,
      city: Hotel.city,
      country: Hotel.country,
      fileImages: Hotel.fileImages,
      rooms: Hotel.rooms,
      //description: Hotel.description
    }
    return this.httpClient.put<IHotel>(`${this.url}`,
      body, {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      }
    );
  }

  deleteHotel(Id:string): Observable<void> {
    return this.httpClient.delete<void>(`http://localhost:8004/api/v1/RoomManaging/DeleteHotel`,
      {
        params: {
          id: Id
        }
      }
    );
  }
}
