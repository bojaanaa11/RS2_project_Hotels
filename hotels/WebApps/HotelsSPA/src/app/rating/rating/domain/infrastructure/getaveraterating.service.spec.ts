import { TestBed } from '@angular/core/testing';
import { GetAverageRatingService } from './getaveragerating.service';

describe('GetAverageRatingService', () => {
  let service: GetAverageRatingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetAverageRatingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});