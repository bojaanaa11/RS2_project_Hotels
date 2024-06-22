import { Component, OnInit } from '@angular/core';
import { RoomFacadeService } from '../../domain/application-services/room-facade.service';
import { HotelFacadeService } from '../../domain/application-services/hotel-facade.service';
import { IRoomResponse } from '../../domain/models/room-response';

@Component({
  selector: 'app-client-rooms',
  templateUrl: './client-rooms.component.html',
  styleUrl: './client-rooms.component.css'
})
export class ClientRoomsComponent implements OnInit{

  //rooms: IRoomResponse[] = []
  rooms;
  constructor(private roomService: RoomFacadeService) {}

  ngOnInit(): void {
    this.hotelId = sessionStorage.getItem('hotelId');
    this.roomService.getAllRooms(this.hotelId).subscribe((response:any) => {
      this.rooms = response;
      console.log(this.rooms);
    })
  }
  
  hotelId;

  goToReservationsComponent() {
    
  }

}
