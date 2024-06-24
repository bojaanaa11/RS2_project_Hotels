import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GetAverageRatingService {
  constructor(private httpClient: HttpClient) {}

  public getAverageRating(HotelId:string): Observable<number> {
    return this.httpClient.get<number>(`http://localhost:8002/api/v1/Rating/rating/${HotelId}`);
  }
}