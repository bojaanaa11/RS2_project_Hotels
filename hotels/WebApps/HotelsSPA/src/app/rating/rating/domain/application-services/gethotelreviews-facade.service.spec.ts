import { TestBed } from '@angular/core/testing';
import { GetHotelReviewsFacadeService } from './gethotelreviews-facade.service';

describe('GetHotelReviewsFacadeService', () => {
  let service: GetHotelReviewsFacadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetHotelReviewsFacadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});