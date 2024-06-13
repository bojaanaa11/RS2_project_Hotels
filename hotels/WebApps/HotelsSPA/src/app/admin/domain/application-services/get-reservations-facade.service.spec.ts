import { TestBed } from '@angular/core/testing';

import { GuestReservationsFacadeService } from './get-reservations-facade.service';

describe('GuestReservationsFacadeService', () => {
  let service: GuestReservationsFacadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GuestReservationsFacadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});