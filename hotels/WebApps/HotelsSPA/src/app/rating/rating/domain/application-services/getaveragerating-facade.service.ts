import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetAverageRatingService } from '../infrastructure/getaveragerating.service';

@Injectable({
  providedIn: 'root',
})
export class GetAverageRatingFacadeService {
  constructor(private getAverageRatingFacadeService: GetAverageRatingService) {}

  public GetAverageRating(hotelId: string): Observable<number> {
    return this.getAverageRatingFacadeService.getAverageRating(hotelId);
  }
}