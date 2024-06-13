import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import { AppStateService } from '../../../shared/app-state/app-state.service';
import { IReservations } from '../../domain/models/reservation';
import { CheckInFacadeService } from '../../domain/application-services/check-in-facade.service';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrl: './reservation.component.css'
})

export class ReservationComponent {
  @Input() GuestId! : string
  @Input() ReservationId!: string 
  @Input() HotelName! : string
  @Input() Room! : string 
  @Input() StartDate! :string 
  @Input() EndDate! : string
  checkedIn = false;

  constructor (private checkInFacadeService : CheckInFacadeService) {

  }
  public checkInUser() {
    console.log(this.GuestId)
    console.log(this.ReservationId)
    this.checkInFacadeService.CheckIn(this.GuestId,this.ReservationId).subscribe(
      {
        next: () => {
          console.log('Checked in!');
          this.checkedIn=true;
          window.alert('Guest checked in successfully!');
          
        },
        error: (err) => {          
          console.error(err);
        }
      });
  }
}
