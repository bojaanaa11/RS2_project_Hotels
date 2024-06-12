import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PendingRatingService } from '../infrastructure/pendingrating.service';
import { IPendingReviews } from '../models/pending-reviews';

@Injectable({
  providedIn: 'root',
})
export class PendingRatingFacadeService {
  constructor(private pendingRatingService: PendingRatingService) {}

  public getUserDetails(GuestId: string): Observable<IPendingReviews[]> {
    return this.pendingRatingService.getPendingRatings(GuestId);
  }
}