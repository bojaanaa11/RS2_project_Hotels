import { TestBed } from '@angular/core/testing';

import { CheckInFacadeService } from './check-in-facade.service';

describe('CheckInFacadeService', () => {
  let service: CheckInFacadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CheckInFacadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});