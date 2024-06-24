import { TestBed } from '@angular/core/testing';
import {  } from './gethotelreviews-facade.service';
import { GetAverageRatingFacadeService } from './getaveragerating-facade.service';

describe('GetAverageRatingFacadeService', () => {
  let service: GetAverageRatingFacadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetAverageRatingFacadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});