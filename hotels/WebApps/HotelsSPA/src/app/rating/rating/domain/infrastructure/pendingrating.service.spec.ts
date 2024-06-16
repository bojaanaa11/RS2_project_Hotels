import { TestBed } from '@angular/core/testing';

import { PendingRatingService } from './pendingrating.service';

describe('PendingRatingService', () => {
  let service: PendingRatingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PendingRatingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});