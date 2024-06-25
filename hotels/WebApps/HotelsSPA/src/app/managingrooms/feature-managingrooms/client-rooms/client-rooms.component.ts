import { Component, OnInit } from '@angular/core';
import { RoomFacadeService } from '../../domain/application-services/room-facade.service';
import { HotelFacadeService } from '../../domain/application-services/hotel-facade.service';
import { IRoomResponse } from '../../domain/models/room-response';
import { Router } from '@angular/router';

@Component({
  selector: 'app-client-rooms',
  templateUrl: './client-rooms.component.html',
  styleUrl: './client-rooms.component.css'
})
export class ClientRoomsComponent implements OnInit{

  rooms: IRoomResponse[] = [];
  hotelId: string;
  hotelName: string;
  popUpRoom: IRoomResponse = null;

  constructor(private roomService: RoomFacadeService, private router: Router) {}

  ngOnInit(): void {
    this.hotelId = sessionStorage.getItem('hotelId');
    this.hotelName = sessionStorage.getItem('hotelName');
    this.roomService.getAllRooms(this.hotelId).subscribe((response:any) => {
      this.rooms = response;
      console.log(this.rooms);
      this.popUpRoom = this.rooms[0]
    })
  }

  // goToReservationsComponent(roomId: string) {
  //   sessionStorage.setItem('hotelId', this.hotelId);
  //   sessionStorage.setItem('roomId', roomId);
  //   this.router.navigate(['reservations'])
  // }

  openImages(room: IRoomResponse) {
    this.popUpRoom=room;
    let popUpDiv = document.getElementById("popUpDiv");
    popUpDiv.style.display = "flex";
  }

  closePopUp() {
    let popUpDiv = document.getElementById("popUpDiv");
    popUpDiv.style.display = "none";
  }
  
}
