import { TestBed } from '@angular/core/testing';

import { AddRatingService } from './addrating.service';

describe('AddRatingService', () => {
  let service: AddRatingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddRatingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});