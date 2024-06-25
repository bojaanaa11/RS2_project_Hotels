import { Component, OnInit } from '@angular/core';
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
  hotelId: string
  Name: string
  Address: string
  City: string
  Country: string
  hotelFileImages: string[]
  Rooms: IRoom[] = []
  //hotelDescription: string
  hotelFileImage: string;

  roomId: string
  roomNumber: string
  roomPrice: number
  roomFileImages: string[]
  roomDescription: string
  roomFileImage: string;


  constructor(private hotelService: HotelFacadeService, private router: Router) { }

  ngOnInit(): void {
    
  }

  public AddHotel(): void {
    // if (this.hotelForm.invalid) {
    //   window.alert('Form has errors!');
    //   return;
    // }
    this.hotelFileImages = []
    this.hotelFileImages.push(this.hotelFileImage)
    let hotel: IHotel = {
      id: this.hotelId,
      name: this.Name,
      address: this.Address,
      city: this.City,
      country: this.Country,
      fileImages: this.hotelFileImages,
      rooms: this.Rooms,
      //description: ''
    }
    
    this.hotelService.AddHotel(hotel.id, hotel.name, hotel.address, hotel.city, hotel.country, hotel.fileImages, hotel.rooms).subscribe((response: any) => {
      console.log(`Hotel successfully created`);
      //this.hotelForm.reset();
      //this.router.navigate(['/admin-managingrooms']);
    }),
      (error: any) => {
      console.error(`Error creating hotel: `, error);
    }
  }

  addRoomToList() {
    this.roomFileImages = []
    this.roomFileImages.push(this.roomFileImage)
    const room: IRoom = {
      id: this.roomId,
      hotelId: this.hotelId,
      roomNumber: this.roomNumber,
      status: false,
      price: this.roomPrice,
      fileImages: this.roomFileImages,
      description: this.roomDescription
    };

    this.Rooms.push(room);

    // Reset room fields after adding to list
    // this.roomId = '';
    // this.roomNumber = '';
    // this.roomStatus = '';
    // this.roomPrice = 0;
    // this.roomFileImages = [];
    // this.roomDescription = '';
  }


}

