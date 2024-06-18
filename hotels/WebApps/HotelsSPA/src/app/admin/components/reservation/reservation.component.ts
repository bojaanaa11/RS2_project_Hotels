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
    this.checkInFacadeService.CheckIn(this.GuestId,this.ReservationId,this.generateCurrentDateTime()).subscribe(
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

  generateCurrentDateTime(): string {
    const now = new Date();

    const day = String(now.getDate()).padStart(2, '0');
    const month = String(now.getMonth() + 1).padStart(2, '0');
    const year = now.getFullYear();
  
    const hours = String(now.getHours()).padStart(2, '0');
    const minutes = String(now.getMinutes()).padStart(2, '0');
  
    return `${day}/${month}/${year} ${hours}:${minutes}`;
  }
}
