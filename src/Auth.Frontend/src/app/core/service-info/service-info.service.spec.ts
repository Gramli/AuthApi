import { TestBed } from '@angular/core/testing';

import { ServiceInfoService } from './service-info.service';

describe('ServiceInfoService', () => {
  let service: ServiceInfoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServiceInfoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
