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
  hotelId: string
  Name: string
  Address: string
  City: string
  Country: string
  hotelFileImages: Array<string>
  Rooms: IRoom[] = []
  hotelDescription: string

  roomId: string
  roomNumber: string
  roomStatus: string
  roomPrice: number
  roomFileImages: Array<string> = []
  roomDescription: string

  constructor(private hotelService: HotelFacadeService, private router: Router) {
   
  }

  ngOnInit(): void {
    //this.hotelId = this.route.snapshot.params['id'];
    // this.hotelService.GetHotel(this.hotelId).subscribe((hotel: IHotel) => {
    //   this.Name = hotel.name;
    //   this.Address = hotel.address;
    //   this.City = hotel.city;
    //   this.Country = hotel.country;
    //   this.hotelFileImages = hotel.fileImages;
    //   this.Rooms = hotel.rooms;
    //   this.hotelDescription = hotel.description;
    // }, (error) => {
    //   console.error(`Error fetching hotel details: `, error);
    // });
  }

  public UpdateHotel(): void {
    // if (this.hotelForm.invalid) {
    //   window.alert('Form has errors!');
    //   return;
    // }

    let hotel: IHotel

    hotel.id = this.hotelId;
    hotel.name = this.Name;
    hotel.address = this.Address;
    hotel.city = this.City;
    hotel.country = this.Country;
    hotel.fileImages = this.hotelFileImages;
    hotel.rooms = this.Rooms;
    //hotel.description = this.hotelDescription;


    this.hotelService.UpdateHotel(hotel).subscribe((response: any) => {
      console.log(`Hotel successfully updated`);
      window.alert(`Hotel successfully updated!`);
      //this.hotelForm.reset();
      this.router.navigate(['/admin-managingrooms']);
    }),
      (error: any) => {
      console.log(`Error updating hotel: `, error);
      window.alert(`Error updating hotel!`);
    }
  }
}
