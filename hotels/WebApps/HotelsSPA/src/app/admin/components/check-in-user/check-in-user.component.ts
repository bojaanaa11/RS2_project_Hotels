import { Component } from '@angular/core';
import { GuestReservationsFacadeService } from '../../domain/application-services/get-reservations-facade.service';
import { IReservations } from '../../domain/models/reservation';

@Component({
  selector: 'app-check-in-user',
  templateUrl: './check-in-user.component.html',
  styleUrls: ['./check-in-user.component.css']
})
export class CheckInUserComponent {
  reservations: IReservations[] = [];
  guestId: string = '';
  loading = false;
  error? : string;

  constructor(
    private getReservationsFacadeService: GuestReservationsFacadeService
  ) {}

  getReservations() {
    this.loading=true;
    console.log( this.guestId);
    this.getReservationsFacadeService.GuestReservations(this.guestId).subscribe({
      next : (response : IReservations[]) => {
        this.loading=false;
        console.log(response);
        this.reservations=response;
      }
    });
  }

}
