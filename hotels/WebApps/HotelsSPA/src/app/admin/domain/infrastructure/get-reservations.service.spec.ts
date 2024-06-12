import { TestBed } from '@angular/core/testing';

import { GuestReservationsService } from './get-reservations.service';

describe('GuestREservationsService', () => {
  let service: GuestReservationsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GuestReservationsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});