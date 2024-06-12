import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPendingReviews } from '../models/pending-reviews';

@Injectable({
  providedIn: 'root',
})
export class PendingRatingService {
  constructor(private httpClient: HttpClient) {}

  public getPendingRatings(GuestId:string): Observable<IPendingReviews[]> {
    return this.httpClient.get<IPendingReviews[]>(`http://localhost:8002/api/v1/Rating/pendingRatings/${GuestId}`);
  }
}