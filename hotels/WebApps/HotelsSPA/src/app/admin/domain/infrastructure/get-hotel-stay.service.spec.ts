import { TestBed } from '@angular/core/testing';

import { GuestHotelStaysService } from './get-hotel-stays.service';

describe('GuestHotelStaysService', () => {
  let service: GuestHotelStaysService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GuestHotelStaysService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});