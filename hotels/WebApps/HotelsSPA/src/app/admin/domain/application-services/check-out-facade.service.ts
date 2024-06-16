import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CheckOutService } from '../infrastructure/check-out.service';

@Injectable({
  providedIn: 'root',
})
export class CheckOutFacadeService {
  constructor(private checkOutService: CheckOutService) {}

  public CheckOut(ReservationId: string, EndDate: string): Observable<void> {
    return this.checkOutService.checkOut(ReservationId,EndDate);
  }
}