import { TestBed } from '@angular/core/testing';

import { GuestHotelStaysFacadeService } from './get-hotel-stays-facade.service';

describe('GuestHotelStaysFacadeService', () => {
  let service: GuestHotelStaysFacadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GuestHotelStaysFacadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});