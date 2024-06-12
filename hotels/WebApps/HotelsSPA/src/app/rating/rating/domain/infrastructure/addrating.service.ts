import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IHotelRating } from '../models/hotel-rating';
import { INewRatingRequest } from '../models/put-new-rating-request';

@Injectable({
  providedIn: 'root',
})
export class AddRatingService {
  constructor(private httpClient: HttpClient) {}

  public AddRating(ratingInfo: INewRatingRequest): Observable<void> {
    return this.httpClient.put<void>(`http://localhost:8002/api/v1/Rating`,ratingInfo);
  }
}