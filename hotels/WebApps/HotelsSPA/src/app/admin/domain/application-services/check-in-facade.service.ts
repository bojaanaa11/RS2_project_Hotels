import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CheckInService } from '../infrastructure/check-in.service';

@Injectable({
  providedIn: 'root',
})
export class CheckInFacadeService {
  constructor(private checkInService: CheckInService) {}

  public CheckIn(GuestId : string, ReservationId: string): Observable<void> {
    return this.checkInService.checkIn(GuestId,ReservationId);
  }
}