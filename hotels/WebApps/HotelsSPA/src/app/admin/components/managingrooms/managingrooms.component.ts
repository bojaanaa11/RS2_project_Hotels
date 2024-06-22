import { Component, OnInit } from '@angular/core';
import { HotelFacadeService } from '../../domain/application-services/hotel-facade.service';
import { IHotel } from '../../domain/models/hotel';

@Component({
  selector: 'app-managingrooms',
  templateUrl: './managingrooms.component.html',
  styleUrl: './managingrooms.component.css'
})
export class ManagingroomsComponent implements OnInit {

  hotels: IHotel[] = [];
  newHotel: IHotel = {
    id: '',
    name: '',
    address: '',
    city: '',
    country: '',
    fileImages: [],
    rooms: [],
    description: ''
  };

  constructor(private hotelFacadeService: HotelFacadeService) {}
  
  ngOnInit(): void {
    this.loadHotels();
  }

  public loadHotels(): void {
    this.hotelFacadeService.GetHotels().subscribe((response:any) => {
      this.hotels = response;
      console.log(this.hotels);
    })
  }

  public addHotel(): void {
    console.log("adding new hotel")
    this.hotelFacadeService.AddHotel(this.newHotel).subscribe(() => {
      //this.loadHotels();
      //next: ()
    });
  }

 /* updateHotel(hotel: Hotel): void {
    this.hotelFacadeService.UpdateHotel(hotel).subscribe(() => {
      this.loadHotels();
    });
  } */

  deleteHotel(id: string): void {
    this.hotelFacadeService.DeleteHotel(id).subscribe(() => {
      this.loadHotels();
    });
  }


}
