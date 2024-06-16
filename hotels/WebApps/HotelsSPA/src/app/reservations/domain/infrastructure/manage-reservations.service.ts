import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAddReservationRequest } from '../models/add-reservation-request';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ManageReservationsService {
  private readonly url: string = "http://localhost:8003/api/v1/Reservations";

  constructor(private httpClient: HttpClient) { }

  public create(request: IAddReservationRequest): Observable<Object> {
    return this.httpClient.post(`${this.url}`, request);
  }
}
