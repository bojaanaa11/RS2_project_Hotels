import { TestBed } from '@angular/core/testing';

import { HotelFacadeService } from './hotel-facade.service';

describe('HotelFacadeService', () => {
  let service: HotelFacadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HotelFacadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});