import { Injectable } from '@angular/core';
import { RoomService } from '../infrastructure/room.service';
import { Observable } from 'rxjs';
import { IRoomResponse } from '../models/room-response';

@Injectable({
  providedIn: 'root'
})
export class RoomFacadeService {

  constructor(private roomService: RoomService) { }

  public getAllRooms(hoteId: string): Observable<Array<IRoomResponse>> {
    return this.roomService.getAllRooms(hoteId);
  }
}
