import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GetHotelReviewsFacadeService } from '../../domain/application-services/gethotelreviews-facade.service';
import { IHotelReview } from '../../domain/models/get-hotel-reviews';
import { GetAverageRatingFacadeService } from '../../domain/application-services/getaveragerating-facade.service';

@Component({
  selector: 'app-show-reviews',
  templateUrl: './show-reviews.component.html',
  styleUrl: './show-reviews.component.css'
})
export class ShowReviewsComponent {
  HotelId: string;
  HotelReviews: IHotelReview[] = []
  averageRating: number = 0
  loading: true;
  error: string;
  showAllReviews: boolean = false;
  constructor(private route: ActivatedRoute,
    private getHotelReviewsFacadeService: GetHotelReviewsFacadeService,
    private getAverageRatingFacadeService: GetAverageRatingFacadeService
  ) {
    
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.HotelId = params['hotelId'] || '';
      this.getAverageRatingFacadeService.GetAverageRating(this.HotelId).subscribe({
        next: (response: number) => {
          this.averageRating=response;
          console.log(response);
        },
        error: (error) => {
          console.log(error)
          this.error=error;
        }
      });
      this.getHotelReviewsFacadeService.GetHotelReviews(this.HotelId).subscribe({
        next: (response: IHotelReview[]) => {
          console.log(response)
          this.HotelReviews=response
        },
        error: (error) => {
          this.error=error;
          console.log(error);
        }
      });
    });
  }

  toggleReviews() {
    this.showAllReviews=!this.showAllReviews;
  }
}
