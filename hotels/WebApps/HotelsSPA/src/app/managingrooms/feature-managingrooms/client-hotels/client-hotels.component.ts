import { Component, OnInit } from '@angular/core';
import { HotelFacadeService } from '../../domain/application-services/hotel-facade.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-client-hotels',
  templateUrl: './client-hotels.component.html',
  styleUrl: './client-hotels.component.css'
})
export class ClientHotelsComponent implements OnInit {
  
  constructor(private hotelService: HotelFacadeService, private router: Router) {}

  ngOnInit(): void {
    this.hotelService.getAllHotels().subscribe((response:any) => {
      this.hotels = response;
      console.log(this.hotels);
    })
  }

  hotels;

  goToRoomComponent(hotelId) {
    sessionStorage.setItem('hotelId', hotelId);
    this.router.navigate(['room'])
  }

}
