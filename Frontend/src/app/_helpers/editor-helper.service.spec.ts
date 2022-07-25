import { TestBed } from '@angular/core/testing';

import { EditorHelperService } from './editor-helper.service';

describe('EditorHelperService', () => {
  let service: EditorHelperService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EditorHelperService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
