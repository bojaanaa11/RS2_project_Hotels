import { Component, OnInit } from '@angular/core';
import { PendingRatingFacadeService } from './domain/application-services/pendingrating-facade.service';
import { AppStateService } from '../../shared/app-state/app-state.service';
import { IAppState } from '../../shared/app-state/app-state';
import { IPendingReviews } from './domain/models/pending-reviews';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css']  // corrected from 'styleUrl' to 'styleUrls'
})
export class RatingComponent implements OnInit {
  pendingRatingsResponse?: IPendingReviews[];
  loading = true;
  error?: string;

  constructor(
    private pendingRatingService: PendingRatingFacadeService,
    private appStateService: AppStateService
  ) {}

  ngOnInit(): void {
    this.appStateService.getAppState().subscribe({
      next: (response: IAppState) => {
        if (!response.userId) {
          this.error = "Undefined user id";
          this.loading = false;
          return;
        }

        console.log(response.userId);
        this.pendingRatingService.getUserDetails(response.userId).subscribe({
          next: (pendingRatingsResponse: IPendingReviews[]) => {
            this.pendingRatingsResponse = pendingRatingsResponse;
            this.loading = false;
            console.log(pendingRatingsResponse)
            console.log(pendingRatingsResponse);
            
          },
          error: (err) => {
            this.error = "Failed to fetch user details";
            this.loading = false;
            console.error(err);
          }
        });
      },
      error: (err) => {
        this.error = "Failed to fetch app state";
        this.loading = false;
        console.error(err);
      }
    });
  }
}
