import { TestBed } from '@angular/core/testing';

import { UserDataServiceService } from './user-data-service.service';
import { HttpClientModule } from '@angular/common/http'
describe('UserDataServiceService', () => {
  let service: UserDataServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule
      ],
    });
    service = TestBed.inject(UserDataServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
