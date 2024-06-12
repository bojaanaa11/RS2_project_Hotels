import { TestBed } from '@angular/core/testing';

import { AddRatingFacadeService } from './addrating-facade.service';

describe('UserFacadeService', () => {
  let service: AddRatingFacadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddRatingFacadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});