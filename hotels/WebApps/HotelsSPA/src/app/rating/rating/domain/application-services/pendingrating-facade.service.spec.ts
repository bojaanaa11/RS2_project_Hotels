import { TestBed } from '@angular/core/testing';

import { PendingRatingFacadeService } from './pendingrating-facade.service';

describe('UserFacadeService', () => {
  let service: PendingRatingFacadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PendingRatingFacadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});