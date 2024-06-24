import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HotelFacadeService } from '../../domain/application-services/hotel-facade.service';
import { IHotel } from '../../domain/models/hotel';
import { Router } from '@angular/router';
import { IRoom } from '../../domain/models/room';

@Component({
  selector: 'app-add-hotel',
  templateUrl: './add-hotel.component.html',
  styleUrl: './add-hotel.component.css'
})
export class AddHotelComponent implements OnInit{
  Id: string
  Name: string
  Address: string
  City: string
  Country: string
  FileImages: Array<string>
  Rooms: IRoom[]
  Description: string

  constructor(private hotelService: HotelFacadeService, private router: Router) {
    // this.hotelForm = new FormGroup({
    //   id: new FormControl("", Validators.required),
    //   name: new FormControl("", Validators.required),
    //   address: new FormControl("", Validators.required),
    //   city: new FormControl("", Validators.required),
    //   country: new FormControl("", Validators.required),
    //   fileimages: new FormControl([], Validators.required),
    //   description: new FormControl("", Validators.required),
    // })
  }

  ngOnInit(): void {
    
  }

  public AddHotel(): void {
    // if (this.hotelForm.invalid) {
    //   window.alert('Form has errors!');
    //   return;
    // }

    let hotel: IHotel

    hotel.id = this.Id;
    hotel.name = this.Name;
    hotel.address = this.Address;
    hotel.city = this.City;
    hotel.country = this.Country;
    hotel.fileImages = this.FileImages;
    hotel.rooms = this.Rooms;
    hotel.description = this.Description;

    this.hotelService.AddHotel(hotel).subscribe((response: any) => {
      console.log(`Hotel successfully created`);
      window.alert(`Hotel successfully created!`);
      //this.hotelForm.reset();
      this.router.navigate(['/managingrooms']);
    }),
      (error: any) => {
      console.error(`Error creating hotel: `, error);
      window.alert(`Error creating hotel!`);
    }
  }
}

// this.authenticationService.registerAsHotel(
//   this.registerHotelForm.value.firstName,
//   this.registerHotelForm.value.lastName,
//   this.registerHotelForm.value.username, 
//   this.registerHotelForm.value.password,
//   this.registerHotelForm.value.email,
//   this.registerHotelForm.value.phoneNumber).subscribe((success: boolean) => {
//   window.alert(`Registration ${success ? 'is' : 'is not'} successful!`);
//   this.registerHotelForm.reset();
//   if(success) {
//     this.routerService.navigate(['/identity', 'login']);
//   }
// });

