import { Component, OnInit } from '@angular/core';
import { HotelFacadeService } from '../../domain/application-services/hotel-facade.service';
import { Router } from '@angular/router';
import { IHotelResponse } from '../../domain/models/hotel-response';
import { IRoomResponse } from '../../domain/models/room-response';

@Component({
  selector: 'app-client-hotels',
  templateUrl: './client-hotels.component.html',
  styleUrl: './client-hotels.component.css'
})
export class ClientHotelsComponent implements OnInit {
  
  constructor(private hotelService: HotelFacadeService, private router: Router) {}

  // room: IRoomResponse = {
  //   id: '1',
  //   hotelid: '1',
  //   roomnumber: '100',
  //   status: 'available',
  //   price: 5434.00,
  //   fileimages: ["https://images.app.goo.gl/UXBZGMXtZAizRCFA8", "https://images.app.goo.gl/n1qZ8ZhNXGfbT2Bg7"],
  //   description: 'Apartman sa terasom, klima uredjajem i pogledom na reku.'
  // }

  // hotel: IHotelResponse = {
  //   id: "1",
  //   name: 'Jugoslavija',
  //   address: 'Bulevar Nikole Tesle 3',
  //   city: 'Belgrade',
  //   country: 'Serbia',
  //   fileimages: [],
  //   rooms: [this.room],
  //   description: 'https://images.app.goo.gl/5SwYqTHJJjeeEe3c8", "https://images.app.goo.gl/r58JYvLU1YS3xcWX7'
  // }

  hotels: IHotelResponse[] = []

  ngOnInit(): void {
    this.hotelService.getAllHotels().subscribe((response:any) => {
      this.hotels = response;
      console.log(this.hotels);
    })
  }
  
  goToRoomComponent(hotelId: string, hotelName: string) {
    sessionStorage.setItem('hotelId', hotelId);
    sessionStorage.setItem('hotelName', hotelName)
    this.router.navigate(['client-rooms'])
  }

  // goToRatingComponent(hotelId: string) {
  //   sessionStorage.setItem('hotelId', hotelId);
  //   this.router.navigate(['rating']);
  // }

}
