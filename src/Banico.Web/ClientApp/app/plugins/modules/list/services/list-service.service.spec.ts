import { TestBed } from '@angular/core/testing';

import { ListserviceService } from './list-service.service';

describe('ListserviceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ListserviceService = TestBed.get(ListserviceService);
    expect(service).toBeTruthy();
  });
});
