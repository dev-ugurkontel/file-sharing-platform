import { TestBed } from '@angular/core/testing';

import { PutService } from './post.service';

describe('PutService', () => {
  let service: PutService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PutService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
