import { Component, Input } from '@angular/core';
import { CheckOutFacadeService } from '../../domain/application-services/check-out-facade.service';

@Component({
  selector: 'app-hotel-stay',
  templateUrl: './hotel-stay.component.html',
  styleUrl: './hotel-stay.component.css'
})
export class HotelStayComponent {
  @Input() ReservationId! : string
  @Input() GuestId! : string
  @Input() HotelName! : string
  @Input() Room! : string 
  @Input() StartDate! :string 
  checkoutdate!: string
  checkedOut=false

  constructor(private checkOutFacadeService: CheckOutFacadeService){

  }

  public checkOutUser() {
    console.log("ckecking out");
    this.checkOutFacadeService.CheckOut(this.ReservationId,this.checkoutdate)
      .subscribe({
        next: () => {
          console.log('checked out');
          window.alert('Guest is checked out successfully!')
          this.checkedOut=true;
        },
        error: (err) => {
          console.log(err);
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
