import { TestBed } from '@angular/core/testing';

import { UserorderService } from './userorder.service';

describe('UserorderService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UserorderService = TestBed.get(UserorderService);
    expect(service).toBeTruthy();
  });
});
