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
  hotelFileImages: string[] = []
  Rooms: IRoom[] = []
  //hotelDescription: string
  hotelFileImage: string;

  roomId: string
  roomNumber: string
  roomPrice: number
  roomFileImages: string[] = []
  roomDescription: string
  roomFileImage: string;

  hotels: IHotel[] = [];

  constructor(private hotelService: HotelFacadeService, private router: Router) { }

  ngOnInit(): void {
    this.hotelService.GetHotels().subscribe((response:IHotel[]) => {
      this.hotels = response;
    })
  }

  public AddHotel(): void {
    if (this.Rooms.length == 0) {
      window.alert('There are no rooms added to hotel.\nAdd rooms first.');
      return
    }

    this.hotelFileImages = []
    this.hotelFileImages.push('assets/images/' + this.hotelFileImage.split('\\').pop())
    let hotel: IHotel = {
      id: this.hotelId,
      name: this.Name,
      address: this.Address,
      city: this.City,
      country: this.Country,
      fileImages: this.hotelFileImages,
      rooms: this.Rooms
    }

    let addHotel = true;
    for (let index = 0; index < this.hotels.length; index++) {
      if (this.hotelId === this.hotels[index].id) {
        addHotel = false;
        window.alert('Hotel with given id already exists.')
        break;
      }
    }
    
    if (addHotel) {
      console.log(hotel.fileImages) 
      this.hotelService.AddHotel(hotel.id, hotel.name, hotel.address, hotel.city, hotel.country, hotel.fileImages, hotel.rooms).subscribe((response: any) => {
        console.log('Response:' + response)
        window.alert('Hotel added successfully')
        this.hotelId = "";
        this.Name = "";
        this.Address = "";
        this.City = "";
        this.Country = "";
        this.hotelFileImages = [];
        this.hotelFileImage = ""
        this.Rooms = []
      }),
        (error: any) => {
        console.error(`Error creating hotel: `, error);
      }
    }
    
  }

  addRoomToList() {
   
    const room: IRoom = {
      id: this.roomId,
      hotelId: this.hotelId,
      roomNumber: this.roomNumber,
      status: false,
      price: this.roomPrice,
      fileImages: this.roomFileImages,
      description: this.roomDescription
    };

    let addRoom = true;
    for (let index = 0; index < this.Rooms.length; index++) {
      if (this.roomId === this.Rooms[index].id) {
        addRoom = false;
        window.alert('Room with given id already exists.')
        break;
      }
    }
   
    if (addRoom) this.Rooms.push(room);

    this.roomId = '';
    this.roomNumber = '';
    this.roomPrice = 0;
    this.roomFileImages = [];
    this.roomDescription = '';
    this.roomFileImage = ''

    window.alert('Room successfully added to hotel');
  }

  addImageToRoomsImages() {
    this.roomFileImages.push('assets/images/' + this.roomFileImage.split('\\').pop())
    this.roomFileImage = ''
  }

  clearAllRooms() {
    if (confirm('Are you sure you want to delete all rooms added to hotel?')){
      this.Rooms = [];
    }
  }


}

