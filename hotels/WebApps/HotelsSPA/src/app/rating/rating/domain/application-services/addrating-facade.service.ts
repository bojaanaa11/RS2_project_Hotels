import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPendingReviews } from '../models/pending-reviews';
import { AddRatingService } from '../infrastructure/addrating.service';
import { IHotelRating } from '../models/hotel-rating';
import { INewRatingRequest } from '../models/put-new-rating-request';

@Injectable({
  providedIn: 'root',
})
export class AddRatingFacadeService {
  constructor(private addRatingService: AddRatingService) {}

  public AddRating(ratingInfo: INewRatingRequest): Observable<void> {
    return this.addRatingService.AddRating(ratingInfo);
  }
}