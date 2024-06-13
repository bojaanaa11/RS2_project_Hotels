import { TestBed } from '@angular/core/testing';

import { CheckOutFacadeService } from './check-out-facade.service';

describe('CheckOutFacadeService', () => {
  let service: CheckOutFacadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CheckOutFacadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});