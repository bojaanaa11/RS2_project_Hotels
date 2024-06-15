import { Component, Input } from '@angular/core';
import { IAppState } from '../../../../shared/app-state/app-state';
import { AddRatingFacadeService } from '../../domain/application-services/addrating-facade.service';
import { AppStateService } from '../../../../shared/app-state/app-state.service';
import { trigger, state, style, animate, transition } from '@angular/animations';

@Component({
  selector: 'app-hotel-stay',
  templateUrl: './hotel-stay.component.html',
  styleUrls: ['./hotel-stay.component.css'],
  animations: [
    trigger('fadeOut', [
      state('visible', style({
        opacity: 1
      })),
      state('hidden', style({
        opacity: 0
      })),
      transition('visible => hidden', [
        animate('1s')
      ])
    ])
  ]
})
export class HotelStayComponent {
  @Input() HotelId!: string;
  @Input() HotelName!: string;
  @Input() ReservationId!: string;
  selectedRating: number = 0;
  hoverRating: number = 0;
  comment: string = '';  // Property to hold the comment
  error?: string;
  loading = true;
  userId?: string;
  fadeState = 'visible';
  show=true;

  constructor(
    private addRatingFacadeService: AddRatingFacadeService,
    private appStateService: AppStateService
  ) {}

  selectRating(rating: number): void {
    this.selectedRating = rating;
    console.log(this.selectedRating);
  }

  setHoverRating(rating: number): void {
    this.hoverRating = rating;
  }

  resetHoverRating(): void {
    this.hoverRating = 0;
  }

  submitRating(): void {
    console.log('Rating:', this.selectedRating);
    console.log('Comment:', this.comment);

    this.appStateService.getAppState().subscribe({
      next: (response: IAppState) => {
        if (!response.username) {
          this.error = "Undefined user id";
          this.loading = false;          
          return;
        }
        this.userId = response.username;
        console.log(response.userId);

        this.addRatingFacadeService.AddRating({
          hotelId: this.HotelId,
          hotelName: this.HotelName,
          guestId: this.userId,
          reservationId: this.ReservationId,
          hotelRating: {
            rating: this.selectedRating,
            comment: this.comment,
            ratingDate: undefined
          }
        }).subscribe({
          next: () => {    
            window.alert("You successfully rated stay!")        
            this.loading = false;
            this.fadeState = 'hidden';  // Trigger the fade-out animation
            this.show=false;
          },
          error: (err) => {
            this.error = "Failed to fetch user details";
            this.loading = false;
            console.error(err);
            window.alert("Error!");
          }
        });
      },
      error: (err) => {
        this.error = "Failed to fetch app state";
        this.loading = false;
        console.error(err);
        window.alert("Error!");
      }
    });
  }
}
