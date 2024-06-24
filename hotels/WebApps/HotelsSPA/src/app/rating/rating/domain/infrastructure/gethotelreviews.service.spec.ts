import { TestBed } from '@angular/core/testing';
import { GetHotelReviewsService } from './gethotelreviews.service';



describe('GetHotelReviewsService', () => {
  let service: GetHotelReviewsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetHotelReviewsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});