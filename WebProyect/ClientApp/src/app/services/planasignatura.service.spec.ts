import { TestBed } from '@angular/core/testing';

import { PlanasignaturaService } from './planasignatura.service';

describe('PlanasignaturaService', () => {
  let service: PlanasignaturaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlanasignaturaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
