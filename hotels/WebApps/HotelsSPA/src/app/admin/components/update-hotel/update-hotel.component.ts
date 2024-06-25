import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HotelFacadeService } from '../../domain/application-services/hotel-facade.service';
import { IHotel } from '../../domain/models/hotel';
import { IRoom } from '../../domain/models/room';

@Component({
  selector: 'app-update-hotel',
  templateUrl: './update-hotel.component.html',
  styleUrl: './update-hotel.component.css'
})
export class UpdateHotelComponent {
 
  constructor(private hotelService: HotelFacadeService, private router: Router) {
  }

  hotelId: string
  hotel: IHotel
  hotelFileImage: string;
  roomFileImage: any;

  ngOnInit(): void {

    this.hotelId = sessionStorage.getItem('hotelId');
    console.log(this.hotelId);

    this.hotelService.GetHotel(this.hotelId).subscribe((hotel: IHotel) => {
      this.hotel = hotel
    }),
    (error: any) => {
      console.error(`Error updating hotel: `, error);
    }
  }

  public UpdateHotel(): void {
    
    this.hotel.fileImages.push(this.hotelFileImage)

    this.hotelService.UpdateHotel(this.hotel).subscribe((response: any) => {
      console.log(`Hotel successfully updated`);
      window.alert(`Hotel successfully updated!`);
      this.router.navigate(['/admin-managingrooms']);
    }),
      (error: any) => {
      console.log(`Error updating hotel: `, error);
      window.alert(`Error updating hotel!`);
    }
  }

  
}
