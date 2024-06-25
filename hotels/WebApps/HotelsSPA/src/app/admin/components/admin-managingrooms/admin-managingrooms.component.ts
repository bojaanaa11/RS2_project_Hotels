import { Component, OnInit } from '@angular/core';
import { IHotel } from '../../domain/models/hotel';
import { HotelFacadeService } from '../../domain/application-services/hotel-facade.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-managingrooms',
  templateUrl: './admin-managingrooms.component.html',
  styleUrl: './admin-managingrooms.component.css'
})
export class AdminManagingroomsComponent implements OnInit {
  hotels: IHotel[] = [];
  newHotel: IHotel = {
    id: '',
    name: '',
    address: '',
    city: '',
    country: '',
    fileImages: [],
    rooms: [],
    //description: ''
  };

  constructor(private hotelFacadeService: HotelFacadeService, private router: Router) {

  }

  ngOnInit(): void {
    this.loadHotels();
  }

  public loadHotels(): void {
    this.hotelFacadeService.GetHotels().subscribe((response:IHotel[]) => {
      this.hotels = response;
      this.hotels.forEach(hotel => {
        hotel.fileImages.forEach(image => {
          
        });
      });
    })
  }
  
 

  public addHotel(): void {
    console.log("adding new hotel")
    this.router.navigate(['add-hotel'])
  }

  updateHotel(hotel: IHotel): void {
    //this.hotelFacadeService.UpdateHotel(hotel).subscribe(() => {
      sessionStorage.setItem('hotelId', hotel.id);
      this.router.navigate(['update-hotel'])
    //});
  }

  deleteHotel(id: string): void {
    if (confirm('Are you sure you want to delete hotel?')){
      this.hotelFacadeService.DeleteHotel(id).subscribe(() => {
        this.loadHotels();
      });
    }
  }

}
