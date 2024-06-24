import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetHotelReviewsService } from '../infrastructure/gethotelreviews.service';
import { IHotelReview } from '../models/get-hotel-reviews';

@Injectable({
  providedIn: 'root',
})
export class GetHotelReviewsFacadeService {
  constructor(private getHotelReviewsService: GetHotelReviewsService) {}

  public GetHotelReviews(hotelId: string): Observable<IHotelReview[]> {
    return this.getHotelReviewsService.getHotelReviews(hotelId);
  }
}