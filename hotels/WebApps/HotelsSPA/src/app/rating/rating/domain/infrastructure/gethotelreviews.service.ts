import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IHotelReview } from '../models/get-hotel-reviews';

@Injectable({
  providedIn: 'root',
})
export class GetHotelReviewsService {
  constructor(private httpClient: HttpClient) {}

  public getHotelReviews(HotelId:string): Observable<IHotelReview[]> {
    return this.httpClient.get<IHotelReview[]>(`http://localhost:8002/api/v1/Rating/reviews/${HotelId}`);
  }
}