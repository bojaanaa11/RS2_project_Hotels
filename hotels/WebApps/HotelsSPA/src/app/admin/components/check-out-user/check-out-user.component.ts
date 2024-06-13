import { Component } from '@angular/core';
import { IHotelStay } from '../../domain/models/hotel-stay';
import { GuestHotelStaysFacadeService } from '../../domain/application-services/get-hotel-stays-facade.service';

@Component({
  selector: 'app-check-out-user',
  templateUrl: './check-out-user.component.html',
  styleUrl: './check-out-user.component.css'
})
export class CheckOutUserComponent {
  stays: IHotelStay[] = [];
  guestId: string = '';
  loading = false;
  error? : string;

  constructor(private getHotelStaysFacadeService: GuestHotelStaysFacadeService){

  }
  getHotelStay() {
    this.loading=true;
    console.log('geting hotel stays');
    console.log(this.guestId);
    this.getHotelStaysFacadeService.GuestHotelStays(this.guestId)
      .subscribe({
        next: (response) => {
          this.loading=false;
          console.log(response)
          console.log(typeof(response))
          this.stays=response;
        },
        error: (err) => {
          this.loading=false
          this.error=err;
          console.log(err);
        }
      });
  }
}
