import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemApproveComponent } from './item-approve.component';

describe('ItemApproveComponent', () => {
  let component: ItemApproveComponent;
  let fixture: ComponentFixture<ItemApproveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemApproveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemApproveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
