import { TestBed } from '@angular/core/testing';

import { AdminGGuard } from './admin-g.guard';

describe('AdminGGuard', () => {
  let guard: AdminGGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(AdminGGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
